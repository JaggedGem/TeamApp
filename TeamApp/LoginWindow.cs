using System.Text;

namespace TeamApp
{
    public partial class LoginWindow : Form
    {
        private string? _cachedUsername;
        private string? _cachedPasswordHash;

        private byte[]? _cachedEncryptionSalt;
        private byte[]? _cachedNonce;
        private byte[]? _cachedEncryptedMasterKey;
        private byte[]? _cachedTag;

        private readonly List<Team> _teams = new();
        public TeamRepository TeamRepository;

        public LoginWindow() {
            InitializeComponent();

            LoadAuthData();
            LoadEncryptionData();
        }

        private void LoadAuthData() {
            if (!File.Exists("auth.meta")) {
                MessageBox.Show("No auth file found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return;
            }

            using (FileStream fs = new FileStream("auth.meta", FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs)) {
                _cachedUsername = reader.ReadString();
                _cachedPasswordHash = reader.ReadString();
            }
        }

        private void LoadEncryptionData() {
            if (!File.Exists("encryption.meta")) {
                MessageBox.Show("No encryption file found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return;
            }

            using (FileStream fs = new FileStream("encryption.meta", FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs)) {
                _cachedEncryptionSalt = reader.ReadBytes(reader.ReadInt32());
                _cachedNonce = reader.ReadBytes(reader.ReadInt32());
                _cachedEncryptedMasterKey = reader.ReadBytes(reader.ReadInt32());
                _cachedTag = reader.ReadBytes(reader.ReadInt32());
            }
        }

        private bool checkCredentials(string username, string password) {
            if (username == _cachedUsername && SecureHandler.VerifyPassword(password, _cachedPasswordHash ?? "")) {
                return true;
            }

            return false;
        }

        private void LoadData(byte[] masterKey, IProgress<int> progress) {
            const int discoveryEnd = 20;
            const int processingStart = 20;
            const int processingEnd = 100;

            string teamsDirectory = Path.Combine("data", "teams");

            if (!Directory.Exists(teamsDirectory)) {
                Directory.CreateDirectory(teamsDirectory);
                progress.Report(100);

                return;
            }

            // Discover folders
            string[] dataFolders = Directory.GetDirectories(teamsDirectory);

            progress.Report(discoveryEnd);

            // Count total entries so processing progress can be accurate
            int totalEntries = 0;

            foreach (string dataFolder in dataFolders) {
                totalEntries += Directory.GetFiles(Path.Combine(dataFolder, "players"), "*.player").Length + 1;
            }

            if (totalEntries == 0) {
                progress.Report(100);

                return;
            }

            int processedEntries = 0;

            // Process folders
            foreach (string dataFolder in dataFolders) {
                string name;
                List<Player> players = new List<Player>();

                using (FileStream fs = new FileStream(Path.Combine(dataFolder, "team.meta"), FileMode.Open,
                           FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs)) {
                    byte[] nonce = reader.ReadBytes(reader.ReadInt32());
                    byte[] ciphertext = reader.ReadBytes(reader.ReadInt32());
                    byte[] tag = reader.ReadBytes(reader.ReadInt32());

                    name = Encoding.UTF8.GetString(
                        SecureHandler.Decrypt(masterKey, nonce, ciphertext, tag)
                    );
                }

                processedEntries++;

                int progressValue = processingStart +
                                    (int)((double)processedEntries / totalEntries *
                                          (processingEnd - processingStart));

                progress.Report(progressValue);

                foreach (string dataFile in Directory.GetFiles(Path.Combine(dataFolder, "players"), "*.player")) {
                    using (FileStream fs = new FileStream(dataFile, FileMode.Open, FileAccess.Read))
                    using (BinaryReader reader = new BinaryReader(fs)) {
                        byte[] nonce = reader.ReadBytes(reader.ReadInt32());
                        byte[] ciphertext = reader.ReadBytes(reader.ReadInt32());
                        byte[] tag = reader.ReadBytes(reader.ReadInt32());

                        byte[] decryptedData = SecureHandler.Decrypt(
                            masterKey,
                            nonce,
                            ciphertext,
                            tag
                        );

                        using MemoryStream ms = new MemoryStream(decryptedData);
                        using BinaryReader decryptedReader = new BinaryReader(ms);

                        string playerName = decryptedReader.ReadString();
                        string playerRole = decryptedReader.ReadString();
                        int idnp = decryptedReader.ReadInt32();
                        int year = decryptedReader.ReadInt32();
                        int month = decryptedReader.ReadInt32();
                        int day = decryptedReader.ReadInt32();

                        players.Add(
                            new Player(
                                playerName,
                                playerRole,
                                idnp,
                                new DateTime(year, month, day),
                                Guid.Parse(Path.GetFileNameWithoutExtension(dataFile))
                            )
                        );
                    }

                    processedEntries++;

                    progressValue = processingStart +
                                    (int)((double)processedEntries / totalEntries *
                                          (processingEnd - processingStart));

                    progress.Report(progressValue);
                }

                _teams.Add(new Team(name, players, Guid.Parse(Path.GetFileName(dataFolder))));
            }
        }

        private async void loginButton_Click(object sender, EventArgs e) {
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            byte[] masterKey;
            if (checkCredentials(username, password)) {
                masterKey = SecureHandler.Decrypt(SecureHandler.GenerateEncryptionKey(password, _cachedEncryptionSalt),
                    _cachedNonce, _cachedEncryptedMasterKey, _cachedTag);
            }
            else {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dataProgressbar.Visible = true;

            var progress = new Progress<int>(value => { dataProgressbar.Value = value; });

            await Task.Run(() => LoadData(masterKey, progress));

            dataProgressbar.Value = 100;

            TeamRepository = new TeamRepository(masterKey, _teams);

            await Task.Delay(500);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}