using System.ComponentModel;

namespace TeamApp
{
    partial class SignupWindow
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
            usernameLabel = new System.Windows.Forms.Label();
            usernameInput = new System.Windows.Forms.TextBox();
            passwordInput = new System.Windows.Forms.TextBox();
            passwordLabel = new System.Windows.Forms.Label();
            signupButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            usernameLabel.Location = new System.Drawing.Point(113, 39);
            usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(117, 27);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "Username";
            // 
            // usernameInput
            // 
            usernameInput.Location = new System.Drawing.Point(113, 69);
            usernameInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            usernameInput.Name = "usernameInput";
            usernameInput.Size = new System.Drawing.Size(307, 23);
            usernameInput.TabIndex = 1;
            // 
            // passwordInput
            // 
            passwordInput.Location = new System.Drawing.Point(113, 125);
            passwordInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            passwordInput.Name = "passwordInput";
            passwordInput.PasswordChar = '*';
            passwordInput.Size = new System.Drawing.Size(307, 23);
            passwordInput.TabIndex = 3;
            passwordInput.UseSystemPasswordChar = true;
            passwordInput.WordWrap = false;
            // 
            // passwordLabel
            // 
            passwordLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            passwordLabel.Location = new System.Drawing.Point(113, 95);
            passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(117, 27);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Password";
            // 
            // signupButton
            // 
            signupButton.Location = new System.Drawing.Point(222, 182);
            signupButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            signupButton.Name = "signupButton";
            signupButton.Size = new System.Drawing.Size(88, 27);
            signupButton.TabIndex = 4;
            signupButton.Text = "Signup";
            signupButton.UseVisualStyleBackColor = true;
            signupButton.Click += signupButton_Click;
            // 
            // SignupWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(530, 245);
            Controls.Add(signupButton);
            Controls.Add(passwordInput);
            Controls.Add(passwordLabel);
            Controls.Add(usernameInput);
            Controls.Add(usernameLabel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Text = "Sign up";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button signupButton;

        #endregion
    }
}