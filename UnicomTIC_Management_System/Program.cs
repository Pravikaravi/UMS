using System;
using System.Windows.Forms;
using UnicomTIC_Management_System.Repositories;
using UnicomTIC_Management_System.Views;

namespace UnicomTIC_Management_System
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DatabaseInitializer.CreateTables(); // create admin user if needed

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new formMain()); // Run main form first
            //Application.Run(new AdminPanel()); // Run main form first
         
        }
    }
}
