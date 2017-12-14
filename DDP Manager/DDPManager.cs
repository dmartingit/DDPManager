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
        List<Label> m_labelList = new List<Label>();

        public DPPManager()
        {
            InitializeComponent();
            m_listboxList.Add(lbContent1);
            m_listboxList.Add(lbContent2);
            m_listboxList.Add(lbContent3);
            m_labelList.Add(lblContent1);
            m_labelList.Add(lblContent2);
            m_labelList.Add(lblContent3);
        }

        private Tuple<string, List<string>> getTracks(string url, bool onlyReEntries = false)
        {
            List<string> tracks = new List<string>();

            int pFrom = 0, pTo = 0, rank = 0;
            String track = String.Empty, artist = String.Empty, trackname = String.Empty, title = String.Empty;

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

                pFrom = content.IndexOf("<h1>") + "<h1>".Length;
                pTo = content.IndexOf("</h1>", pFrom);
                title = content.Substring(pFrom, pTo - pFrom);
                if(onlyReEntries)
                {
                    title = title.Replace("TOP 100", "WIEDEREINSTEIGER");
                }

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
                    bool isReentry = (content.Substring(pFrom, pTo - pFrom) == "RE");
                    content = content.Remove(0, content.IndexOf("<div class=\"info "));

                    pFrom = content.IndexOf("<div class=\"info ") + "<div class=\"info ".Length;
                    pTo = content.IndexOf("<div class=\"icons\">");
                    track = content.Substring(pFrom, pTo - pFrom);

                    pFrom = track.IndexOf("<div class=\"interpret\">") + "<div class=\"interpret\">".Length;
                    pTo = track.IndexOf("</div>");
                    artist = track.Substring(pFrom, pTo - pFrom);

                    track = track.Remove(0, pTo + "</div>".Length);
                    pFrom = track.IndexOf("<div class=\"titel\">") + "<div class=\"titel\">".Length;
                    pTo = track.IndexOf("</div>");
                    trackname = track.Substring(pFrom, pTo - pFrom);

                    track = rank.ToString().PadLeft(3, '0') + " - " + artist + " - " + trackname + "\n";
                    track = track.ToLower();
                    track = Regex.Replace(track, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
                    track = Regex.Replace(track, @"\({1}[a-z]", m => m.Value.ToUpper());

                    if (!onlyReEntries || (onlyReEntries && isReentry))
                    {
                        tracks.Add(track);
                    }

                    content = content.Remove(0, content.IndexOf("<div class=\"icons\">") + "<div class=\"icons\">".Length);
                }
            }
            catch (Exception)
            {
                if (tracks.Count == 0 && !onlyReEntries)
                {
                    tracks.Add("Failed to load the page content.");
                }
                else if (tracks.Count == 0 && onlyReEntries)
                {
                    tracks.Add("There are no re-entries or the page was not loaded correctly.");
                }
            }

            return new Tuple<string, List<string>>(title, tracks);
        }

        private void loadTracks()
        {
            List<List<string>> contentList = new List<List<string>>()
            {
                new List<string>(),
                new List<string>(),
                new List<string>()
            };

            List<Tuple<string, bool>> urlList = new List<Tuple<string, bool>>()
            {
                new Tuple<string, bool>("http://www.deutsche-dj-playlist.de/DDP-Charts-Top100/", false),
                new Tuple<string, bool>("http://www.deutsche-dj-playlist.de/DDP-Charts-Neueinsteiger/", false),
                new Tuple<string, bool>("http://www.deutsche-dj-playlist.de/DDP-Charts-Top100/", true)
            };
            
            // Check if all lists are equally
            if(!(m_listboxList.Count == urlList.Count) || !(m_listboxList.Count == contentList.Count))
            {
                return;
            }

            for(var i = 0; i < m_listboxList.Count; ++i)
            {
                // Get Tracks
                Tuple<string, List<string>> tracks = getTracks(urlList[i].Item1, urlList[i].Item2);
                contentList[i] = tracks.Item2;

                // Fill Tracks into GUI
                m_listboxList[i].Invoke((MethodInvoker)delegate
                {
                    m_listboxList[i].DataSource = contentList[i];
                });

                // Set Labels
                m_labelList[i].Invoke((MethodInvoker)delegate
                {
                    m_labelList[i].Text = tracks.Item1;
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
