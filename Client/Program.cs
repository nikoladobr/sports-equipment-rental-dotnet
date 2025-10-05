using Client.GuiController;

namespace Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoginGuiController.Instance.ShowFrmLogin();
        }
    }
}