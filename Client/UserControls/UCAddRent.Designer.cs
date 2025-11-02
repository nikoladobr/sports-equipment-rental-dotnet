using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Client.UserControls
{
    partial class UCAddRent
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
            lblUkupanIznos = new Label();
            lblOd = new Label();
            lblOkvir1 = new Label();
            lblKolicina = new Label();
            lblCena = new Label();
            lblDo = new Label();
            lblTrajanje = new Label();
            lblIznos = new Label();
            lblOprema = new Label();
            lblOsoba = new Label();
            cbOsoba = new ComboBox();
            txtIznos = new TextBox();
            dtpSince = new DateTimePicker();
            lblOkvir2 = new Label();
            txtKolicina = new TextBox();
            txtCena = new TextBox();
            txtTrajanje = new TextBox();
            dtpTo = new DateTimePicker();
            cbOprema = new ComboBox();
            btnAddRentalItem = new Button();
            txtUkupanIznos = new TextBox();
            btnAddRent = new Button();
            label4 = new Label();
            lblRb = new Label();
            dgvStavke = new DataGridView();
            btnObrisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            SuspendLayout();
            // 
            // lblUkupanIznos
            // 
            lblUkupanIznos.AutoSize = true;
            lblUkupanIznos.Location = new Point(11, 444);
            lblUkupanIznos.Name = "lblUkupanIznos";
            lblUkupanIznos.Size = new Size(106, 20);
            lblUkupanIznos.TabIndex = 1;
            lblUkupanIznos.Text = "Укупан износ:";
            // 
            // lblOd
            // 
            lblOd.AutoSize = true;
            lblOd.Location = new Point(11, 64);
            lblOd.Name = "lblOd";
            lblOd.Size = new Size(31, 20);
            lblOd.TabIndex = 2;
            lblOd.Text = "Од:";
            // 
            // lblOkvir1
            // 
            lblOkvir1.AutoSize = true;
            lblOkvir1.Location = new Point(0, 109);
            lblOkvir1.Name = "lblOkvir1";
            lblOkvir1.Size = new Size(532, 20);
            lblOkvir1.TabIndex = 3;
            lblOkvir1.Text = "------------------------------ Ставка изнајмљивања ------------------------------";
            // 
            // lblKolicina
            // 
            lblKolicina.AutoSize = true;
            lblKolicina.Location = new Point(11, 220);
            lblKolicina.Name = "lblKolicina";
            lblKolicina.Size = new Size(81, 20);
            lblKolicina.TabIndex = 5;
            lblKolicina.Text = "Количина:";
            // 
            // lblCena
            // 
            lblCena.AutoSize = true;
            lblCena.Location = new Point(11, 181);
            lblCena.Name = "lblCena";
            lblCena.Size = new Size(48, 20);
            lblCena.TabIndex = 6;
            lblCena.Text = "Цена:";
            // 
            // lblDo
            // 
            lblDo.AutoSize = true;
            lblDo.Location = new Point(11, 260);
            lblDo.Name = "lblDo";
            lblDo.Size = new Size(31, 20);
            lblDo.TabIndex = 7;
            lblDo.Text = "До:";
            // 
            // lblTrajanje
            // 
            lblTrajanje.AutoSize = true;
            lblTrajanje.Location = new Point(11, 300);
            lblTrajanje.Name = "lblTrajanje";
            lblTrajanje.Size = new Size(69, 20);
            lblTrajanje.TabIndex = 8;
            lblTrajanje.Text = "Трајање:";
            // 
            // lblIznos
            // 
            lblIznos.AutoSize = true;
            lblIznos.Location = new Point(11, 340);
            lblIznos.Name = "lblIznos";
            lblIznos.Size = new Size(55, 20);
            lblIznos.TabIndex = 9;
            lblIznos.Text = "Износ:";
            // 
            // lblOprema
            // 
            lblOprema.AutoSize = true;
            lblOprema.Location = new Point(11, 141);
            lblOprema.Name = "lblOprema";
            lblOprema.Size = new Size(68, 20);
            lblOprema.TabIndex = 10;
            lblOprema.Text = "Опрема:";
            // 
            // lblOsoba
            // 
            lblOsoba.AutoSize = true;
            lblOsoba.Location = new Point(11, 25);
            lblOsoba.Name = "lblOsoba";
            lblOsoba.Size = new Size(56, 20);
            lblOsoba.TabIndex = 11;
            lblOsoba.Text = "Особа:";
            // 
            // cbOsoba
            // 
            cbOsoba.FormattingEnabled = true;
            cbOsoba.Location = new Point(131, 21);
            cbOsoba.Margin = new Padding(3, 4, 3, 4);
            cbOsoba.Name = "cbOsoba";
            cbOsoba.Size = new Size(211, 28);
            cbOsoba.TabIndex = 12;
            // 
            // txtIznos
            // 
            txtIznos.Enabled = false;
            txtIznos.Location = new Point(131, 336);
            txtIznos.Margin = new Padding(3, 4, 3, 4);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(211, 27);
            txtIznos.TabIndex = 13;
            // 
            // dtpSince
            // 
            dtpSince.Format = DateTimePickerFormat.Custom;
            dtpSince.Location = new Point(131, 60);
            dtpSince.Margin = new Padding(3, 4, 3, 4);
            dtpSince.Name = "dtpSince";
            dtpSince.Size = new Size(211, 27);
            dtpSince.TabIndex = 14;
            // 
            // lblOkvir2
            // 
            lblOkvir2.AutoSize = true;
            lblOkvir2.Location = new Point(-3, 376);
            lblOkvir2.Name = "lblOkvir2";
            lblOkvir2.Size = new Size(541, 20);
            lblOkvir2.TabIndex = 15;
            lblOkvir2.Text = "---------------------------------------------------------------------------------------- ";
            // 
            // txtKolicina
            // 
            txtKolicina.Location = new Point(131, 216);
            txtKolicina.Margin = new Padding(3, 4, 3, 4);
            txtKolicina.Name = "txtKolicina";
            txtKolicina.Size = new Size(211, 27);
            txtKolicina.TabIndex = 16;
            // 
            // txtCena
            // 
            txtCena.Enabled = false;
            txtCena.Location = new Point(131, 177);
            txtCena.Margin = new Padding(3, 4, 3, 4);
            txtCena.Name = "txtCena";
            txtCena.Size = new Size(211, 27);
            txtCena.TabIndex = 17;
            // 
            // txtTrajanje
            // 
            txtTrajanje.Enabled = false;
            txtTrajanje.Location = new Point(131, 296);
            txtTrajanje.Margin = new Padding(3, 4, 3, 4);
            txtTrajanje.Name = "txtTrajanje";
            txtTrajanje.Size = new Size(211, 27);
            txtTrajanje.TabIndex = 18;
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.Location = new Point(131, 255);
            dtpTo.Margin = new Padding(3, 4, 3, 4);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(211, 27);
            dtpTo.TabIndex = 19;
            // 
            // cbOprema
            // 
            cbOprema.FormattingEnabled = true;
            cbOprema.Location = new Point(131, 137);
            cbOprema.Margin = new Padding(3, 4, 3, 4);
            cbOprema.Name = "cbOprema";
            cbOprema.Size = new Size(211, 28);
            cbOprema.TabIndex = 20;
            // 
            // btnAddRentalItem
            // 
            btnAddRentalItem.Location = new Point(360, 192);
            btnAddRentalItem.Margin = new Padding(3, 4, 3, 4);
            btnAddRentalItem.Name = "btnAddRentalItem";
            btnAddRentalItem.Size = new Size(151, 51);
            btnAddRentalItem.TabIndex = 21;
            btnAddRentalItem.Text = "Додај ставку";
            btnAddRentalItem.UseVisualStyleBackColor = true;
            // 
            // txtUkupanIznos
            // 
            txtUkupanIznos.Enabled = false;
            txtUkupanIznos.Location = new Point(131, 440);
            txtUkupanIznos.Margin = new Padding(3, 4, 3, 4);
            txtUkupanIznos.Name = "txtUkupanIznos";
            txtUkupanIznos.Size = new Size(211, 27);
            txtUkupanIznos.TabIndex = 22;
            // 
            // btnAddRent
            // 
            btnAddRent.Location = new Point(360, 429);
            btnAddRent.Margin = new Padding(3, 4, 3, 4);
            btnAddRent.Name = "btnAddRent";
            btnAddRent.Size = new Size(151, 51);
            btnAddRent.TabIndex = 23;
            btnAddRent.Text = "Додај изнајмљивање";
            btnAddRent.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(422, 140);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 24;
            label4.Text = "Редни број:";
            // 
            // lblRb
            // 
            lblRb.AutoSize = true;
            lblRb.Location = new Point(502, 140);
            lblRb.Name = "lblRb";
            lblRb.Size = new Size(0, 20);
            lblRb.TabIndex = 25;
            // 
            // dgvStavke
            // 
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Location = new Point(538, 3);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.RowHeadersWidth = 51;
            dgvStavke.Size = new Size(777, 503);
            dgvStavke.TabIndex = 26;
            // 
            // btnObrisi
            // 
            btnObrisi.Enabled = false;
            btnObrisi.Location = new Point(360, 269);
            btnObrisi.Margin = new Padding(3, 4, 3, 4);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(151, 51);
            btnObrisi.TabIndex = 27;
            btnObrisi.Text = "Обриши ставку";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // UCAddRent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnObrisi);
            Controls.Add(dgvStavke);
            Controls.Add(lblRb);
            Controls.Add(label4);
            Controls.Add(btnAddRent);
            Controls.Add(txtUkupanIznos);
            Controls.Add(btnAddRentalItem);
            Controls.Add(cbOprema);
            Controls.Add(dtpTo);
            Controls.Add(txtTrajanje);
            Controls.Add(txtCena);
            Controls.Add(txtKolicina);
            Controls.Add(lblOkvir2);
            Controls.Add(dtpSince);
            Controls.Add(txtIznos);
            Controls.Add(cbOsoba);
            Controls.Add(lblOsoba);
            Controls.Add(lblOprema);
            Controls.Add(lblIznos);
            Controls.Add(lblTrajanje);
            Controls.Add(lblDo);
            Controls.Add(lblCena);
            Controls.Add(lblKolicina);
            Controls.Add(lblOkvir1);
            Controls.Add(lblOd);
            Controls.Add(lblUkupanIznos);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UCAddRent";
            Size = new Size(1318, 509);
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblUkupanIznos;
        private Label lblOd;
        private Label lblOkvir1;
        private Label lblKolicina;
        private Label lblCena;
        private Label lblDo;
        private Label lblTrajanje;
        private Label lblIznos;
        private Label lblOprema;
        private Label lblOsoba;
        private Label lblOkvir2;
        private Label label4;
        private Label lblRb;

        private ComboBox cbOsoba;
        private ComboBox cbOprema;

        private TextBox txtIznos;
        private TextBox txtKolicina;
        private TextBox txtCena;
        private TextBox txtTrajanje;
        private TextBox txtUkupanIznos;

        private DateTimePicker dtpTo;
        private DateTimePicker dtpSince;

        private Button btnAddRentalItem;
        private Button btnAddRent;
        private DataGridView dgvStavke;
        private Button btnObrisi;

        public Button BtnAddRentalItem { get => btnAddRentalItem; set => btnAddRentalItem = value; }
        public Button BtnAddRent { get => btnAddRent; set => btnAddRent = value; }
        public Button BtnObrisi { get => btnObrisi; set => btnObrisi = value; }
        public TextBox TxtIznos { get => txtIznos; set => txtIznos = value; }
        public TextBox TxtKolicina { get => txtKolicina; set => txtKolicina = value; }
        public TextBox TxtCena { get => txtCena; set => txtCena = value; }
        public TextBox TxtTrajanje { get => txtTrajanje; set => txtTrajanje = value; }
        public TextBox TxtUkupanIznos { get => txtUkupanIznos; set => txtUkupanIznos = value; }
        public ComboBox CbOsoba { get => cbOsoba; set => cbOsoba = value; }
        public ComboBox CbOprema { get => cbOprema; set => cbOprema = value; }
        public Label LblUkupanIznos { get => lblUkupanIznos; set => lblUkupanIznos = value; }
        public Label LblOd { get => lblOd; set => lblOd = value; }
        public Label LblOkvir1 { get => lblOkvir1; set => lblOkvir1 = value; }
        public Label LblKolicina { get => lblKolicina; set => lblKolicina = value; }
        public Label LblDo { get => lblDo; set => lblDo = value; }
        public Label LblCena { get => lblCena; set => lblCena = value; }
        public Label LblTrajanje { get => lblTrajanje; set => lblTrajanje = value; }
        public Label LblIznos { get => lblIznos; set => lblIznos = value; }
        public Label LblOprema { get => lblOprema; set => lblOprema = value; }
        public Label LblOsoba { get => lblOsoba; set => lblOsoba = value; }
        public Label LblOkvir2 { get => lblOkvir2; set => lblOkvir2 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public Label LblRb { get => lblRb; set => lblRb = value; }
        public DateTimePicker DtpTo { get => dtpTo; set => dtpTo = value; }
        public DateTimePicker DtpSince { get => dtpSince; set => dtpSince = value; }
        public DataGridView DgvStavke { get => dgvStavke; set => dgvStavke = value; }
    }
}
