namespace Client.UserControls
{
    partial class UCAddPerson
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
            lblIme = new Label();
            lblPrezime = new Label();
            lblEmail = new Label();
            lblKategorija = new Label();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtEmail = new TextBox();
            btnAddPerson = new Button();
            cbKategorija = new ComboBox();
            SuspendLayout();
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(185, 108);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(34, 15);
            lblIme.TabIndex = 0;
            lblIme.Text = "Име:";
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(185, 146);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(59, 15);
            lblPrezime.TabIndex = 1;
            lblPrezime.Text = "Презиме:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(185, 184);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(45, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Емаил:";
            // 
            // lblKategorija
            // 
            lblKategorija.AutoSize = true;
            lblKategorija.Location = new Point(185, 222);
            lblKategorija.Name = "lblKategorija";
            lblKategorija.Size = new Size(69, 15);
            lblKategorija.TabIndex = 3;
            lblKategorija.Text = "Категорија:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(280, 105);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(178, 23);
            txtIme.TabIndex = 4;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(280, 143);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(178, 23);
            txtPrezime.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(280, 181);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(178, 23);
            txtEmail.TabIndex = 6;
            // 
            // btnAddPerson
            // 
            btnAddPerson.Location = new Point(321, 257);
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.Size = new Size(86, 36);
            btnAddPerson.TabIndex = 7;
            btnAddPerson.Text = "Запамти";
            btnAddPerson.UseVisualStyleBackColor = true;
            // 
            // cbKategorija
            // 
            cbKategorija.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKategorija.FormattingEnabled = true;
            cbKategorija.Location = new Point(280, 219);
            cbKategorija.Name = "cbKategorija";
            cbKategorija.Size = new Size(178, 23);
            cbKategorija.TabIndex = 8;
            // 
            // UCAddPerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cbKategorija);
            Controls.Add(btnAddPerson);
            Controls.Add(txtEmail);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(lblKategorija);
            Controls.Add(lblEmail);
            Controls.Add(lblPrezime);
            Controls.Add(lblIme);
            Name = "UCAddPerson";
            Size = new Size(643, 398);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIme;
        private Label lblPrezime;
        private Label lblEmail;
        private Label lblKategorija;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtEmail;
        private Button btnAddPerson;
        private ComboBox cbKategorija;

        public Button BtnAddPerson { get => btnAddPerson; set => btnAddPerson = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }
        public ComboBox CbKategorija { get => cbKategorija; set => cbKategorija = value; }
        public Label LblIme { get => lblIme; set => lblIme = value; }
        public Label LblPrezime { get => lblPrezime; set => lblPrezime = value; }
        public Label LblEmail { get => lblEmail; set => lblEmail = value; }
        public Label LblKategorija { get => lblKategorija; set => lblKategorija = value; }

    }
}
