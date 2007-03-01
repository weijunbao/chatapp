using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChatApp.Properties; 
using System.Threading;

namespace ChatApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Show the Debug output windwo
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Settings.Default.Debug == true)
            {
                DebugOutput dbgWindow = new DebugOutput();
                dbgWindow.Show();
            }


            // ApplicationContext currentAppContext = new ApplicationContext();
            Application.Run(AppController.Instance);
         }

    }
}