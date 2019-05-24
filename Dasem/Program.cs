using System;
using System.Windows.Forms;

namespace DasemBeniSanssen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Classes.Security security = new Classes.Security();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //security.expirationDate();
            Application.Run(new Forms.Login());
        }
    }
}