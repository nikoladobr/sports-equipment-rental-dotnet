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
            btnSearchIznajmljivanje = new Button();
            lblOprema = new Label();
            lblOsoba = new Label();
            lblZaposleni = new Label();
            cbZaposleni = new ComboBox();
            cbOsoba = new ComboBox();
            cbOprema = new ComboBox();
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
            dgvIznajmljivanja.Location = new Point(49, 287);
            dgvIznajmljivanja.Margin = new Padding(3, 4, 3, 4);
            dgvIznajmljivanja.Name = "dgvIznajmljivanja";
            dgvIznajmljivanja.RowHeadersWidth = 51;
            dgvIznajmljivanja.Size = new Size(639, 244);
            dgvIznajmljivanja.TabIndex = 0;
            // 
            // btnShowIznajmljivanje
            // 
            btnShowIznajmljivanje.Location = new Point(590, 231);
            btnShowIznajmljivanje.Margin = new Padding(3, 4, 3, 4);
            btnShowIznajmljivanje.Name = "btnShowIznajmljivanje";
            btnShowIznajmljivanje.Size = new Size(98, 48);
            btnShowIznajmljivanje.TabIndex = 24;
            btnShowIznajmljivanje.Text = "Прикажи";
            btnShowIznajmljivanje.UseVisualStyleBackColor = true;
            // 
            // btnSearchIznajmljivanje
            // 
            btnSearchIznajmljivanje.Location = new Point(395, 99);
            btnSearchIznajmljivanje.Margin = new Padding(3, 4, 3, 4);
            btnSearchIznajmljivanje.Name = "btnSearchIznajmljivanje";
            btnSearchIznajmljivanje.Size = new Size(98, 48);
            btnSearchIznajmljivanje.TabIndex = 32;
            btnSearchIznajmljivanje.Text = "Претражи";
            btnSearchIznajmljivanje.UseVisualStyleBackColor = true;
            // 
            // lblOprema
            // 
            lblOprema.AutoSize = true;
            lblOprema.Location = new Point(14, 127);
            lblOprema.Name = "lblOprema";
            lblOprema.Size = new Size(68, 20);
            lblOprema.TabIndex = 27;
            lblOprema.Text = "Опрема:";
            // 
            // lblOsoba
            // 
            lblOsoba.AutoSize = true;
            lblOsoba.Location = new Point(14, 76);
            lblOsoba.Name = "lblOsoba";
            lblOsoba.Size = new Size(56, 20);
            lblOsoba.TabIndex = 26;
            lblOsoba.Text = "Особа:";
            // 
            // lblZaposleni
            // 
            lblZaposleni.AutoSize = true;
            lblZaposleni.Location = new Point(14, 25);
            lblZaposleni.Name = "lblZaposleni";
            lblZaposleni.Size = new Size(87, 20);
            lblZaposleni.TabIndex = 25;
            lblZaposleni.Text = "Запослени:";
            // 
            // cbZaposleni
            // 
            cbZaposleni.FormattingEnabled = true;
            cbZaposleni.Location = new Point(101, 21);
            cbZaposleni.Margin = new Padding(3, 4, 3, 4);
            cbZaposleni.Name = "cbZaposleni";
            cbZaposleni.Size = new Size(228, 28);
            cbZaposleni.TabIndex = 33;
            // 
            // cbOsoba
            // 
            cbOsoba.FormattingEnabled = true;
            cbOsoba.Location = new Point(101, 72);
            cbOsoba.Margin = new Padding(3, 4, 3, 4);
            cbOsoba.Name = "cbOsoba";
            cbOsoba.Size = new Size(228, 28);
            cbOsoba.TabIndex = 34;
            // 
            // cbOprema
            // 
            cbOprema.FormattingEnabled = true;
            cbOprema.Location = new Point(101, 123);
            cbOprema.Margin = new Padding(3, 4, 3, 4);
            cbOprema.Name = "cbOprema";
            cbOprema.Size = new Size(228, 28);
            cbOprema.TabIndex = 35;
            // 
            // lblUkupanIznos
            // 
            lblUkupanIznos.AutoSize = true;
            lblUkupanIznos.Location = new Point(14, 175);
            lblUkupanIznos.Name = "lblUkupanIznos";
            lblUkupanIznos.Size = new Size(158, 20);
            lblUkupanIznos.TabIndex = 38;
            lblUkupanIznos.Text = "Укупан износ између";
            // 
            // txtMin
            // 
            txtMin.Location = new Point(162, 171);
            txtMin.Margin = new Padding(3, 4, 3, 4);
            txtMin.Name = "txtMin";
            txtMin.Size = new Size(66, 27);
            txtMin.TabIndex = 39;
            // 
            // lblI
            // 
            lblI.AutoSize = true;
            lblI.Location = new Point(235, 175);
            lblI.Name = "lblI";
            lblI.Size = new Size(18, 20);
            lblI.TabIndex = 40;
            lblI.Text = "и";
            // 
            // txtMax
            // 
            txtMax.Location = new Point(263, 171);
            txtMax.Margin = new Padding(3, 4, 3, 4);
            txtMax.Name = "txtMax";
            txtMax.Size = new Size(66, 27);
            txtMax.TabIndex = 42;
            // 
            // UCManageRent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtMax);
            Controls.Add(lblI);
            Controls.Add(txtMin);
            Controls.Add(lblUkupanIznos);
            Controls.Add(cbOprema);
            Controls.Add(cbOsoba);
            Controls.Add(cbZaposleni);
            Controls.Add(btnSearchIznajmljivanje);
            Controls.Add(lblOprema);
            Controls.Add(lblOsoba);
            Controls.Add(lblZaposleni);
            Controls.Add(btnShowIznajmljivanje);
            Controls.Add(dgvIznajmljivanja);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UCManageRent";
            Size = new Size(735, 531);
            ((System.ComponentModel.ISupportInitialize)dgvIznajmljivanja).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvIznajmljivanja;
        private Button btnShowIznajmljivanje;
        private Button btnSearchIznajmljivanje;
        private Label lblOprema;
        private Label lblOsoba;
        private Label lblZaposleni;
        private ComboBox cbZaposleni;
        private ComboBox cbOsoba;
        private ComboBox cbOprema;
        private Label lblUkupanIznos;
        private Label lblI;
        private TextBox txtMin;
        private TextBox txtMax;

        public Button BtnSearchIznajmljivanje { get => btnSearchIznajmljivanje; set => btnSearchIznajmljivanje = value; }
        public ComboBox CbZaposleni { get => cbZaposleni; set => cbZaposleni = value; }
        public ComboBox CbOsoba { get => cbOsoba; set => cbOsoba = value; }
        public ComboBox CbOprema { get => cbOprema; set => cbOprema = value; }
        public Label LblOprema { get => lblOprema; set => lblOprema = value; }
        public Label LblOsoba { get => lblOsoba; set => lblOsoba = value; }
        public Label LblZaposleni { get => lblZaposleni; set => lblZaposleni = value; }
        public Label LblUkupanIznos { get => lblUkupanIznos; set => lblUkupanIznos = value; }
        public Label LblI { get => lblI; set => lblI = value; }
        public DataGridView DgvIznajmljivanja { get => dgvIznajmljivanja; set => dgvIznajmljivanja = value; }
        public Button BtnShowIznajmljivanje { get => btnShowIznajmljivanje; set => btnShowIznajmljivanje = value; }
        public TextBox TxtMin { get => txtMin; set => txtMin = value; }
        public TextBox TxtMax { get => txtMax; set => txtMax = value; }
    }
}