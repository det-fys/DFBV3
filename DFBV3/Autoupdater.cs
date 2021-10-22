using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DFBV3 {
    public static class Autoupdater {
        public static bool ZkontrolovatAktualizace(string Endpoint, string Verze) {
            try {
                var request = (HttpWebRequest)WebRequest.Create($"{Endpoint}autoupdate/currentversion");

                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var NovaVerze = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (NovaVerze == Verze) { return false; }

                if (MessageBox.Show($"K dispozici je nová verze DF Bakalářů (v{NovaVerze}). Chcete ji nyní stáhnout a nainstalovat?", "Aktualizace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return false;

                var fn = Temp.Cesta() + "\\DFBV3-autoupdate.exe";

                var wc = new WebClient();
                try {
                    wc.DownloadFile($"{Endpoint}DFBV3-v{NovaVerze.Replace('.', '-')}-setup.exe", fn);
                } catch {
                    MessageBox.Show("Nepodařilo se automaticky stáhnout novou verzi. ", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Process.Start(fn, "/aktualizace=true");

            } catch {
                return false;
            }

            return true;
        }
    
    }
}
