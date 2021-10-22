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
    public partial class frmZvyrazneni : Form {
        public frmZvyrazneni(string Default = "") {
            InitializeComponent();

            tbText.Text = Default;
        }

        private void frmZvyrazneni_Load(object sender, EventArgs e) {

        }

        public string Vstup() {
            return tbText.Text;
        }
    }
}
