using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    internal class MainCoordinator
    {
        private static MainCoordinator instance;
        public static MainCoordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainCoordinator();
                }
                return instance;
            }
        }

        private MainCoordinator()
        {
            personGuiController = new PersonGuiController();
        }

        private FrmMain frmMain;
        private PersonGuiController personGuiController;

        internal void ShowFrmMain()
        {
            frmMain = new FrmMain();
            frmMain.AutoSize = true;
            frmMain.ShowDialog();
        }

        internal void ShowAddPersonPanel()
        {
            frmMain.ChangePanel(personGuiController.CreateAddPerson());
        }

        internal void ShowManagePersonPanel()
        {
            frmMain.ChangePanel(personGuiController.CreateManagePerson());
        }
    }
}
