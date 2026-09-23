using System.ComponentModel;

namespace TeamApp
{
    partial class LoginWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new System.Windows.Forms.Label();
            usernameInput = new System.Windows.Forms.TextBox();
            passwordInput = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            loginButton = new System.Windows.Forms.Button();
            dataProgressbar = new System.Windows.Forms.ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            label1.Location = new System.Drawing.Point(150, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // usernameInput
            // 
            usernameInput.Location = new System.Drawing.Point(150, 35);
            usernameInput.Name = "usernameInput";
            usernameInput.Size = new System.Drawing.Size(227, 23);
            usernameInput.TabIndex = 1;
            // 
            // passwordInput
            // 
            passwordInput.Location = new System.Drawing.Point(150, 87);
            passwordInput.Name = "passwordInput";
            passwordInput.Size = new System.Drawing.Size(227, 23);
            passwordInput.TabIndex = 3;
            passwordInput.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            label2.Location = new System.Drawing.Point(150, 61);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(100, 23);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // loginButton
            // 
            loginButton.Location = new System.Drawing.Point(226, 132);
            loginButton.Name = "loginButton";
            loginButton.Size = new System.Drawing.Size(75, 23);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // dataProgressbar
            // 
            dataProgressbar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            dataProgressbar.Location = new System.Drawing.Point(12, 180);
            dataProgressbar.Name = "dataProgressbar";
            dataProgressbar.Size = new System.Drawing.Size(506, 28);
            dataProgressbar.TabIndex = 5;
            dataProgressbar.Visible = false;
            // 
            // LoginWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(530, 245);
            Controls.Add(dataProgressbar);
            Controls.Add(loginButton);
            Controls.Add(passwordInput);
            Controls.Add(label2);
            Controls.Add(usernameInput);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ProgressBar dataProgressbar;

        private System.Windows.Forms.Button loginButton;

        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}