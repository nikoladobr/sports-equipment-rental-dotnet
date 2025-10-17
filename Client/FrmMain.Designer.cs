namespace Client
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            особаToolStripMenuItem = new ToolStripMenuItem();
            itemAddPerson = new ToolStripMenuItem();
            itemManagePerson = new ToolStripMenuItem();
            изнајмљивањеToolStripMenuItem = new ToolStripMenuItem();
            itemAddRent = new ToolStripMenuItem();
            itemManageRent = new ToolStripMenuItem();
            pnlMain = new Panel();
            терминДежурстваToolStripMenuItem = new ToolStripMenuItem();
            itemAddDutyTerm = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { особаToolStripMenuItem, изнајмљивањеToolStripMenuItem, терминДежурстваToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(643, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // особаToolStripMenuItem
            // 
            особаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { itemAddPerson, itemManagePerson });
            особаToolStripMenuItem.Name = "особаToolStripMenuItem";
            особаToolStripMenuItem.Size = new Size(54, 20);
            особаToolStripMenuItem.Text = "Особа";
            // 
            // itemAddPerson
            // 
            itemAddPerson.Name = "itemAddPerson";
            itemAddPerson.Size = new Size(125, 22);
            itemAddPerson.Text = "Креирај";
            // 
            // itemManagePerson
            // 
            itemManagePerson.Name = "itemManagePerson";
            itemManagePerson.Size = new Size(125, 22);
            itemManagePerson.Text = "Управљај";
            // 
            // изнајмљивањеToolStripMenuItem
            // 
            изнајмљивањеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { itemAddRent, itemManageRent });
            изнајмљивањеToolStripMenuItem.Name = "изнајмљивањеToolStripMenuItem";
            изнајмљивањеToolStripMenuItem.Size = new Size(102, 20);
            изнајмљивањеToolStripMenuItem.Text = "Изнајмљивање";
            // 
            // itemAddRent
            // 
            itemAddRent.Name = "itemAddRent";
            itemAddRent.Size = new Size(180, 22);
            itemAddRent.Text = "Креирај";
            // 
            // itemManageRent
            // 
            itemManageRent.Name = "itemManageRent";
            itemManageRent.Size = new Size(180, 22);
            itemManageRent.Text = "Управљај";
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 24);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(643, 398);
            pnlMain.TabIndex = 1;
            // 
            // терминДежурстваToolStripMenuItem
            // 
            терминДежурстваToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { itemAddDutyTerm });
            терминДежурстваToolStripMenuItem.Name = "терминДежурстваToolStripMenuItem";
            терминДежурстваToolStripMenuItem.Size = new Size(121, 20);
            терминДежурстваToolStripMenuItem.Text = "Термин дежурства";
            // 
            // itemAddDutyTerm
            // 
            itemAddDutyTerm.Name = "itemAddDutyTerm";
            itemAddDutyTerm.Size = new Size(180, 22);
            itemAddDutyTerm.Text = "Убаци";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 422);
            Controls.Add(pnlMain);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            Text = "Главна";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem особаToolStripMenuItem;
        private Panel pnlMain;
        private ToolStripMenuItem itemManagePerson;
        private ToolStripMenuItem itemAddPerson;
        private ToolStripMenuItem изнајмљивањеToolStripMenuItem;
        private ToolStripMenuItem itemAddRent;
        private ToolStripMenuItem itemManageRent;
        private ToolStripMenuItem терминДежурстваToolStripMenuItem;
        private ToolStripMenuItem itemAddDutyTerm;
    }
}