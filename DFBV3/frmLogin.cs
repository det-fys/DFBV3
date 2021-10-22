using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFBV3 { 
    public partial class frmLogin : Form {
        public string sUser;
        public string sPwd;
        public string sAddr;

        public frmLogin() {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e) {
            if (DFBV3.Properties.Settings.Default.OLDSCHOOL) {
                BackColor = SystemColors.Control;
                foreach (Button btn in (new Button[] { btnCancel, btnOK })) {
                    //btn.Text = "test";
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = SystemColors.ControlText;
                    btn.FlatStyle = FlatStyle.Standard;
                    btn.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                }

                foreach (TextBox tb in (new TextBox[] { tbAddress, tbLogin, tbPwd})) {
                    tb.BorderStyle = BorderStyle.Fixed3D;
                    tb.BackColor = SystemColors.Window;
                    tb.ForeColor = SystemColors.WindowText;
                    tb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                }

                foreach (Label tb in (new Label[] { lblUsername, lblAddress, lblPwd })) {
                    tb.ForeColor = SystemColors.ControlText;
                    tb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                }

                lblExample.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                lblExample.ForeColor = SystemColors.ControlText;

                cbRemember.ForeColor = SystemColors.ControlText;
                cbRemember.BackColor = SystemColors.Control;
                cbRemember.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold | FontStyle.Underline);

                lblRemember.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                lblRemember.ForeColor = SystemColors.ControlText;

                //foreach (GroupBox btn in (new GroupBox[] { gbHodina, gbInfo, gbPrumer, gbRozvrh, gbZnamky })) {
                //    btn.BackColor = SystemColors.Control;
                //    btn.ForeColor = SystemColors.ControlText;
                //    btn.FlatStyle = FlatStyle.Standard;
                //    btn.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                //}

            }

            DialogResult = DialogResult.None;

            tbLogin.Text = DFBV3.Properties.Settings.Default.Jmeno;
            tbAddress.Text = DFBV3.Properties.Settings.Default.Adresa;

            string PwdEnc = DFBV3.Properties.Settings.Default.PwdEnc;

            if (PwdEnc != "") {
                try {
                    tbPwd.Text = Crypto.Derypt(PwdEnc);
                    btnOK_Click(null, null);
                } catch {
                    tbPwd.Text = "";
                }
            } else {
                tbPwd.Text = "";
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (!tbAddress.Text.EndsWith("/"))
                tbAddress.Text += "/";

            DFBV3.Properties.Settings.Default.Jmeno = tbLogin.Text;
            DFBV3.Properties.Settings.Default.Adresa = tbAddress.Text;

            string PwdEnc = "";
            if (cbRemember.Checked) {
                try {
                    PwdEnc = Crypto.Crypt(tbPwd.Text);
                } catch { }
            }

            DFBV3.Properties.Settings.Default.PwdEnc = PwdEnc;
            DFBV3.Properties.Settings.Default.Save();

            sUser = tbLogin.Text;
            sPwd = tbPwd.Text;
            sAddr = tbAddress.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

}
