using DFBV3.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFBV3 {
    public partial class Form1 : Form {
        public Form1() { InitializeComponent(); }

        private BakaAPI API = new BakaAPI();

        JObject RozvrhData;
        JObject ZnamkyData;

        RozvrhStyl rozvrhStyl = new RozvrhStyl();
        ZnamkyStyl znamkyStyl = new ZnamkyStyl();
        RozvrhInteraktivniStyl rozvrhInteraktivniStyl = new RozvrhInteraktivniStyl();

        DateTime RozvrhTyden = DateTime.Now;
        //List<Interaktivni<RozvrhRenderer.ZpracovanaHodina>> OblastiRozvrhu = new List<Interaktivni<RozvrhRenderer.ZpracovanaHodina>>();
        RozvrhInteraktivni rozvrhInteraktivni = null;


        private void Form1_Load(object sender, EventArgs e) {
            NastavitZahlavi();

            if (DFBV3.Properties.Settings.Default.OLDSCHOOL) {
                BackColor = SystemColors.Control;
                foreach (Button btn in (new Button[] { btnCurrentWeek, btnKonec, btnLogout, btnNextWeek, btnPrevWeek, btnRestart})) {
                    //btn.Text = "test";
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = SystemColors.ControlText;
                    btn.FlatStyle = FlatStyle.Standard;
                    btn.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                }

                foreach (GroupBox btn in (new GroupBox[] { gbHodina, gbInfo, gbPrumer, gbRozvrh, gbZnamky})) {
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = SystemColors.ControlText;
                    btn.FlatStyle = FlatStyle.Standard;
                    btn.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                }

                lblUser.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold | FontStyle.Underline);
                lblSchool.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);

                //pbRozvrh.BorderStyle = BorderStyle.FixedSingle;

                rozvrhStyl.OkrajeBunek = true;
                rozvrhStyl.KreslitPozadi = true;

                rozvrhStyl.Pozadi = Color.LightGray;

                rozvrhStyl.WidthFix = -2;

                rozvrhStyl.ZahlaviDenF = Brushes.DarkGray;
                rozvrhStyl.ZahlaviHodinaF = Brushes.DarkGray;

                rozvrhStyl.HodinaF = Brushes.Black;
                rozvrhStyl.HodinaTrF = Brushes.Blue;
                rozvrhStyl.HodinaAF = Brushes.Black;
                rozvrhStyl.HodinaATrF = Brushes.Blue;
                rozvrhStyl.HodinaCHF = Brushes.Black;
                rozvrhStyl.HodinaCHTrF = Brushes.Blue;
                rozvrhStyl.HodinaSvF = Brushes.Black;
                rozvrhStyl.HodinaSvTrF = Brushes.Blue;
                rozvrhStyl.HodinaHdF = Brushes.Black;
                rozvrhStyl.HodinaHdTrF = Brushes.Blue;

                rozvrhStyl.BunkaPadding = 0;
                rozvrhStyl.BunkaVyplnHodina = Brushes.White;
                rozvrhStyl.BunkaVyplnHodinaA = Brushes.LightGreen;
                //rozvrhStyl.BunkaVyplnHodinaX = Brushes.LightGray;
                rozvrhStyl.BunkaVyplnHodinaCH = Brushes.Pink;
                rozvrhStyl.BunkaVyplnHodinaSv = Brushes.LightCyan;
                rozvrhStyl.BunkaVyplnHodinaHd = new SolidBrush(Color.FromArgb(255, 190, 255));

                rozvrhStyl.ZahlaviDenF = Brushes.Black;//Brushes.DarkGray;
                rozvrhStyl.ZahlaviHodinaF = Brushes.Black;

                rozvrhStyl.BunkaVyplnZahlavi = Brushes.DarkGray;

                rozvrhStyl.ZahlaviDen = new Font("Courier New", 12, FontStyle.Bold);
                rozvrhStyl.ZahlaviHodinaCislo = new Font("Courier New", 12, FontStyle.Bold);
                rozvrhStyl.ZahlaviDenDatum = new Font("Arial", 10);
                rozvrhStyl.ZahlaviHodinaCas = new Font("Arial", 8);

                rozvrhStyl.HodinaZkr = new Font("Arial", 13, FontStyle.Bold);
                rozvrhStyl.HodinaUc = new Font("Arial", 10, FontStyle.Bold);
                rozvrhStyl.HodinaTr = new Font("Arial", 10, FontStyle.Bold);

                znamkyStyl.Okraje = true;
                znamkyStyl.Margin = 0;

                Brush[] cerny = {
                    Brushes.Black,
                    Brushes.Black,
                    Brushes.Black,
                    Brushes.Black,
                    Brushes.Black,
                    Brushes.Black
                };

                znamkyStyl.StupenVypln = znamkyStyl.StupenBarva;
                znamkyStyl.StupenBarva = cerny;

                znamkyStyl.VyskaPredmet = 54;
                znamkyStyl.VyskaZnamka = 36;

                znamkyStyl.DatumFix = 0;
                znamkyStyl.Padding = 1;

                znamkyStyl.ZahlaviVypln = new SolidBrush(Color.LightGray); 
                znamkyStyl.ZahlaviPredmetPismo = new Font("Microsoft Sans Serif", 13.0f, FontStyle.Bold);
                znamkyStyl.ZahlaviPredmetBarva = Brushes.Black;
                znamkyStyl.ZahlaviPrumerPismo = new Font("Microsoft Sans Serif", 15.0f, FontStyle.Bold);
                znamkyStyl.ZahlaviPrumerBarva = Brushes.Black;

                znamkyStyl.ZnamkaVypln = Brushes.White;
                znamkyStyl.ZnamkaTextPismo = new Font("Microsoft Sans Serif", 11.0f, FontStyle.Bold);
                znamkyStyl.ZnamkaVahaPismo = new Font("Microsoft Sans Serif", 11.0f);
                znamkyStyl.ZnamkaZnamkaPismo = new Font("Microsoft Sans Serif", 13.0f, FontStyle.Bold);

                znamkyStyl.ZnamkaBarva = Brushes.Black;
                znamkyStyl.ZnamkaNovaBarva = Brushes.Red;

                rozvrhInteraktivniStyl.ZvyrazneniOkraj = new Pen(Color.Black, 1);
                rozvrhInteraktivniStyl.ZvyrazneniVypln = new SolidBrush(Color.FromArgb(30, Color.Blue));
    }


            //defaultwb(wbPrumer);
            //defaultwb(wbZnamky);

            // autoupdate
            if (Autoupdater.ZkontrolovatAktualizace(Resources.UpdateEndpoint, Resources.Verze)) {
                konec();
                return;
            }
   

            frmLogin dialogLogin = new frmLogin();

            DialogResult lres = dialogLogin.ShowDialog();

            if (lres != DialogResult.OK) {
                konec();
                return;
            }
               
            Application.DoEvents();

            string loginErr = API.Login(dialogLogin.sUser, dialogLogin.sPwd, dialogLogin.sAddr);
            dialogLogin.Dispose();

            if (loginErr != null) {
                if (loginErr == "_http_error") 
                    MessageBox.Show("Chyba při žádosti o token. Buď server neexistuje, nebo byly použity nesprávné přihlašovací údaje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Chyba při žádosti o token: {loginErr}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);

                logout();
                return;
            }


            //lblUser.Text = API.getAccessToken();

            //MessageBox.Show(JsonConvert.SerializeObject()) ;

            Application.DoEvents();

            ZiskatData();

            // MessageBox.Show(JsonConvert.SerializeObject(RozvrhData));


        }

        void NastavitZahlavi(string text = "") {
            if (text != "")
                text += " - ";
            Text = text + "DF Bakaláři v" + Resources.Verze + " BETA";

        }

        void ZiskatData() {
            ZiskatInfo();
            ZiskatRozvrh();
            ZiskatZnamky();
        }

        void ZiskatRozvrh() {
            RozvrhData = null;
            prekreslit();
            Application.DoEvents();
            string datum = RozvrhTyden.ToString("yyyy-MM-dd");
            RozvrhData = API.GetModule($"api/3/timetable/actual?date={datum}");
            prekreslit();
            //System.IO.File.WriteAllText("D:\\zbynda\\rozvrhv3.json", JsonConvert.SerializeObject(RozvrhData));

        }

        void ZiskatInfo() {
            dynamic UserInfo = API.GetModule("api/3/user");
            lblUser.Text = UserInfo["FullName"] + " [" + UserInfo["UserTypeText"] + "]";
            lblSchool.Text = UserInfo["SchoolOrganizationName"];

            NastavitZahlavi(lblUser.Text);

            Application.DoEvents();
        }

        void ZiskatZnamky() {
            Application.DoEvents();
            ZnamkyData = API.GetModule("api/3/marks");
            //wbZnamky.DocumentText = Znamky.Vytvorit(ZnamkyData);
            prekreslit();

        }

        private void btnKonec_Click(object sender, EventArgs e) { konec(); }
        void konec() { Application.Exit(); }
        void restart() { Application.Restart(); }
        void logout() {
            DFBV3.Properties.Settings.Default.PwdEnc = "";
            DFBV3.Properties.Settings.Default.Save();
            restart();

        }

        private void btnLogout_Click(object sender, EventArgs e) { logout(); }
        private void btnRestart_Click(object sender, EventArgs e) { restart(); }

        private void Form1_Resize(object sender, EventArgs e) {
            prekreslit();
        }

        void prekreslit() {
            var rrv = RozvrhRenderer.Vyrendrovat(RozvrhData, pbRozvrh.Width, pbRozvrh.Height, rozvrhStyl);
            pbRozvrh.Image = rrv.ziskatObrazek();
            rozvrhInteraktivni = new RozvrhInteraktivni(pbRozvrhInteraktivni, rrv.ziskatOblasti(), rozvrhInteraktivniStyl);
            
            var obrazky = ZnamkyRenderer.Vyrendrovat(znamkyStyl, ZnamkyData, pbZnamky.Width, pbPrumer.Width, pbPrumer.Height);
            pbPrumer.Image = obrazky.Prumer;
            pbZnamky.Image = obrazky.Znamky;
            pbZnamky.Height = Math.Max(panZnamky.Height + 1, pbZnamky.Image.Height);
        }

        private void btnPrevWeek_Click(object sender, EventArgs e) {
            RozvrhTyden = RozvrhTyden.AddDays(-7);
            ZiskatRozvrh();
        }

        private void btnNextWeek_Click(object sender, EventArgs e) {
            RozvrhTyden = RozvrhTyden.AddDays(7);
            ZiskatRozvrh();
        }

        private void btnCurrentWeek_Click(object sender, EventArgs e) {
            RozvrhTyden = DateTime.Now;
            ZiskatRozvrh();
        }

        private void lblUser_MouseDoubleClick(object sender, MouseEventArgs e) {

        }

        private void scVert_SplitterMoved(object sender, SplitterEventArgs e) {
            prekreslit();
        }

        private void scHori_SplitterMoved(object sender, SplitterEventArgs e) {
            prekreslit();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e) {
            //prekreslit();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e) {
            //dynamic trd = RozvrhData;
            //RozvrhData = null;
            //prekreslit();
            //RozvrhData = trd;
        }

        private void lblSwitch_Click(object sender, EventArgs e) {
            DFBV3.Properties.Settings.Default.OLDSCHOOL = !DFBV3.Properties.Settings.Default.OLDSCHOOL;
            DFBV3.Properties.Settings.Default.Save();
            restart();
        }

        private void pbRozvrh_Click(object sender, EventArgs e) {
            //prekreslit();   
        }

        private void pbZnamky_Click(object sender, EventArgs e) {
            prekreslit();
        }

        private void pbRozvrh_MouseMove(object sender, MouseEventArgs e) {
            if (rozvrhInteraktivni != null) {
                rozvrhInteraktivni.PohybKurzoru(e.Location);
            }
        }

        private void pbRozvrhInteraktivni_MouseLeave(object sender, EventArgs e) {
            if (rozvrhInteraktivni != null) {
                rozvrhInteraktivni.Vycistit();
            }
        }

        private void pbRozvrhInteraktivni_Click(object sender, EventArgs e) {
            if (rozvrhInteraktivni != null) {
                rozvrhInteraktivni.ZobrazitPodrobnosti();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            //if (e.KeyCode == Keys.H && e.Control) {
            if (e.KeyCode == Keys.F2) {
                F2();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F3) {
                F3();
                e.Handled = true;
            }
        }

        private void F2() {
            var inputbox = new frmZvyrazneni(Settings.Default.Zvyraznit);
            if (inputbox.ShowDialog() == DialogResult.OK) {
                Settings.Default.Zvyraznit = inputbox.Vstup();
                Settings.Default.Save();
                prekreslit();
            }
        }

        private void F3() {
            JObject AbsenceData = API.GetModule("api/3/absence/student");
            //JObject AbsenceData = (JObject)JsonConvert.DeserializeObject(System.IO.File.ReadAllText("D:\\Zbynda\\absence.exekapp", Encoding.ASCII));

            var absenceDialog = new frmAbsence(AbsenceData);
            absenceDialog.ShowDialog();
        }


        private void gbInfo_Enter(object sender, EventArgs e) {

        }

        private void btnZvyraznit_Click(object sender, EventArgs e) {
            F2();
        }

        private void btnAbsence_Click(object sender, EventArgs e) {
            F3();
        }
    }
}
