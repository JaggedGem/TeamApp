namespace TeamApp
{
    public partial class MainWindow : Form
    {
        private readonly TeamRepository _teamRepository;

        public MainWindow(TeamRepository teamRepository) {
            _teamRepository = teamRepository;

            InitializeComponent();

            PopulateTeams();
        }

        private void PopulateTeams() {
            teamSelect.Items.Clear();

            if (_teamRepository.Teams.Count == 0) {
                teamSelect.Items.Add("Adauga prima echipa...");
                teamSelect.SelectedIndex = 0;
                teamSelect.Enabled = false;

                return;
            }

            foreach (Team team in _teamRepository.Teams) {
                teamSelect.Items.Add(team.Name);
            }

            teamSelect.SelectedIndex = 0;
        }

        private void PopulatePlayers(int selectedTeamIndex) {
            List<Player> players = _teamRepository.Teams[selectedTeamIndex].Players;

            if (players.Count == 0) {
                playerList.Controls.Clear();
                playerList.Visible = false;

                label2.Visible = true;

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
            idnpInput.Text = selectedPlayer.Idnp.ToString();
            birthdayInput.Value = selectedPlayer.BirthDate;
        }

        private void teamSelect_SelectedIndexChanged(object sender, EventArgs e) {
            if (teamSelect.SelectedIndex < 0 || teamSelect.SelectedIndex >= _teamRepository.Teams.Count)
                return;

            PopulatePlayers(teamSelect.SelectedIndex);
        }

        private void newTeamButton_Click(object sender, EventArgs e) {
            NewTeamWindow window = new NewTeamWindow();

            window.ShowDialog();

            if (window.DialogResult != DialogResult.OK) {
                return;
            }

            if (_teamRepository.Teams.Count == 0) {
                teamSelect.Items.Clear();
                teamSelect.Enabled = true;
            }

            _teamRepository.CreateTeam(window.NewTeamName, team => { teamSelect.Items.Add(team.Name); });

            if (_teamRepository.Teams.Count == 1) {
                teamSelect.SelectedIndex = 0;
            }
        }
    }
}