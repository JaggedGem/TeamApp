namespace TeamApp
{
    public partial class SignupWindow : Form
    {
        public SignupWindow() {
            InitializeComponent();
        }

        private void signupButton_Click(object sender, EventArgs e) {
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            if (username == "" || password == "") {
                MessageBox.Show("Please enter a username and password", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            byte[] masterKey = SecureHandler.GenerateMasterKey();

            using (FileStream fs = new FileStream("./auth.meta", FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs)) {
                writer.Write(username);
                writer.Write(SecureHandler.HashPassword(password));
            }

            using (FileStream fs = new FileStream("./encryption.meta", FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs)) {
                (byte[] encryptionSalt, byte[] keyEncryptionKey) = SecureHandler.GenerateEncryptionKey(password);

                (byte[] nonce, byte[] encryptedMasterKey, byte[] tag) =
                    SecureHandler.Encrypt(keyEncryptionKey, masterKey);

                writer.Write(encryptionSalt.Length);
                writer.Write(encryptionSalt);

                writer.Write(nonce.Length);
                writer.Write(nonce);

                writer.Write(encryptedMasterKey.Length);
                writer.Write(encryptedMasterKey);

                writer.Write(tag.Length);
                writer.Write(tag);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}