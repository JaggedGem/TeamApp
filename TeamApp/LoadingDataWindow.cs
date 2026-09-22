using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TeamApp
{
    public partial class LoadingDataWindow : Form
    {
        public List<string> DataFiles { get; private set; } = new  List<string>();

        public LoadingDataWindow()
        {
            InitializeComponent();
            
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