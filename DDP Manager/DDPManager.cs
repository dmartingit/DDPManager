using System;
using System.IO;
using System.Net;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DDP_Manager
{
    public partial class DPPManager : Form
    {

        public DPPManager()
        {
            InitializeComponent();
            this.cbURL.SelectedIndex = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lbContent.Items.Clear();

            try
            {
                WebRequest request = WebRequest.Create(cbURL.Text);
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
                this.Text = title;

                content = content.Remove(0, content.IndexOf("<div class=\"eintrag\">") + "<div class=\"eintrag\">".Length);
                for(var iterator = 0; iterator < 100; ++iterator)
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

                    if (!cbReentry.Checked || (cbReentry.Checked && isReentry))
                    {
                        lbContent.Items.Add(result);
                    }

                    content = content.Remove(0, content.IndexOf("<div class=\"icons\">") + "<div class=\"icons\">".Length);
                }
            }
            catch(Exception)
            {
                if (lbContent.Items.Count == 0 && !cbReentry.Checked)
                {
                    lbContent.Items.Add("Failed to load the page content.");
                }
                else if (lbContent.Items.Count == 0 && cbReentry.Checked)
                {
                    lbContent.Items.Add("There are no re-entries.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sF1 = new SaveFileDialog();
            sF1.Filter = "Text Files|*.txt";
            if (sF1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sF1.FileName);
                List<string> list = new List<string>();

                foreach (var item in lbContent.Items)
                {
                    string str = item.ToString();
                    str = Regex.Replace(str, @"\r\n?|\n", String.Empty);
                    list.Add(str);
                }
                string res = String.Join("\r\n", list);

                sw.Write(res);

                sw.Close();
            }
        }

        private void lbContent_DoubleClick(object sender, EventArgs e)
        {
            string content = lbContent.SelectedItem.ToString();
            var splitted = content.Split('-');
            string artist = splitted[1].Remove(0, 1);
            artist = artist.Replace("Feat. ", "");
            string title = splitted[2].Remove(0, 1);
            title = title.Remove(title.Length - 1);
            Clipboard.SetText(artist + title);
        }
    }
}
