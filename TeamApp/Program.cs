namespace TeamApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<Team> teams;
            if (!File.Exists(@"./auth.meta")) {
                SignupWindow signupWindow = new SignupWindow();
                if (signupWindow.ShowDialog() != DialogResult.OK) {
                    return;
                }

                teams = new List<Team>();
            }
            else {
                LoginWindow loginWindow = new LoginWindow();
                if (loginWindow.ShowDialog() != DialogResult.OK) {
                    return;
                }

                teams = loginWindow.Teams;
            }

            Application.Run(new MainWindow(teams));
        }
    }
}