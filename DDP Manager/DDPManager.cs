using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace DDP_Manager
{
    public partial class DPPManager : Form
    {
        List<ListBox> m_listboxList = new List<ListBox>();

        public DPPManager()
        {
            InitializeComponent();
            m_listboxList.Add(lbContent1);
            m_listboxList.Add(lbContent2);
            m_listboxList.Add(lbContent3);
        }

        private List<string> getTracks(string url, bool onlyReEntries = false)
        {
            List<string> items = new List<string>();
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string content = reader.ReadToEnd();
                reader.Close();
                response.Close();

                int pFrom = 0, pTo = 0, rank = 0;
                String result = String.Empty, artist = String.Empty, track = String.Empty, title = String.Empty;

                pFrom = content.IndexOf("<h1>") + "<h1>".Length;
                pTo = content.IndexOf("</h1>", pFrom);
                title = content.Substring(pFrom, pTo - pFrom);

                content = content.Remove(0, content.IndexOf("<div class=\"eintrag\">") + "<div class=\"eintrag\">".Length);
                for (var iterator = 0; iterator < 100; ++iterator)
                {
                    pFrom = content.IndexOf("<div class=\"platz\">") + "<div class=\"platz\">".Length;
                    pTo = content.IndexOf("</div>", pFrom);
                    String strRank = content.Substring(pFrom, pTo - pFrom);
                    rank = Int32.Parse(content.Substring(pFrom, pTo - pFrom));
                    content = content.Remove(0, content.IndexOf("<div class=\"platz\">") + "<div class=\"platz\">".Length);

                    pFrom = content.IndexOf("<div class=\"platz\">") + "<div class=\"platz\">".Length;
                    pTo = content.IndexOf("</div>", pFrom);
                    String res = content.Substring(pFrom, pTo - pFrom);
                    bool isReentry = (res == "RE");
                    content = content.Remove(0, content.IndexOf("<div class=\"info "));

                    pFrom = content.IndexOf("<div class=\"info ") + "<div class=\"info ".Length;
                    pTo = content.IndexOf("<div class=\"icons\">");
                    result = content.Substring(pFrom, pTo - pFrom);

                    pFrom = result.IndexOf("<div class=\"interpret\">") + "<div class=\"interpret\">".Length;
                    pTo = result.IndexOf("</div>");
                    artist = result.Substring(pFrom, pTo - pFrom);

                    result = result.Remove(0, pTo + "</div>".Length);
                    pFrom = result.IndexOf("<div class=\"titel\">") + "<div class=\"titel\">".Length;
                    pTo = result.IndexOf("</div>");
                    track = result.Substring(pFrom, pTo - pFrom);

                    result = rank.ToString().PadLeft(3, '0') + " - " + artist + " - " + track + "\n";
                    result = result.ToLower();
                    result = Regex.Replace(result, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
                    result = Regex.Replace(result, @"\({1}[a-z]", m => m.Value.ToUpper());

                    if (!onlyReEntries || (onlyReEntries && isReentry))
                    {
                        items.Add(result);
                    }

                    content = content.Remove(0, content.IndexOf("<div class=\"icons\">") + "<div class=\"icons\">".Length);
                }
            }
            catch (Exception)
            {
                if (items.Count == 0 && !onlyReEntries)
                {
                    items.Add("Failed to load the page content.");
                }
                else if (items.Count == 0 && onlyReEntries)
                {
                    items.Add("There are no re-entries or the page was not loaded correctly.");
                }
            }
            return items;
        }

        private void loadTracks()
        {
            List<List<string>> contentList = new List<List<string>>()
            {
                new List<string>(),
                new List<string>(),
                new List<string>()
            };

            List<KeyValuePair<string, bool>> urlList = new List<KeyValuePair<string, bool>>()
            {
                new KeyValuePair<string, bool>("http://www.deutsche-dj-playlist.de/DDP-Charts-Top100/", false),
                new KeyValuePair<string, bool>("http://www.deutsche-dj-playlist.de/DDP-Charts-Neueinsteiger/", false),
                new KeyValuePair<string, bool>("http://www.deutsche-dj-playlist.de/DDP-Charts-Top100/", true)
            };
            
            // Check if all lists are equally
            if(!(m_listboxList.Count == urlList.Count) || !(m_listboxList.Count == contentList.Count))
            {
                return;
            }

            for(var i = 0; i < m_listboxList.Count; ++i)
            {
                // Get Tracks
                contentList[i] = getTracks(urlList[i].Key, urlList[i].Value);

                // Fill Tracks into GUI
                m_listboxList[i].Invoke((MethodInvoker)delegate
                {
                    m_listboxList[i].DataSource = contentList[i];
                });
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Load Tracks async
            Thread t = new Thread(loadTracks);
            t.IsBackground = true;
            t.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Properties.Settings.Default.LastSaveFolder;
            if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                List<string> fileNames = new List<string>()
                {
                    fbd.SelectedPath + "\\Top100.txt",
                    fbd.SelectedPath + "\\Neueinsteiger.txt",
                    fbd.SelectedPath + "\\Wiedereinsteiger.txt"
                };

                if(!(m_listboxList.Count == fileNames.Count))
                {
                    return;
                }

                for(var i = 0; i < m_listboxList.Count; ++i)
                {
                    StreamWriter sw = new StreamWriter(fileNames[i]);
                    List<string> list = new List<string>();

                    foreach (var item in m_listboxList[i].Items)
                    {
                        string str = item.ToString();
                        str = Regex.Replace(str, @"\r\n?|\n", String.Empty);
                        list.Add(str);
                    }
                    string res = String.Join("\r\n", list);

                    sw.Write(res);

                    sw.Close();
                }

                // Save last folder
                Properties.Settings.Default.LastSaveFolder = fbd.SelectedPath;
            }
        }

        private void lbContent_DoubleClick(object sender, EventArgs e)
        {
            string content = ((ListBox)sender).SelectedItem.ToString();
            var splitted = content.Split('-');
            string artist = splitted[1].Remove(0, 1);
            artist = artist.Replace("Feat. ", "");
            artist = artist.Replace("& ", "");
            artist = artist.Replace("/\\ ", "");
            string title = splitted[2].Remove(0, 1);
            title = title.Remove(title.Length - 1);
            Clipboard.SetText(artist + title);
        }
    }
}
