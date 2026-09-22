using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TeamApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            LoadingDataWindow loadingWindow = new LoadingDataWindow();

            Application.Run(loadingWindow);

            Application.Run(new MainWindow(loadingWindow.DataFiles));
        }
    }
}