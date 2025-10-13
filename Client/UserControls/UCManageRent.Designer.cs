using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Client.UserControls
{
    partial class UCManageRent
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvIznajmljivanja = new DataGridView();
            btnShowIznajmljivanje = new Button();
            btnEditIznajmljivanje = new Button();
            btnSearchIznajmljivanje = new Button();
            lblOprema = new Label();
            lblOsoba = new Label();
            lblZaposleni = new Label();
            cbZaposleni = new ComboBox();
            cbOsoba = new ComboBox();
            cbOprema = new ComboBox();
            dtpOd = new DateTimePicker();
            lblOd = new Label();
            lblUkupanIznos = new Label();
            txtMin = new TextBox();
            lblI = new Label();
            txtMax = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvIznajmljivanja).BeginInit();
            SuspendLayout();
            // 
            // dgvIznajmljivanja
            // 
            dgvIznajmljivanja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIznajmljivanja.Location = new Point(3, 212);
            dgvIznajmljivanja.Name = "dgvIznajmljivanja";
            dgvIznajmljivanja.Size = new Size(637, 183);
            dgvIznajmljivanja.TabIndex = 0;
            // 
            // btnShowIznajmljivanje
            // 
            btnShowIznajmljivanje.Location = new Point(462, 171);
            btnShowIznajmljivanje.Name = "btnShowIznajmljivanje";
            btnShowIznajmljivanje.Size = new Size(86, 36);
            btnShowIznajmljivanje.TabIndex = 24;
            btnShowIznajmljivanje.Text = "Прикажи";
            btnShowIznajmljivanje.UseVisualStyleBackColor = true;
            // 
            // btnEditIznajmljivanje
            // 
            btnEditIznajmljivanje.Location = new Point(554, 171);
            btnEditIznajmljivanje.Name = "btnEditIznajmljivanje";
            btnEditIznajmljivanje.Size = new Size(86, 36);
            btnEditIznajmljivanje.TabIndex = 22;
            btnEditIznajmljivanje.Text = "Промени";
            btnEditIznajmljivanje.UseVisualStyleBackColor = true;
            // 
            // btnSearchIznajmljivanje
            // 
            btnSearchIznajmljivanje.Location = new Point(346, 74);
            btnSearchIznajmljivanje.Name = "btnSearchIznajmljivanje";
            btnSearchIznajmljivanje.Size = new Size(86, 36);
            btnSearchIznajmljivanje.TabIndex = 32;
            btnSearchIznajmljivanje.Text = "Претражи";
            btnSearchIznajmljivanje.UseVisualStyleBackColor = true;
            // 
            // lblOprema
            // 
            lblOprema.AutoSize = true;
            lblOprema.Location = new Point(12, 95);
            lblOprema.Name = "lblOprema";
            lblOprema.Size = new Size(54, 15);
            lblOprema.TabIndex = 27;
            lblOprema.Text = "Опрема:";
            // 
            // lblOsoba
            // 
            lblOsoba.AutoSize = true;
            lblOsoba.Location = new Point(12, 57);
            lblOsoba.Name = "lblOsoba";
            lblOsoba.Size = new Size(45, 15);
            lblOsoba.TabIndex = 26;
            lblOsoba.Text = "Особа:";
            // 
            // lblZaposleni
            // 
            lblZaposleni.AutoSize = true;
            lblZaposleni.Location = new Point(12, 19);
            lblZaposleni.Name = "lblZaposleni";
            lblZaposleni.Size = new Size(70, 15);
            lblZaposleni.TabIndex = 25;
            lblZaposleni.Text = "Запослени:";
            // 
            // cbZaposleni
            // 
            cbZaposleni.FormattingEnabled = true;
            cbZaposleni.Location = new Point(88, 16);
            cbZaposleni.Name = "cbZaposleni";
            cbZaposleni.Size = new Size(200, 23);
            cbZaposleni.TabIndex = 33;
            // 
            // cbOsoba
            // 
            cbOsoba.FormattingEnabled = true;
            cbOsoba.Location = new Point(88, 54);
            cbOsoba.Name = "cbOsoba";
            cbOsoba.Size = new Size(200, 23);
            cbOsoba.TabIndex = 34;
            // 
            // cbOprema
            // 
            cbOprema.FormattingEnabled = true;
            cbOprema.Location = new Point(88, 92);
            cbOprema.Name = "cbOprema";
            cbOprema.Size = new Size(200, 23);
            cbOprema.TabIndex = 35;
            // 
            // dtpOd
            // 
            dtpOd.Location = new Point(88, 130);
            dtpOd.Name = "dtpOd";
            dtpOd.Size = new Size(200, 23);
            dtpOd.TabIndex = 36;
            // 
            // lblOd
            // 
            lblOd.AutoSize = true;
            lblOd.Location = new Point(12, 133);
            lblOd.Name = "lblOd";
            lblOd.Size = new Size(25, 15);
            lblOd.TabIndex = 37;
            lblOd.Text = "Од:";
            // 
            // lblUkupanIznos
            // 
            lblUkupanIznos.AutoSize = true;
            lblUkupanIznos.Location = new Point(12, 171);
            lblUkupanIznos.Name = "lblUkupanIznos";
            lblUkupanIznos.Size = new Size(124, 15);
            lblUkupanIznos.TabIndex = 38;
            lblUkupanIznos.Text = "Укупан износ између";
            // 
            // txtMin
            // 
            txtMin.Location = new Point(142, 168);
            txtMin.Name = "txtMin";
            txtMin.Size = new Size(58, 23);
            txtMin.TabIndex = 39;
            // 
            // lblI
            // 
            lblI.AutoSize = true;
            lblI.Location = new Point(206, 171);
            lblI.Name = "lblI";
            lblI.Size = new Size(14, 15);
            lblI.TabIndex = 40;
            lblI.Text = "и";
            // 
            // txtMax
            // 
            txtMax.Location = new Point(230, 168);
            txtMax.Name = "txtMax";
            txtMax.Size = new Size(58, 23);
            txtMax.TabIndex = 42;
            // 
            // UCManageRent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtMax);
            Controls.Add(lblI);
            Controls.Add(txtMin);
            Controls.Add(lblUkupanIznos);
            Controls.Add(lblOd);
            Controls.Add(dtpOd);
            Controls.Add(cbOprema);
            Controls.Add(cbOsoba);
            Controls.Add(cbZaposleni);
            Controls.Add(btnSearchIznajmljivanje);
            Controls.Add(lblOprema);
            Controls.Add(lblOsoba);
            Controls.Add(lblZaposleni);
            Controls.Add(btnShowIznajmljivanje);
            Controls.Add(btnEditIznajmljivanje);
            Controls.Add(dgvIznajmljivanja);
            Name = "UCManageRent";
            Size = new Size(643, 398);
            ((System.ComponentModel.ISupportInitialize)dgvIznajmljivanja).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvIznajmljivanja;
        private Button btnShowIznajmljivanje;
        private Button btnEditIznajmljivanje;
        private Button btnSearchIznajmljivanje;
        private Label lblOprema;
        private Label lblOsoba;
        private Label lblZaposleni;
        private ComboBox cbZaposleni;
        private ComboBox cbOsoba;
        private ComboBox cbOprema;
        private DateTimePicker dtpOd;
        private Label lblOd;
        private Label lblUkupanIznos;
        private Label lblI;
        private TextBox txtMin;
        private TextBox txtMax;

        public Button BtnSearchIznajmljivanje { get => btnSearchIznajmljivanje; set => btnSearchIznajmljivanje = value; }
        public Button BtnEditIznajmljivanje { get => btnEditIznajmljivanje; set => btnEditIznajmljivanje = value; }
        public ComboBox CbZaposleni { get => cbZaposleni; set => cbZaposleni = value; }
        public ComboBox CbOsoba { get => cbOsoba; set => cbOsoba = value; }
        public ComboBox CbOprema { get => cbOprema; set => cbOprema = value; }
        public Label LblOprema { get => lblOprema; set => lblOprema = value; }
        public Label LblOsoba { get => lblOsoba; set => lblOsoba = value; }
        public Label LblZaposleni { get => lblZaposleni; set => lblZaposleni = value; }
        public Label LblOd { get => lblOd; set => lblOd = value; }
        public Label LblUkupanIznos { get => lblUkupanIznos; set => lblUkupanIznos = value; }
        public Label LblI { get => lblI; set => lblI = value; }
        public DataGridView DgvIznajmljivanja { get => dgvIznajmljivanja; set => dgvIznajmljivanja = value; }
        public Button BtnShowIznajmljivanje { get => btnShowIznajmljivanje; set => btnShowIznajmljivanje = value; }
        public TextBox TxtMin { get => txtMin; set => txtMin = value; }
        public TextBox TxtMax { get => txtMax; set => txtMax = value; }
        public DateTimePicker DtpOd { get => dtpOd; set => dtpOd = value; }
    }
}