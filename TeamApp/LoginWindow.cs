using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TeamApp
{
    public partial class LoginWindow : Form
    {
        public List<string> DataFiles { get; private set; } = new  List<string>();

        public LoginWindow()
        {
            InitializeComponent();  
        }

        private bool checkCredentials(string  username, string password)
        {
            if (!File.Exists(@"./auth.meta"))
            {
                MessageBox.Show(@"Login Error", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
                return false;
            }
            
            return true;
        }

        private void LoadData()
        {
            bool skipEntryScan = false;

            if (!Directory.Exists("./data"))
            {
                Directory.CreateDirectory("./data");
                skipEntryScan = true;
            }

            loadingBar.Value = 33;

            string[] dataFolders = Directory.GetDirectories("./data");

            loadingBar.Value = 66;

            if (!skipEntryScan)
            {
                foreach (string dataFolder in dataFolders)
                {
                    DataFiles.AddRange(
                        Directory.GetFiles(dataFolder, "*.tmap")
                    );
                }
            }

            loadingBar.Value = 100;
        }
        
        private void LoadingDataWindow_Shown(object sender, EventArgs e)
        {
            LoadData();
            Close();
        }
    }
}