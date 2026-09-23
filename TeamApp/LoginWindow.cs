using System.Text;

namespace TeamApp
{
    public partial class LoginWindow : Form
    {
        private string? cachedUsername;
        private string? cachedPasswordHash;

        private byte[]? cachedEncryptionSalt;
        private byte[]? cachedNonce;
        private byte[]? cachedEncryptedMasterKey;
        private byte[]? cachedTag;

        public List<Team> Teams { get; private set; } = new List<Team>();

        public LoginWindow() {
            InitializeComponent();

            LoadAuthData();
            LoadEncryptionData();
        }

        private void LoadAuthData() {
            if (!File.Exists("./auth.meta")) {
                MessageBox.Show("No auth file found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return;
            }

            using (FileStream fs = new FileStream("./auth.meta", FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs)) {
                cachedUsername = reader.ReadString();
                cachedPasswordHash = reader.ReadString();
            }
        }

        private void LoadEncryptionData() {
            if (!File.Exists("./encryption.meta")) {
                MessageBox.Show("No encryption file found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return;
            }

            using (FileStream fs = new FileStream("./encryption.meta", FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs)) {
                cachedEncryptionSalt = reader.ReadBytes(reader.ReadInt32());
                cachedNonce = reader.ReadBytes(reader.ReadInt32());
                cachedEncryptedMasterKey = reader.ReadBytes(reader.ReadInt32());
                cachedTag = reader.ReadBytes(reader.ReadInt32());
            }
        }

        private bool checkCredentials(string username, string password) {
            if (username == cachedUsername && SecureHandler.VerifyPassword(password, cachedPasswordHash ?? "")) {
                return true;
            }

            return false;
        }

        private void LoadData(byte[] masterKey, IProgress<int> progress) {
            const int discoveryEnd = 20;
            const int processingStart = 20;
            const int processingEnd = 100;

            if (!Directory.Exists("./data")) {
                Directory.CreateDirectory("./data");
                progress.Report(100);

                return;
            }

            // Discover folders
            string[] dataFolders = Directory.GetDirectories("./data");

            progress.Report(discoveryEnd);

            // Count total entries so processing progress can be accurate
            int totalEntries = 0;

            foreach (string dataFolder in dataFolders) {
                totalEntries += Directory.GetFiles(dataFolder, "*.tamp").Length;
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

                using (FileStream fs = new FileStream(Path.Combine(dataFolder, "teamInfo.meta"), FileMode.Open,
                           FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs)) {
                    byte[] nonce = reader.ReadBytes(reader.ReadInt32());
                    byte[] ciphertext = reader.ReadBytes(reader.ReadInt32());
                    byte[] tag = reader.ReadBytes(reader.ReadInt32());

                    name = Encoding.UTF8.GetString(
                        SecureHandler.Decrypt(masterKey, nonce, ciphertext, tag)
                    );
                }

                foreach (string dataFile in Directory.GetFiles(dataFolder, "*.tamp")) {
                    using (FileStream fs = new FileStream(Path.Combine(dataFolder, dataFile), FileMode.Open,
                               FileAccess.Read))
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
                                new DateTime(year, month, day)
                            )
                        );
                    }

                    processedEntries++;

                    int progressValue = processingStart +
                                        (int)((double)processedEntries / totalEntries *
                                              (processingEnd - processingStart));

                    progress.Report(progressValue);
                }

                Teams.Add(new Team(name, players));
            }
        }

        private async void loginButton_Click(object sender, EventArgs e) {
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            byte[] masterKey;
            if (checkCredentials(username, password)) {
                masterKey = SecureHandler.Decrypt(SecureHandler.GenerateEncryptionKey(password, cachedEncryptionSalt),
                    cachedNonce, cachedEncryptedMasterKey, cachedTag);
            }
            else {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dataProgressbar.Visible = true;

            var progress = new Progress<int>(value => { dataProgressbar.Value = value; });

            await Task.Run(() => LoadData(masterKey, progress));

            dataProgressbar.Value = 100;

            await Task.Delay(500);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}