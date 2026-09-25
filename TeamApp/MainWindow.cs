namespace TeamApp
{
    public partial class MainWindow : Form
    {
        private readonly TeamRepository _teamRepository;
        private Player? _selectedPlayer;

        public MainWindow(TeamRepository teamRepository) {
            _teamRepository = teamRepository;

            InitializeComponent();

            PopulateTeams();
            PopulatePlayers(teamSelect.SelectedIndex);
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
            playerList.Controls.Clear();

            List<Player> players = _teamRepository.Teams[selectedTeamIndex].Players;

            if (players.Count == 0) {
                playerList.Visible = false;
                label2.Visible = true;

                playerNameInput.Enabled = false;
                positionInput.Enabled = false;
                idnpInput.Enabled = false;
                birthdayInput.Enabled = false;

                savePlayerDataButton.Enabled = false;

                playerNameInput.Text = "";
                positionInput.Text = "";
                idnpInput.Text = "";
                birthdayInput.Value = DateTime.Today;

                return;
            }

            playerList.Visible = true;
            label2.Visible = false;

            playerNameInput.Enabled = true;
            positionInput.Enabled = true;
            idnpInput.Enabled = true;
            birthdayInput.Enabled = true;

            savePlayerDataButton.Enabled = true;

            int buttonId = 0;

            foreach (Player player in players) {
                Button button = new Button();

                button.Anchor = AnchorStyles.None;
                button.Location = new Point(3, 3);
                button.Name = $"playerButton_{buttonId++}";
                button.Size = new Size(
                    playerList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth,
                    25
                );
                button.TabIndex = 0;
                button.Text = player.Name;
                button.UseVisualStyleBackColor = true;
                button.Click += (sender, e) => {
                    PopulatePlayerData(player);

                    _selectedPlayer = player;
                };

                playerList.Controls.Add(button);
            }

            PopulatePlayerData(players[0]);
        }

        private void PopulatePlayerData(Player selectedPlayer) {
            playerNameInput.Text = selectedPlayer.Name;
            positionInput.Text = selectedPlayer.Position;
            idnpInput.Text = selectedPlayer.Idnp;
            birthdayInput.Value = selectedPlayer.Birthday;
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

        private void newPlayerButton_Click(object sender, EventArgs e) {
            NewPlayerWindow newPlayerWindow = new NewPlayerWindow();

            newPlayerWindow.ShowDialog();

            if (newPlayerWindow.DialogResult != DialogResult.OK) {
                return;
            }

            Team selectedTeam = _teamRepository.Teams[teamSelect.SelectedIndex];

            _teamRepository.CreatePlayer(newPlayerWindow.NewPlayerName, newPlayerWindow.NewPlayerPosition,
                newPlayerWindow.NewPlayerIdnp, newPlayerWindow.NewPlayerBirthday, selectedTeam,
                player => {
                    PopulatePlayers(teamSelect.SelectedIndex);
                    PopulatePlayerData(player);
                });
        }

        private void savePlayerDataButton_Click(object sender, EventArgs e) {
            if (_selectedPlayer == null) {
                return;
            }

            string name = playerNameInput.Text.Trim();
            string position = positionInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(name)) {
                MessageBox.Show("Introdu numele jucătorului.");
                playerNameInput.Focus();

                return;
            }

            if (string.IsNullOrWhiteSpace(position)) {
                MessageBox.Show("Introdu poziția jucătorului.");
                positionInput.Focus();

                return;
            }

            if (idnpInput.Text.Length != 13 || !idnpInput.Text.All(char.IsDigit)) {
                MessageBox.Show("IDNP-ul trebuie să conțină exact 13 cifre.");
                idnpInput.Focus();

                return;
            }

            bool skipPlayerListRerender = playerNameInput.Text == _selectedPlayer.Name;

            _teamRepository.UpdatePlayer(_selectedPlayer, _teamRepository.Teams[teamSelect.SelectedIndex],
                playerNameInput.Text, positionInput.Text, idnpInput.Text, birthdayInput.Value,
                skipPlayerListRerender ? null : () => { PopulatePlayers(teamSelect.SelectedIndex); });
        }

        private void deleteTeamButton_Click(object sender, EventArgs e) {
            Team teamToDelete = _teamRepository.Teams[teamSelect.SelectedIndex];
            var confirmDialog =
                MessageBox.Show(
                    $"Sunteti siguri ca doriti sa stergeti echipa \"{teamToDelete.Name}\"?\nActiunea nu poate fi reversata!",
                    "Sigur?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (confirmDialog != DialogResult.OK) {
                return;
            }

            _teamRepository.DeleteTeam(teamToDelete.Id);

            PopulateTeams();
        }
    }
}