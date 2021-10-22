using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFBV3 {
    public partial class frmAbsence : Form {


        private ZobrazeniAbsence _zobrazeni;
        private JObject _AbsenceData = null;

        public frmAbsence(JObject absenceData) {
            InitializeComponent();
            _AbsenceData = absenceData;
        }


        private void frmAbsence_Load(object sender, EventArgs e) {
            ZmenitZobrazeni(ZobrazeniAbsence.Dny);
        }

        private void frmAbsence_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Escape) {
                e.Handled = true;
                Close();
            }
        }

        private void ZmenitZobrazeni(ZobrazeniAbsence zobrazeni) {
            _zobrazeni = zobrazeni;
            var pozadi = Color.FromArgb(255, 60, 62, 70);
            var aktivni = Color.FromArgb(255, 60, 120, 160);

            btnDny.BackColor = (zobrazeni == ZobrazeniAbsence.Dny) ? aktivni : pozadi;
            btnMesice.BackColor = (zobrazeni == ZobrazeniAbsence.Mesice) ? aktivni : pozadi;
            btnPredmety.BackColor = (zobrazeni == ZobrazeniAbsence.Predmety) ? aktivni : pozadi;

            Prekreslit();
        }

        private void Prekreslit() {
            //MessageBox.Show(_AbsenceData.ToString());
            pbAbsence.Image = AbsenceRenderer.Vyrendrovat(_AbsenceData, _zobrazeni);
        }

        private void btnDny_Click(object sender, EventArgs e) {
            ZmenitZobrazeni(ZobrazeniAbsence.Dny);
        }

        private void btnMesice_Click(object sender, EventArgs e) {
            ZmenitZobrazeni(ZobrazeniAbsence.Mesice);
        }

        private void btnPredmety_Click(object sender, EventArgs e) {
            ZmenitZobrazeni(ZobrazeniAbsence.Predmety);
        }

        private void button1_Click(object sender, EventArgs e) {
            var napovedaFrm = new frmAbsenceNapoveda();
            napovedaFrm.ShowDialog();
        }
    }
}
