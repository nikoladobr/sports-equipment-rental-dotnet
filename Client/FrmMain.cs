using Client.GuiController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            itemAddPerson.Click += (s, a) => MainCoordinator.Instance.ShowAddPersonPanel();
            itemManagePerson.Click += (s,a) => MainCoordinator.Instance.ShowManagePersonPanel();
            itemAddRent.Click += (s, a) => MainCoordinator.Instance.ShowAddRentPanel();
            itemManageRent.Click += (s, a) => MainCoordinator.Instance.ShowManageRentPanel();
        }
        public void ChangePanel(Control control)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            pnlMain.AutoSize = true;
            pnlMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }

}
