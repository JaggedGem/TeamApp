namespace TeamApp
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            teamSelect = new System.Windows.Forms.ComboBox();
            newTeamButton = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            playerList = new System.Windows.Forms.FlowLayoutPanel();
            playerDetails = new System.Windows.Forms.GroupBox();
            savePlayerDataButton = new System.Windows.Forms.Button();
            birthdayInput = new System.Windows.Forms.DateTimePicker();
            idnpInput = new System.Windows.Forms.TextBox();
            positionInput = new System.Windows.Forms.TextBox();
            playerNameInput = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            newPlayerButton = new System.Windows.Forms.Button();
            playerDetails.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label1.Location = new System.Drawing.Point(28, 26);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Echipa:";
            // 
            // teamSelect
            // 
            teamSelect.FormattingEnabled = true;
            teamSelect.Location = new System.Drawing.Point(93, 26);
            teamSelect.Name = "teamSelect";
            teamSelect.Size = new System.Drawing.Size(150, 23);
            teamSelect.TabIndex = 2;
            teamSelect.SelectedIndexChanged += teamSelect_SelectedIndexChanged;
            // 
            // newTeamButton
            // 
            newTeamButton.Location = new System.Drawing.Point(249, 26);
            newTeamButton.Name = "newTeamButton";
            newTeamButton.Size = new System.Drawing.Size(85, 23);
            newTeamButton.TabIndex = 3;
            newTeamButton.Text = "Echipa Noua";
            newTeamButton.UseVisualStyleBackColor = true;
            newTeamButton.Click += newTeamButton_Click;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            label2.Location = new System.Drawing.Point(75, 83);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(193, 23);
            label2.TabIndex = 4;
            label2.Text = "Nu exista jucatori in aceasta echipa";
            label2.Visible = false;
            // 
            // playerList
            // 
            playerList.AutoScroll = true;
            playerList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            playerList.Location = new System.Drawing.Point(104, 68);
            playerList.Name = "playerList";
            playerList.Size = new System.Drawing.Size(230, 214);
            playerList.TabIndex = 5;
            playerList.WrapContents = false;
            // 
            // playerDetails
            // 
            playerDetails.Controls.Add(savePlayerDataButton);
            playerDetails.Controls.Add(birthdayInput);
            playerDetails.Controls.Add(idnpInput);
            playerDetails.Controls.Add(positionInput);
            playerDetails.Controls.Add(playerNameInput);
            playerDetails.Controls.Add(label6);
            playerDetails.Controls.Add(label5);
            playerDetails.Controls.Add(label4);
            playerDetails.Controls.Add(label3);
            playerDetails.Location = new System.Drawing.Point(340, 68);
            playerDetails.Name = "playerDetails";
            playerDetails.Size = new System.Drawing.Size(281, 214);
            playerDetails.TabIndex = 6;
            playerDetails.TabStop = false;
            playerDetails.Text = "Detalii Jucator";
            // 
            // savePlayerDataButton
            // 
            savePlayerDataButton.Location = new System.Drawing.Point(200, 185);
            savePlayerDataButton.Name = "savePlayerDataButton";
            savePlayerDataButton.Size = new System.Drawing.Size(75, 23);
            savePlayerDataButton.TabIndex = 8;
            savePlayerDataButton.Text = "Save";
            savePlayerDataButton.UseVisualStyleBackColor = true;
            // 
            // birthdayInput
            // 
            birthdayInput.CustomFormat = "dd.MM.yyyy";
            birthdayInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            birthdayInput.Location = new System.Drawing.Point(112, 147);
            birthdayInput.Name = "birthdayInput";
            birthdayInput.Size = new System.Drawing.Size(163, 23);
            birthdayInput.TabIndex = 7;
            birthdayInput.Value = new System.DateTime(2026, 9, 24, 16, 31, 38, 921);
            // 
            // idnpInput
            // 
            idnpInput.Location = new System.Drawing.Point(112, 100);
            idnpInput.Name = "idnpInput";
            idnpInput.Size = new System.Drawing.Size(163, 23);
            idnpInput.TabIndex = 6;
            // 
            // positionInput
            // 
            positionInput.Location = new System.Drawing.Point(112, 59);
            positionInput.Name = "positionInput";
            positionInput.Size = new System.Drawing.Size(163, 23);
            positionInput.TabIndex = 5;
            // 
            // playerNameInput
            // 
            playerNameInput.Location = new System.Drawing.Point(112, 19);
            playerNameInput.Name = "playerNameInput";
            playerNameInput.Size = new System.Drawing.Size(163, 23);
            playerNameInput.TabIndex = 4;
            // 
            // label6
            // 
            label6.Location = new System.Drawing.Point(6, 153);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(100, 23);
            label6.TabIndex = 3;
            label6.Text = "Data Nasterii";
            label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(6, 103);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(100, 23);
            label5.TabIndex = 2;
            label5.Text = "IDNP";
            label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(6, 59);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(100, 23);
            label4.TabIndex = 1;
            label4.Text = "Post";
            label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(6, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(100, 23);
            label3.TabIndex = 0;
            label3.Text = "Nume";
            label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // newPlayerButton
            // 
            newPlayerButton.Location = new System.Drawing.Point(249, 288);
            newPlayerButton.Name = "newPlayerButton";
            newPlayerButton.Size = new System.Drawing.Size(85, 23);
            newPlayerButton.TabIndex = 7;
            newPlayerButton.Text = "Jucator Nou";
            newPlayerButton.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(636, 333);
            Controls.Add(newPlayerButton);
            Controls.Add(playerDetails);
            Controls.Add(newTeamButton);
            Controls.Add(teamSelect);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(playerList);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Text = "Team App";
            playerDetails.ResumeLayout(false);
            playerDetails.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button savePlayerDataButton;

        private System.Windows.Forms.Button newPlayerButton;

        private System.Windows.Forms.DateTimePicker birthdayInput;

        private System.Windows.Forms.TextBox idnpInput;

        private System.Windows.Forms.TextBox positionInput;

        private System.Windows.Forms.TextBox playerNameInput;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.GroupBox playerDetails;

        private System.Windows.Forms.FlowLayoutPanel playerList;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button newTeamButton;

        private System.Windows.Forms.ComboBox teamSelect;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}