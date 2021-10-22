using System.Runtime.CompilerServices;

namespace DFBV3
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.lblSwitch = new System.Windows.Forms.Label();
            this.lblSchool = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlbtnRestart = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.pnlbtnLogout = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlbtnKonec = new System.Windows.Forms.Panel();
            this.btnKonec = new System.Windows.Forms.Button();
            this.pnlbtnAbsence = new System.Windows.Forms.Panel();
            this.btnAbsence = new System.Windows.Forms.Button();
            this.pnlbtnZvyraznit = new System.Windows.Forms.Panel();
            this.btnZvyraznit = new System.Windows.Forms.Button();
            this.scVert = new System.Windows.Forms.SplitContainer();
            this.scHori = new System.Windows.Forms.SplitContainer();
            this.gbRozvrh = new System.Windows.Forms.GroupBox();
            this.pbRozvrh = new System.Windows.Forms.PictureBox();
            this.pbRozvrhInteraktivni = new System.Windows.Forms.PictureBox();
            this.tlpRozvrhControl = new System.Windows.Forms.TableLayoutPanel();
            this.btnCurrentWeek = new System.Windows.Forms.Button();
            this.btnNextWeek = new System.Windows.Forms.Button();
            this.btnPrevWeek = new System.Windows.Forms.Button();
            this.gbPrumer = new System.Windows.Forms.GroupBox();
            this.pbPrumer = new System.Windows.Forms.PictureBox();
            this.gbHodina = new System.Windows.Forms.GroupBox();
            this.gbZnamky = new System.Windows.Forms.GroupBox();
            this.panZnamky = new System.Windows.Forms.Panel();
            this.pbZnamky = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ttRozvrh = new System.Windows.Forms.ToolTip(this.components);
            this.gbInfo.SuspendLayout();
            this.pnlbtnRestart.SuspendLayout();
            this.pnlbtnLogout.SuspendLayout();
            this.pnlbtnKonec.SuspendLayout();
            this.pnlbtnAbsence.SuspendLayout();
            this.pnlbtnZvyraznit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scVert)).BeginInit();
            this.scVert.Panel1.SuspendLayout();
            this.scVert.Panel2.SuspendLayout();
            this.scVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scHori)).BeginInit();
            this.scHori.Panel1.SuspendLayout();
            this.scHori.Panel2.SuspendLayout();
            this.scHori.SuspendLayout();
            this.gbRozvrh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRozvrh)).BeginInit();
            this.pbRozvrh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRozvrhInteraktivni)).BeginInit();
            this.tlpRozvrhControl.SuspendLayout();
            this.gbPrumer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrumer)).BeginInit();
            this.gbZnamky.SuspendLayout();
            this.panZnamky.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbZnamky)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.gbInfo.Controls.Add(this.lblSwitch);
            this.gbInfo.Controls.Add(this.lblSchool);
            this.gbInfo.Controls.Add(this.lblUser);
            this.gbInfo.Controls.Add(this.pnlbtnRestart);
            this.gbInfo.Controls.Add(this.pnlbtnLogout);
            this.gbInfo.Controls.Add(this.pnlbtnKonec);
            this.gbInfo.Controls.Add(this.pnlbtnAbsence);
            this.gbInfo.Controls.Add(this.pnlbtnZvyraznit);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbInfo.Location = new System.Drawing.Point(5, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Padding = new System.Windows.Forms.Padding(7, 0, 7, 7);
            this.gbInfo.Size = new System.Drawing.Size(789, 67);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Enter += new System.EventHandler(this.gbInfo_Enter);
            // 
            // lblSwitch
            // 
            this.lblSwitch.BackColor = System.Drawing.Color.Transparent;
            this.lblSwitch.Location = new System.Drawing.Point(455, 33);
            this.lblSwitch.Name = "lblSwitch";
            this.lblSwitch.Size = new System.Drawing.Size(24, 31);
            this.lblSwitch.TabIndex = 6;
            this.lblSwitch.Click += new System.EventHandler(this.lblSwitch_Click);
            // 
            // lblSchool
            // 
            this.lblSchool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSchool.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSchool.Location = new System.Drawing.Point(207, 36);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(275, 24);
            this.lblSchool.TabIndex = 5;
            this.lblSchool.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUser.Location = new System.Drawing.Point(207, 16);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(275, 20);
            this.lblUser.TabIndex = 4;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblUser.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblUser_MouseDoubleClick);
            // 
            // pnlbtnRestart
            // 
            this.pnlbtnRestart.Controls.Add(this.btnRestart);
            this.pnlbtnRestart.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlbtnRestart.Location = new System.Drawing.Point(482, 16);
            this.pnlbtnRestart.Margin = new System.Windows.Forms.Padding(0);
            this.pnlbtnRestart.Name = "pnlbtnRestart";
            this.pnlbtnRestart.Padding = new System.Windows.Forms.Padding(3);
            this.pnlbtnRestart.Size = new System.Drawing.Size(100, 44);
            this.pnlbtnRestart.TabIndex = 3;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnRestart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Location = new System.Drawing.Point(3, 3);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(94, 38);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Restartovat";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // pnlbtnLogout
            // 
            this.pnlbtnLogout.Controls.Add(this.btnLogout);
            this.pnlbtnLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlbtnLogout.Location = new System.Drawing.Point(582, 16);
            this.pnlbtnLogout.Name = "pnlbtnLogout";
            this.pnlbtnLogout.Padding = new System.Windows.Forms.Padding(3);
            this.pnlbtnLogout.Size = new System.Drawing.Size(100, 44);
            this.pnlbtnLogout.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(3, 3);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(94, 38);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Odhlásit se";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlbtnKonec
            // 
            this.pnlbtnKonec.Controls.Add(this.btnKonec);
            this.pnlbtnKonec.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlbtnKonec.Location = new System.Drawing.Point(682, 16);
            this.pnlbtnKonec.Name = "pnlbtnKonec";
            this.pnlbtnKonec.Padding = new System.Windows.Forms.Padding(3);
            this.pnlbtnKonec.Size = new System.Drawing.Size(100, 44);
            this.pnlbtnKonec.TabIndex = 1;
            // 
            // btnKonec
            // 
            this.btnKonec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnKonec.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKonec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKonec.FlatAppearance.BorderSize = 0;
            this.btnKonec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKonec.Location = new System.Drawing.Point(3, 3);
            this.btnKonec.Margin = new System.Windows.Forms.Padding(0);
            this.btnKonec.Name = "btnKonec";
            this.btnKonec.Size = new System.Drawing.Size(94, 38);
            this.btnKonec.TabIndex = 0;
            this.btnKonec.Text = "Ukončit";
            this.toolTip1.SetToolTip(this.btnKonec, "Ukončí aplikaci (Esc)");
            this.btnKonec.UseVisualStyleBackColor = false;
            this.btnKonec.Click += new System.EventHandler(this.btnKonec_Click);
            // 
            // pnlbtnAbsence
            // 
            this.pnlbtnAbsence.Controls.Add(this.btnAbsence);
            this.pnlbtnAbsence.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlbtnAbsence.Location = new System.Drawing.Point(107, 16);
            this.pnlbtnAbsence.Margin = new System.Windows.Forms.Padding(0);
            this.pnlbtnAbsence.Name = "pnlbtnAbsence";
            this.pnlbtnAbsence.Padding = new System.Windows.Forms.Padding(3);
            this.pnlbtnAbsence.Size = new System.Drawing.Size(100, 44);
            this.pnlbtnAbsence.TabIndex = 8;
            // 
            // btnAbsence
            // 
            this.btnAbsence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnAbsence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAbsence.FlatAppearance.BorderSize = 0;
            this.btnAbsence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbsence.Location = new System.Drawing.Point(3, 3);
            this.btnAbsence.Name = "btnAbsence";
            this.btnAbsence.Size = new System.Drawing.Size(94, 38);
            this.btnAbsence.TabIndex = 0;
            this.btnAbsence.Text = "Absence (F3)";
            this.btnAbsence.UseVisualStyleBackColor = false;
            this.btnAbsence.Click += new System.EventHandler(this.btnAbsence_Click);
            // 
            // pnlbtnZvyraznit
            // 
            this.pnlbtnZvyraznit.Controls.Add(this.btnZvyraznit);
            this.pnlbtnZvyraznit.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlbtnZvyraznit.Location = new System.Drawing.Point(7, 16);
            this.pnlbtnZvyraznit.Margin = new System.Windows.Forms.Padding(0);
            this.pnlbtnZvyraznit.Name = "pnlbtnZvyraznit";
            this.pnlbtnZvyraznit.Padding = new System.Windows.Forms.Padding(3);
            this.pnlbtnZvyraznit.Size = new System.Drawing.Size(100, 44);
            this.pnlbtnZvyraznit.TabIndex = 7;
            // 
            // btnZvyraznit
            // 
            this.btnZvyraznit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnZvyraznit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZvyraznit.FlatAppearance.BorderSize = 0;
            this.btnZvyraznit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZvyraznit.Location = new System.Drawing.Point(3, 3);
            this.btnZvyraznit.Name = "btnZvyraznit";
            this.btnZvyraznit.Size = new System.Drawing.Size(94, 38);
            this.btnZvyraznit.TabIndex = 0;
            this.btnZvyraznit.Text = "Zvýraznit v rozvrhu (F2)";
            this.btnZvyraznit.UseVisualStyleBackColor = false;
            this.btnZvyraznit.Click += new System.EventHandler(this.btnZvyraznit_Click);
            // 
            // scVert
            // 
            this.scVert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scVert.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scVert.Location = new System.Drawing.Point(5, 67);
            this.scVert.Name = "scVert";
            // 
            // scVert.Panel1
            // 
            this.scVert.Panel1.Controls.Add(this.scHori);
            this.scVert.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            // 
            // scVert.Panel2
            // 
            this.scVert.Panel2.Controls.Add(this.gbZnamky);
            this.scVert.Panel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.scVert.Size = new System.Drawing.Size(789, 694);
            this.scVert.SplitterDistance = 389;
            this.scVert.TabIndex = 1;
            this.scVert.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scVert_SplitterMoved);
            // 
            // scHori
            // 
            this.scHori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scHori.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scHori.Location = new System.Drawing.Point(0, 0);
            this.scHori.Name = "scHori";
            this.scHori.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scHori.Panel1
            // 
            this.scHori.Panel1.Controls.Add(this.gbRozvrh);
            // 
            // scHori.Panel2
            // 
            this.scHori.Panel2.Controls.Add(this.gbPrumer);
            this.scHori.Panel2.Controls.Add(this.gbHodina);
            this.scHori.Size = new System.Drawing.Size(386, 694);
            this.scHori.SplitterDistance = 417;
            this.scHori.TabIndex = 0;
            this.scHori.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scHori_SplitterMoved);
            // 
            // gbRozvrh
            // 
            this.gbRozvrh.Controls.Add(this.pbRozvrh);
            this.gbRozvrh.Controls.Add(this.tlpRozvrhControl);
            this.gbRozvrh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRozvrh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbRozvrh.Location = new System.Drawing.Point(0, 0);
            this.gbRozvrh.Name = "gbRozvrh";
            this.gbRozvrh.Padding = new System.Windows.Forms.Padding(7, 0, 7, 7);
            this.gbRozvrh.Size = new System.Drawing.Size(386, 417);
            this.gbRozvrh.TabIndex = 0;
            this.gbRozvrh.TabStop = false;
            this.gbRozvrh.Text = "Rozvrh";
            // 
            // pbRozvrh
            // 
            this.pbRozvrh.BackColor = System.Drawing.Color.Transparent;
            this.pbRozvrh.Controls.Add(this.pbRozvrhInteraktivni);
            this.pbRozvrh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbRozvrh.Location = new System.Drawing.Point(7, 16);
            this.pbRozvrh.Name = "pbRozvrh";
            this.pbRozvrh.Size = new System.Drawing.Size(341, 394);
            this.pbRozvrh.TabIndex = 1;
            this.pbRozvrh.TabStop = false;
            this.pbRozvrh.Click += new System.EventHandler(this.pbRozvrh_Click);
            // 
            // pbRozvrhInteraktivni
            // 
            this.pbRozvrhInteraktivni.BackColor = System.Drawing.Color.Transparent;
            this.pbRozvrhInteraktivni.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbRozvrhInteraktivni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbRozvrhInteraktivni.Location = new System.Drawing.Point(0, 0);
            this.pbRozvrhInteraktivni.Name = "pbRozvrhInteraktivni";
            this.pbRozvrhInteraktivni.Size = new System.Drawing.Size(341, 394);
            this.pbRozvrhInteraktivni.TabIndex = 2;
            this.pbRozvrhInteraktivni.TabStop = false;
            this.pbRozvrhInteraktivni.Click += new System.EventHandler(this.pbRozvrhInteraktivni_Click);
            this.pbRozvrhInteraktivni.MouseLeave += new System.EventHandler(this.pbRozvrhInteraktivni_MouseLeave);
            this.pbRozvrhInteraktivni.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbRozvrh_MouseMove);
            // 
            // tlpRozvrhControl
            // 
            this.tlpRozvrhControl.ColumnCount = 1;
            this.tlpRozvrhControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRozvrhControl.Controls.Add(this.btnCurrentWeek, 0, 1);
            this.tlpRozvrhControl.Controls.Add(this.btnNextWeek, 0, 2);
            this.tlpRozvrhControl.Controls.Add(this.btnPrevWeek, 0, 0);
            this.tlpRozvrhControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlpRozvrhControl.Location = new System.Drawing.Point(348, 16);
            this.tlpRozvrhControl.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRozvrhControl.Name = "tlpRozvrhControl";
            this.tlpRozvrhControl.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.tlpRozvrhControl.RowCount = 3;
            this.tlpRozvrhControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpRozvrhControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpRozvrhControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpRozvrhControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRozvrhControl.Size = new System.Drawing.Size(31, 394);
            this.tlpRozvrhControl.TabIndex = 0;
            // 
            // btnCurrentWeek
            // 
            this.btnCurrentWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnCurrentWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCurrentWeek.FlatAppearance.BorderSize = 0;
            this.btnCurrentWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrentWeek.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCurrentWeek.Location = new System.Drawing.Point(6, 134);
            this.btnCurrentWeek.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnCurrentWeek.Name = "btnCurrentWeek";
            this.btnCurrentWeek.Size = new System.Drawing.Size(25, 125);
            this.btnCurrentWeek.TabIndex = 2;
            this.btnCurrentWeek.Text = "⌂";
            this.toolTip1.SetToolTip(this.btnCurrentWeek, "Tento týden");
            this.btnCurrentWeek.UseVisualStyleBackColor = false;
            this.btnCurrentWeek.Click += new System.EventHandler(this.btnCurrentWeek_Click);
            // 
            // btnNextWeek
            // 
            this.btnNextWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnNextWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNextWeek.FlatAppearance.BorderSize = 0;
            this.btnNextWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextWeek.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNextWeek.Location = new System.Drawing.Point(6, 265);
            this.btnNextWeek.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnNextWeek.Name = "btnNextWeek";
            this.btnNextWeek.Size = new System.Drawing.Size(25, 129);
            this.btnNextWeek.TabIndex = 2;
            this.btnNextWeek.Text = "↓";
            this.toolTip1.SetToolTip(this.btnNextWeek, "Další týden");
            this.btnNextWeek.UseVisualStyleBackColor = false;
            this.btnNextWeek.Click += new System.EventHandler(this.btnNextWeek_Click);
            // 
            // btnPrevWeek
            // 
            this.btnPrevWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnPrevWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrevWeek.FlatAppearance.BorderSize = 0;
            this.btnPrevWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevWeek.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrevWeek.Location = new System.Drawing.Point(6, 0);
            this.btnPrevWeek.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnPrevWeek.Name = "btnPrevWeek";
            this.btnPrevWeek.Size = new System.Drawing.Size(25, 128);
            this.btnPrevWeek.TabIndex = 1;
            this.btnPrevWeek.Text = "↑";
            this.toolTip1.SetToolTip(this.btnPrevWeek, "Předchozí týden");
            this.btnPrevWeek.UseVisualStyleBackColor = false;
            this.btnPrevWeek.Click += new System.EventHandler(this.btnPrevWeek_Click);
            // 
            // gbPrumer
            // 
            this.gbPrumer.Controls.Add(this.pbPrumer);
            this.gbPrumer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPrumer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbPrumer.Location = new System.Drawing.Point(0, 131);
            this.gbPrumer.Name = "gbPrumer";
            this.gbPrumer.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.gbPrumer.Size = new System.Drawing.Size(386, 142);
            this.gbPrumer.TabIndex = 1;
            this.gbPrumer.TabStop = false;
            this.gbPrumer.Text = "Průměr";
            // 
            // pbPrumer
            // 
            this.pbPrumer.BackColor = System.Drawing.Color.Transparent;
            this.pbPrumer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPrumer.Location = new System.Drawing.Point(3, 19);
            this.pbPrumer.Name = "pbPrumer";
            this.pbPrumer.Size = new System.Drawing.Size(380, 117);
            this.pbPrumer.TabIndex = 0;
            this.pbPrumer.TabStop = false;
            // 
            // gbHodina
            // 
            this.gbHodina.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHodina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbHodina.Location = new System.Drawing.Point(0, 0);
            this.gbHodina.Name = "gbHodina";
            this.gbHodina.Size = new System.Drawing.Size(386, 131);
            this.gbHodina.TabIndex = 0;
            this.gbHodina.TabStop = false;
            // 
            // gbZnamky
            // 
            this.gbZnamky.Controls.Add(this.panZnamky);
            this.gbZnamky.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbZnamky.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbZnamky.Location = new System.Drawing.Point(3, 0);
            this.gbZnamky.Name = "gbZnamky";
            this.gbZnamky.Size = new System.Drawing.Size(393, 694);
            this.gbZnamky.TabIndex = 0;
            this.gbZnamky.TabStop = false;
            this.gbZnamky.Text = "Známky";
            // 
            // panZnamky
            // 
            this.panZnamky.AutoScroll = true;
            this.panZnamky.Controls.Add(this.pbZnamky);
            this.panZnamky.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panZnamky.Location = new System.Drawing.Point(3, 19);
            this.panZnamky.Name = "panZnamky";
            this.panZnamky.Size = new System.Drawing.Size(387, 672);
            this.panZnamky.TabIndex = 0;
            // 
            // pbZnamky
            // 
            this.pbZnamky.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbZnamky.Location = new System.Drawing.Point(0, 0);
            this.pbZnamky.Name = "pbZnamky";
            this.pbZnamky.Size = new System.Drawing.Size(370, 982);
            this.pbZnamky.TabIndex = 0;
            this.pbZnamky.TabStop = false;
            this.pbZnamky.Click += new System.EventHandler(this.pbZnamky_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // ttRozvrh
            // 
            this.ttRozvrh.AutomaticDelay = 10;
            this.ttRozvrh.AutoPopDelay = 0;
            this.ttRozvrh.InitialDelay = 10;
            this.ttRozvrh.IsBalloon = true;
            this.ttRozvrh.ReshowDelay = 2;
            this.ttRozvrh.ShowAlways = true;
            this.ttRozvrh.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttRozvrh.UseAnimation = false;
            this.ttRozvrh.UseFading = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(44)))), ((int)(((byte)(47)))));
            this.CancelButton = this.btnKonec;
            this.ClientSize = new System.Drawing.Size(799, 761);
            this.Controls.Add(this.scVert);
            this.Controls.Add(this.gbInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.gbInfo.ResumeLayout(false);
            this.pnlbtnRestart.ResumeLayout(false);
            this.pnlbtnLogout.ResumeLayout(false);
            this.pnlbtnKonec.ResumeLayout(false);
            this.pnlbtnAbsence.ResumeLayout(false);
            this.pnlbtnZvyraznit.ResumeLayout(false);
            this.scVert.Panel1.ResumeLayout(false);
            this.scVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scVert)).EndInit();
            this.scVert.ResumeLayout(false);
            this.scHori.Panel1.ResumeLayout(false);
            this.scHori.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scHori)).EndInit();
            this.scHori.ResumeLayout(false);
            this.gbRozvrh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRozvrh)).EndInit();
            this.pbRozvrh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRozvrhInteraktivni)).EndInit();
            this.tlpRozvrhControl.ResumeLayout(false);
            this.gbPrumer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrumer)).EndInit();
            this.gbZnamky.ResumeLayout(false);
            this.panZnamky.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbZnamky)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //neco
        

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Button btnKonec;
        private System.Windows.Forms.Panel pnlbtnKonec;
        private System.Windows.Forms.Panel pnlbtnLogout;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlbtnRestart;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.SplitContainer scVert;
        private System.Windows.Forms.SplitContainer scHori;
        private System.Windows.Forms.GroupBox gbZnamky;
        private System.Windows.Forms.GroupBox gbRozvrh;
        private System.Windows.Forms.TableLayoutPanel tlpRozvrhControl;
        private System.Windows.Forms.Button btnCurrentWeek;
        private System.Windows.Forms.Button btnNextWeek;
        private System.Windows.Forms.Button btnPrevWeek;
        private System.Windows.Forms.GroupBox gbHodina;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox gbPrumer;
        private System.Windows.Forms.PictureBox pbRozvrh;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.Panel panZnamky;
        private System.Windows.Forms.PictureBox pbZnamky;
        private System.Windows.Forms.ToolTip ttRozvrh;
        private System.Windows.Forms.PictureBox pbRozvrhInteraktivni;
        private System.Windows.Forms.PictureBox pbPrumer;
        private System.Windows.Forms.Label lblSwitch;
        private System.Windows.Forms.Panel pnlbtnAbsence;
        private System.Windows.Forms.Button btnAbsence;
        private System.Windows.Forms.Panel pnlbtnZvyraznit;
        private System.Windows.Forms.Button btnZvyraznit;
    }
}

