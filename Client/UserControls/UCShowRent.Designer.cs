namespace Client.UserControls
{
    partial class UCShowRent
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
            txtUkupanIznos = new TextBox();
            lblUkupanIznos = new Label();
            dtpSince = new DateTimePicker();
            cbOsoba = new ComboBox();
            lblOsoba = new Label();
            lblOd = new Label();
            cbZaposleni = new ComboBox();
            lblZaposleni = new Label();
            dgvStavkeIznajmljivanja = new DataGridView();
            cbOprema = new ComboBox();
            dtpTo = new DateTimePicker();
            txtTrajanje = new TextBox();
            txtCena = new TextBox();
            txtKolicina = new TextBox();
            txtIznos = new TextBox();
            lblOprema = new Label();
            lblIznos = new Label();
            lblTrajanje = new Label();
            lblDo = new Label();
            lblCena = new Label();
            lblKolicina = new Label();
            btnPrikazi = new Button();
            btnAddRentalItem = new Button();
            btnObrisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStavkeIznajmljivanja).BeginInit();
            SuspendLayout();
            // 
            // txtUkupanIznos
            // 
            txtUkupanIznos.Enabled = false;
            txtUkupanIznos.Location = new Point(108, 64);
            txtUkupanIznos.Name = "txtUkupanIznos";
            txtUkupanIznos.Size = new Size(185, 23);
            txtUkupanIznos.TabIndex = 47;
            // 
            // lblUkupanIznos
            // 
            lblUkupanIznos.AutoSize = true;
            lblUkupanIznos.Location = new Point(3, 67);
            lblUkupanIznos.Name = "lblUkupanIznos";
            lblUkupanIznos.Size = new Size(84, 15);
            lblUkupanIznos.TabIndex = 46;
            lblUkupanIznos.Text = "Укупан износ:";
            // 
            // dtpSince
            // 
            dtpSince.Enabled = false;
            dtpSince.Format = DateTimePickerFormat.Custom;
            dtpSince.Location = new Point(108, 93);
            dtpSince.Name = "dtpSince";
            dtpSince.Size = new Size(185, 23);
            dtpSince.TabIndex = 57;
            // 
            // cbOsoba
            // 
            cbOsoba.Enabled = false;
            cbOsoba.FormattingEnabled = true;
            cbOsoba.Location = new Point(108, 35);
            cbOsoba.Name = "cbOsoba";
            cbOsoba.Size = new Size(185, 23);
            cbOsoba.TabIndex = 56;
            // 
            // lblOsoba
            // 
            lblOsoba.AutoSize = true;
            lblOsoba.Location = new Point(3, 38);
            lblOsoba.Name = "lblOsoba";
            lblOsoba.Size = new Size(45, 15);
            lblOsoba.TabIndex = 55;
            lblOsoba.Text = "Особа:";
            // 
            // lblOd
            // 
            lblOd.AutoSize = true;
            lblOd.Location = new Point(3, 96);
            lblOd.Name = "lblOd";
            lblOd.Size = new Size(25, 15);
            lblOd.TabIndex = 52;
            lblOd.Text = "Од:";
            // 
            // cbZaposleni
            // 
            cbZaposleni.Enabled = false;
            cbZaposleni.FormattingEnabled = true;
            cbZaposleni.Location = new Point(108, 6);
            cbZaposleni.Name = "cbZaposleni";
            cbZaposleni.Size = new Size(185, 23);
            cbZaposleni.TabIndex = 60;
            // 
            // lblZaposleni
            // 
            lblZaposleni.AutoSize = true;
            lblZaposleni.Location = new Point(3, 9);
            lblZaposleni.Name = "lblZaposleni";
            lblZaposleni.Size = new Size(70, 15);
            lblZaposleni.TabIndex = 59;
            lblZaposleni.Text = "Запослени:";
            // 
            // dgvStavkeIznajmljivanja
            // 
            dgvStavkeIznajmljivanja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavkeIznajmljivanja.Location = new Point(296, 3);
            dgvStavkeIznajmljivanja.Name = "dgvStavkeIznajmljivanja";
            dgvStavkeIznajmljivanja.Size = new Size(344, 335);
            dgvStavkeIznajmljivanja.TabIndex = 61;
            // 
            // cbOprema
            // 
            cbOprema.FormattingEnabled = true;
            cbOprema.Location = new Point(108, 142);
            cbOprema.Name = "cbOprema";
            cbOprema.Size = new Size(185, 23);
            cbOprema.TabIndex = 73;
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.Location = new Point(108, 230);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(185, 23);
            dtpTo.TabIndex = 72;
            // 
            // txtTrajanje
            // 
            txtTrajanje.Enabled = false;
            txtTrajanje.Location = new Point(108, 261);
            txtTrajanje.Name = "txtTrajanje";
            txtTrajanje.Size = new Size(185, 23);
            txtTrajanje.TabIndex = 71;
            // 
            // txtCena
            // 
            txtCena.Enabled = false;
            txtCena.Location = new Point(108, 172);
            txtCena.Name = "txtCena";
            txtCena.Size = new Size(185, 23);
            txtCena.TabIndex = 70;
            // 
            // txtKolicina
            // 
            txtKolicina.Location = new Point(108, 201);
            txtKolicina.Name = "txtKolicina";
            txtKolicina.Size = new Size(185, 23);
            txtKolicina.TabIndex = 69;
            // 
            // txtIznos
            // 
            txtIznos.Enabled = false;
            txtIznos.Location = new Point(108, 291);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(185, 23);
            txtIznos.TabIndex = 68;
            // 
            // lblOprema
            // 
            lblOprema.AutoSize = true;
            lblOprema.Location = new Point(3, 145);
            lblOprema.Name = "lblOprema";
            lblOprema.Size = new Size(54, 15);
            lblOprema.TabIndex = 67;
            lblOprema.Text = "Опрема:";
            // 
            // lblIznos
            // 
            lblIznos.AutoSize = true;
            lblIznos.Location = new Point(3, 294);
            lblIznos.Name = "lblIznos";
            lblIznos.Size = new Size(44, 15);
            lblIznos.TabIndex = 66;
            lblIznos.Text = "Износ:";
            // 
            // lblTrajanje
            // 
            lblTrajanje.AutoSize = true;
            lblTrajanje.Location = new Point(3, 264);
            lblTrajanje.Name = "lblTrajanje";
            lblTrajanje.Size = new Size(54, 15);
            lblTrajanje.TabIndex = 65;
            lblTrajanje.Text = "Трајање:";
            // 
            // lblDo
            // 
            lblDo.AutoSize = true;
            lblDo.Location = new Point(3, 234);
            lblDo.Name = "lblDo";
            lblDo.Size = new Size(25, 15);
            lblDo.TabIndex = 64;
            lblDo.Text = "До:";
            // 
            // lblCena
            // 
            lblCena.AutoSize = true;
            lblCena.Location = new Point(3, 175);
            lblCena.Name = "lblCena";
            lblCena.Size = new Size(38, 15);
            lblCena.TabIndex = 63;
            lblCena.Text = "Цена:";
            // 
            // lblKolicina
            // 
            lblKolicina.AutoSize = true;
            lblKolicina.Location = new Point(3, 204);
            lblKolicina.Name = "lblKolicina";
            lblKolicina.Size = new Size(65, 15);
            lblKolicina.TabIndex = 62;
            lblKolicina.Text = "Количина:";
            // 
            // btnPrikazi
            // 
            btnPrikazi.Location = new Point(325, 350);
            btnPrikazi.Name = "btnPrikazi";
            btnPrikazi.Size = new Size(132, 38);
            btnPrikazi.TabIndex = 74;
            btnPrikazi.Text = "Прикажи";
            btnPrikazi.UseVisualStyleBackColor = true;
            // 
            // btnAddRentalItem
            // 
            btnAddRentalItem.Location = new Point(131, 320);
            btnAddRentalItem.Name = "btnAddRentalItem";
            btnAddRentalItem.Size = new Size(132, 38);
            btnAddRentalItem.TabIndex = 75;
            btnAddRentalItem.Text = "Додај ставку";
            btnAddRentalItem.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(491, 350);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(132, 38);
            btnObrisi.TabIndex = 76;
            btnObrisi.Text = "Обриши ставку";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // UCShowRent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnObrisi);
            Controls.Add(btnAddRentalItem);
            Controls.Add(btnPrikazi);
            Controls.Add(cbOprema);
            Controls.Add(dtpTo);
            Controls.Add(txtTrajanje);
            Controls.Add(txtCena);
            Controls.Add(txtKolicina);
            Controls.Add(txtIznos);
            Controls.Add(lblOprema);
            Controls.Add(lblIznos);
            Controls.Add(lblTrajanje);
            Controls.Add(lblDo);
            Controls.Add(lblCena);
            Controls.Add(lblKolicina);
            Controls.Add(dgvStavkeIznajmljivanja);
            Controls.Add(cbZaposleni);
            Controls.Add(lblZaposleni);
            Controls.Add(dtpSince);
            Controls.Add(cbOsoba);
            Controls.Add(lblOsoba);
            Controls.Add(lblOd);
            Controls.Add(txtUkupanIznos);
            Controls.Add(lblUkupanIznos);
            Name = "UCShowRent";
            Size = new Size(643, 398);
            ((System.ComponentModel.ISupportInitialize)dgvStavkeIznajmljivanja).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUkupanIznos;
        private Label lblUkupanIznos;
        private DateTimePicker dtpSince;
        private ComboBox cbOsoba;
        private Label lblOsoba;
        private Label lblOd;
        private ComboBox cbZaposleni;
        private Label lblZaposleni;
        private DataGridView dgvStavkeIznajmljivanja;
        private ComboBox cbOprema;
        private DateTimePicker dtpTo;
        private TextBox txtTrajanje;
        private TextBox txtCena;
        private TextBox txtKolicina;
        private TextBox txtIznos;
        private Label lblOprema;
        private Label lblIznos;
        private Label lblTrajanje;
        private Label lblDo;
        private Label lblCena;
        private Label lblKolicina;
        private Button btnPrikazi;
        private Button btnPromeni;
        private Button btnAddRentalItem;
        private Button btnObrisi;

        public TextBox TxtIznos { get => txtIznos; set => txtIznos = value; }
        public TextBox TxtKolicina { get => txtKolicina; set => txtKolicina = value; }
        public TextBox TxtCena { get => txtCena; set => txtCena = value; }
        public TextBox TxtTrajanje { get => txtTrajanje; set => txtTrajanje = value; }
        public TextBox TxtUkupanIznos { get => txtUkupanIznos; set => txtUkupanIznos = value; }
        public ComboBox CbOsoba { get => cbOsoba; set => cbOsoba = value; }
        public ComboBox CbOprema { get => cbOprema; set => cbOprema = value; }
        public ComboBox CbZaposleni { get => cbZaposleni; set => cbZaposleni = value; }
        public Label LblUkupanIznos { get => lblUkupanIznos; set => lblUkupanIznos = value; }
        public Label LblOd { get => lblOd; set => lblOd = value; }
        public Label LblKolicina { get => lblKolicina; set => lblKolicina = value; }
        public Label LblDo { get => lblDo; set => lblDo = value; }
        public Label LblCena { get => lblCena; set => lblCena = value; }
        public Label LblTrajanje { get => lblTrajanje; set => lblTrajanje = value; }
        public Label LblIznos { get => lblIznos; set => lblIznos = value; }
        public Label LblOprema { get => lblOprema; set => lblOprema = value; }
        public Label LblOsoba { get => lblOsoba; set => lblOsoba = value; }
        public Label LblZaposleni { get => lblZaposleni; set => lblZaposleni = value; }
        public DateTimePicker DtpTo { get => dtpTo; set => dtpTo = value; }
        public DateTimePicker DtpSince { get => dtpSince; set => dtpSince = value; }
        public DataGridView DgvStavkeIznajmljivanja { get => dgvStavkeIznajmljivanja; set => dgvStavkeIznajmljivanja = value; }
        public Button BtnPrikazi { get => btnPrikazi; set => btnPrikazi = value; }
        public Button BtnObrisi { get => btnObrisi; set => btnObrisi = value; }
        public Button BtnAddRentalItem { get => btnAddRentalItem; set => btnAddRentalItem = value; }
    }
}
