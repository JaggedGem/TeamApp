namespace TeamApp
{
    public partial class MainWindow : Form
    {
        private List<Team> teams;

        public MainWindow(List<Team> teams) {
            this.teams = teams;

            InitializeComponent();
        }
    }
}