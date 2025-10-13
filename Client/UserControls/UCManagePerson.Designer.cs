namespace Client.UserControls
{
    partial class UCManagePerson
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
            cbKategorija = new ComboBox();
            btnSearchPerson = new Button();
            txtEmail = new TextBox();
            txtPrezime = new TextBox();
            lblKategorija = new Label();
            lblEmail = new Label();
            lblPrezime = new Label();
            lblIme = new Label();
            dgvOsobe = new DataGridView();
            btnEditPerson = new Button();
            btnRemovePerson = new Button();
            btnShowPerson = new Button();
            txtIme = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvOsobe).BeginInit();
            SuspendLayout();
            // 
            // cbKategorija
            // 
            cbKategorija.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKategorija.FormattingEnabled = true;
            cbKategorija.Location = new Point(104, 130);
            cbKategorija.Name = "cbKategorija";
            cbKategorija.Size = new Size(153, 23);
            cbKategorija.TabIndex = 17;
            // 
            // btnSearchPerson
            // 
            btnSearchPerson.Location = new Point(288, 36);
            btnSearchPerson.Name = "btnSearchPerson";
            btnSearchPerson.Size = new Size(86, 36);
            btnSearchPerson.TabIndex = 16;
            btnSearchPerson.Text = "Претражи";
            btnSearchPerson.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(104, 92);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(153, 23);
            txtEmail.TabIndex = 15;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(104, 54);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(153, 23);
            txtPrezime.TabIndex = 14;
            // 
            // lblKategorija
            // 
            lblKategorija.AutoSize = true;
            lblKategorija.Location = new Point(9, 133);
            lblKategorija.Name = "lblKategorija";
            lblKategorija.Size = new Size(69, 15);
            lblKategorija.TabIndex = 12;
            lblKategorija.Text = "Категорија:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(9, 95);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(45, 15);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Емаил:";
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(9, 57);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(59, 15);
            lblPrezime.TabIndex = 10;
            lblPrezime.Text = "Презиме:";
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(9, 19);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(34, 15);
            lblIme.TabIndex = 9;
            lblIme.Text = "Име:";
            // 
            // dgvOsobe
            // 
            dgvOsobe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOsobe.Location = new Point(3, 172);
            dgvOsobe.Name = "dgvOsobe";
            dgvOsobe.Size = new Size(429, 223);
            dgvOsobe.TabIndex = 18;
            // 
            // btnEditPerson
            // 
            btnEditPerson.Location = new Point(448, 274);
            btnEditPerson.Name = "btnEditPerson";
            btnEditPerson.Size = new Size(86, 36);
            btnEditPerson.TabIndex = 19;
            btnEditPerson.Text = "Промени";
            btnEditPerson.UseVisualStyleBackColor = true;
            // 
            // btnRemovePerson
            // 
            btnRemovePerson.Location = new Point(554, 274);
            btnRemovePerson.Name = "btnRemovePerson";
            btnRemovePerson.Size = new Size(86, 36);
            btnRemovePerson.TabIndex = 20;
            btnRemovePerson.Text = "Обриши";
            btnRemovePerson.UseVisualStyleBackColor = true;
            // 
            // btnShowPerson
            // 
            btnShowPerson.Location = new Point(497, 218);
            btnShowPerson.Name = "btnShowPerson";
            btnShowPerson.Size = new Size(86, 36);
            btnShowPerson.TabIndex = 21;
            btnShowPerson.Text = "Прикажи";
            btnShowPerson.UseVisualStyleBackColor = true;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(104, 16);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(153, 23);
            txtIme.TabIndex = 13;
            // 
            // UCManagePerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnShowPerson);
            Controls.Add(btnRemovePerson);
            Controls.Add(btnEditPerson);
            Controls.Add(dgvOsobe);
            Controls.Add(cbKategorija);
            Controls.Add(btnSearchPerson);
            Controls.Add(txtEmail);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(lblKategorija);
            Controls.Add(lblEmail);
            Controls.Add(lblPrezime);
            Controls.Add(lblIme);
            Name = "UCManagePerson";
            Size = new Size(643, 398);
            ((System.ComponentModel.ISupportInitialize)dgvOsobe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbKategorija;
        private Button btnSearchPerson;
        private TextBox txtEmail;
        private TextBox txtPrezime;
        private Label lblKategorija;
        private Label lblEmail;
        private Label lblPrezime;
        private Label lblIme;
        private DataGridView dgvOsobe;
        private Button btnEditPerson;
        private Button btnRemovePerson;
        private Button btnShowPerson;
        private TextBox txtIme;

        public Button BtnSearchPerson { get => btnSearchPerson; set => btnSearchPerson = value; }
        public Button BtnEditPerson { get => btnEditPerson; set => btnEditPerson = value; }
        public Button BtnRemovePerson { get => btnRemovePerson; set => btnRemovePerson = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }
        public ComboBox CbKategorija { get => cbKategorija; set => cbKategorija = value; }
        public Label LblIme { get => lblIme; set => lblIme = value; }
        public Label LblPrezime { get => lblPrezime; set => lblPrezime = value; }
        public Label LblEmail { get => lblEmail; set => lblEmail = value; }
        public Label LblKategorija { get => lblKategorija; set => lblKategorija = value; }
        public DataGridView DgvOsobe { get => dgvOsobe; set => dgvOsobe = value; }
        public Button BtnShowPerson { get => btnShowPerson; set => btnShowPerson = value; }

    }
}
