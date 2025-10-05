using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;



namespace Client.GuiController
{
    public class LoginGuiController
    {
        private static LoginGuiController instance;
        public static LoginGuiController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginGuiController();
                }
                return instance;
            }
        }
        private LoginGuiController()
        {
        }

        private FrmLogin frmLogin;

        internal void ShowFrmLogin()
        {
            try
            {
                Communication.Instance.Connect();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frmLogin = new FrmLogin();
                frmLogin.AutoSize = true;
                Application.Run(frmLogin);
            }
            catch (SocketException)
            {
                MessageBox.Show("Није могуће успоставити комуникацију са сервером!");
            }
        }
        public void Login(object? sender, EventArgs e)
        {
            if (!frmLogin.Validacija())
            {
                MessageBox.Show("Молимо попуните сва поља");
                return;
            }

            Zaposleni z = new Zaposleni
            {
                KorisnickoIme = frmLogin.TxtUsername.Text,
                Sifra = frmLogin.TxtPassword.Text
            };
            Response response = Communication.Instance.Login(z);
            if (response.ExceptionMessage == null)
            {
                MessageBox.Show("Корисничко име и шифра су исправни.");
                frmLogin.Visible = false;
                MainCoordinator.Instance.ShowFrmMain();
            }
            else
            {
                MessageBox.Show("Не може да се отвори главна форма и мени");
            }
        }
    }
}
