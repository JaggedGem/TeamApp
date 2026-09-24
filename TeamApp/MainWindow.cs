namespace TeamApp
{
    public partial class MainWindow : Form
    {
        private readonly List<Team> _teams;

        public MainWindow(List<Team> teams) {
            _teams = teams;

            InitializeComponent();

            PopulateTeams();
        }

        private void PopulateTeams() {
            teamSelect.Items.Clear();

            if (_teams.Count == 0) {
                teamSelect.Items.Add("Adauga prima echipa...");
                teamSelect.SelectedIndex = 0;
                teamSelect.Enabled = false;

                return;
            }

            foreach (Team team in _teams) {
                teamSelect.Items.Add(team.Name);
            }
        }

        private void PopulatePlayers(int selectedTeamIndex) {
            List<Player> players = _teams[selectedTeamIndex].Players;

            if (players.Count == 0) {
                playerList.Controls.Clear();
                playerList.Visible = false;

                return;
            }

            int buttonId = 0;
            foreach (Player player in players) {
                Button button = new Button();

                button.Anchor = AnchorStyles.None;
                button.Location = new Point(3, 3);
                button.Name = $"playerButton_{buttonId++}";
                button.Size = new Size(playerList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth, 25);
                button.TabIndex = 0;
                button.Text = player.Name;
                button.UseVisualStyleBackColor = true;
                button.Click += (object sender, EventArgs e) => { PopulatePlayerData(player); };
            }
        }

        private void PopulatePlayerData(Player selectedPlayer) {
            playerNameInput.Text = selectedPlayer.Name;
            positionInput.Text = selectedPlayer.Position;
            idnpInput.Text = selectedPlayer.IDNP.ToString();
            birthdayInput.Value = selectedPlayer.BirthDate;
        }

        private void teamSelect_SelectedIndexChanged(object sender, EventArgs e) {
            if (teamSelect.SelectedIndex < 0 || teamSelect.SelectedIndex >= _teams.Count)
                return;

            PopulatePlayers(teamSelect.SelectedIndex);
        }

        private void newTeamButton_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
    }
}