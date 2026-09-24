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

            TeamRepository teamRepository;
            if (!File.Exists(@"./auth.meta")) {
                SignupWindow signupWindow = new SignupWindow();
                if (signupWindow.ShowDialog() != DialogResult.OK) {
                    return;
                }

                teamRepository = signupWindow.TeamRepository;
            }
            else {
                LoginWindow loginWindow = new LoginWindow();
                if (loginWindow.ShowDialog() != DialogResult.OK) {
                    return;
                }

                teamRepository = loginWindow.TeamRepository;
            }

            Application.Run(new MainWindow(teamRepository));
        }
    }
}