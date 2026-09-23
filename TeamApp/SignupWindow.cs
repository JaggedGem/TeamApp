using System;
using System.IO;
using System.Windows.Forms;

namespace TeamApp
{
    public partial class SignupWindow : Form
    {
        public SignupWindow()
        {
            InitializeComponent();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter a username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            
            using (FileStream fs = new FileStream("auth.meta", FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(username);
                writer.Write(PasswordHandler.HashPassword(password));
            }
            
            using (FileStream fs = new FileStream("encryption.meta", FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(username);
                writer.Write(PasswordHandler.HashPassword(password));
            }
        }
    }
}