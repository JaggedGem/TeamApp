using System.ComponentModel;

namespace TeamApp;

partial class NewTeamWindow
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
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
        newTeamName = new System.Windows.Forms.TextBox();
        cancelButton = new System.Windows.Forms.Button();
        addTeamButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(12, 38);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(157, 23);
        label1.TabIndex = 0;
        label1.Text = "Numele echipei";
        // 
        // newTeamName
        // 
        newTeamName.Location = new System.Drawing.Point(12, 64);
        newTeamName.Name = "newTeamName";
        newTeamName.Size = new System.Drawing.Size(332, 23);
        newTeamName.TabIndex = 1;
        // 
        // cancelButton
        // 
        cancelButton.CausesValidation = false;
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        cancelButton.Location = new System.Drawing.Point(188, 127);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(75, 23);
        cancelButton.TabIndex = 2;
        cancelButton.Text = "Anuleaza";
        cancelButton.UseVisualStyleBackColor = true;
        cancelButton.Click += cancelButton_Click;
        // 
        // addTeamButton
        // 
        addTeamButton.Location = new System.Drawing.Point(269, 127);
        addTeamButton.Name = "addTeamButton";
        addTeamButton.Size = new System.Drawing.Size(75, 23);
        addTeamButton.TabIndex = 3;
        addTeamButton.Text = "Adauga";
        addTeamButton.UseVisualStyleBackColor = true;
        addTeamButton.Click += addTeamButton_Click;
        // 
        // NewTeamWindow
        // 
        AcceptButton = addTeamButton;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        CancelButton = cancelButton;
        ClientSize = new System.Drawing.Size(356, 162);
        Controls.Add(addTeamButton);
        Controls.Add(cancelButton);
        Controls.Add(newTeamName);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Adauga Echipa";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button addTeamButton;

    private System.Windows.Forms.TextBox newTeamName;

    private System.Windows.Forms.Label label1;

    #endregion
}