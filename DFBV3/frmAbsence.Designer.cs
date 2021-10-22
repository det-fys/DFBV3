
namespace DFBV3 {
    partial class frmAbsence {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbsence));
            this.btnPredmety = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMesice = new System.Windows.Forms.Button();
            this.btnDny = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pbAbsence = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbsence)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPredmety
            // 
            this.btnPredmety.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnPredmety.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPredmety.FlatAppearance.BorderSize = 0;
            this.btnPredmety.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPredmety.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPredmety.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPredmety.Location = new System.Drawing.Point(322, 0);
            this.btnPredmety.Margin = new System.Windows.Forms.Padding(0);
            this.btnPredmety.Name = "btnPredmety";
            this.btnPredmety.Size = new System.Drawing.Size(162, 35);
            this.btnPredmety.TabIndex = 3;
            this.btnPredmety.Text = "podle předmětu";
            this.btnPredmety.UseVisualStyleBackColor = false;
            this.btnPredmety.Click += new System.EventHandler(this.btnPredmety_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.Controls.Add(this.btnPredmety, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMesice, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDny, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 35);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnMesice
            // 
            this.btnMesice.BackColor = System.Drawing.Color.SteelBlue;
            this.btnMesice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMesice.FlatAppearance.BorderSize = 0;
            this.btnMesice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMesice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMesice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMesice.Location = new System.Drawing.Point(161, 0);
            this.btnMesice.Margin = new System.Windows.Forms.Padding(0);
            this.btnMesice.Name = "btnMesice";
            this.btnMesice.Size = new System.Drawing.Size(161, 35);
            this.btnMesice.TabIndex = 2;
            this.btnMesice.Text = "měsíce";
            this.btnMesice.UseVisualStyleBackColor = false;
            this.btnMesice.Click += new System.EventHandler(this.btnMesice_Click);
            // 
            // btnDny
            // 
            this.btnDny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnDny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDny.FlatAppearance.BorderSize = 0;
            this.btnDny.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDny.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDny.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDny.Location = new System.Drawing.Point(0, 0);
            this.btnDny.Margin = new System.Windows.Forms.Padding(0);
            this.btnDny.Name = "btnDny";
            this.btnDny.Size = new System.Drawing.Size(161, 35);
            this.btnDny.TabIndex = 1;
            this.btnDny.Text = "dny";
            this.btnDny.UseVisualStyleBackColor = false;
            this.btnDny.Click += new System.EventHandler(this.btnDny_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.pbAbsence);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 35);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(484, 683);
            this.pnlMain.TabIndex = 1;
            // 
            // pbAbsence
            // 
            this.pbAbsence.Location = new System.Drawing.Point(0, 0);
            this.pbAbsence.Name = "pbAbsence";
            this.pbAbsence.Size = new System.Drawing.Size(112, 127);
            this.pbAbsence.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAbsence.TabIndex = 0;
            this.pbAbsence.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnOK, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 718);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(484, 43);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Location = new System.Drawing.Point(250, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Nápověda k ikonám v záhlaví";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.Location = new System.Drawing.Point(157, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 37);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Zavřít";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // frmAbsence
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(44)))), ((int)(((byte)(47)))));
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmAbsence";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Absence";
            this.Load += new System.EventHandler(this.frmAbsence_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAbsence_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbsence)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPredmety;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnMesice;
        private System.Windows.Forms.Button btnDny;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pbAbsence;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOK;
    }
}