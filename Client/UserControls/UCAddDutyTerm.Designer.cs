namespace Client.UserControls
{
    partial class UCAddDutyTerm
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
            lblSmena = new Label();
            btnUbaci = new Button();
            txtSmena = new TextBox();
            SuspendLayout();
            // 
            // lblSmena
            // 
            lblSmena.AutoSize = true;
            lblSmena.Location = new Point(263, 167);
            lblSmena.Name = "lblSmena";
            lblSmena.Size = new Size(46, 15);
            lblSmena.TabIndex = 0;
            lblSmena.Text = "Смена:";
            // 
            // btnUbaci
            // 
            btnUbaci.Location = new Point(269, 204);
            btnUbaci.Name = "btnUbaci";
            btnUbaci.Size = new Size(106, 45);
            btnUbaci.TabIndex = 2;
            btnUbaci.Text = "Убаци";
            btnUbaci.UseVisualStyleBackColor = true;
            // 
            // txtSmena
            // 
            txtSmena.Location = new Point(315, 164);
            txtSmena.Name = "txtSmena";
            txtSmena.Size = new Size(69, 23);
            txtSmena.TabIndex = 3;
            // 
            // UCAddDutyTerm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtSmena);
            Controls.Add(btnUbaci);
            Controls.Add(lblSmena);
            Name = "UCAddDutyTerm";
            Size = new Size(643, 398);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSmena;
        private Button btnUbaci;
        private TextBox txtSmena;

        public Button BtnUbaci { get => btnUbaci; set => btnUbaci = value; }
        public TextBox TxtSmena { get => txtSmena; set => txtSmena = value; }

    }
}
