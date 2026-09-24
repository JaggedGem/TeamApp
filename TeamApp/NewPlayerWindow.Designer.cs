using System.ComponentModel;

namespace TeamApp;

partial class NewPlayerWindow
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
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        addPlayerButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        nameInput = new System.Windows.Forms.TextBox();
        positionInput = new System.Windows.Forms.TextBox();
        idnpInput = new System.Windows.Forms.TextBox();
        birthdayInput = new System.Windows.Forms.DateTimePicker();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(12, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 0;
        label1.Text = "Nume";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.Location = new System.Drawing.Point(12, 70);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 1;
        label2.Text = "Post";
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.Location = new System.Drawing.Point(12, 128);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(100, 23);
        label3.TabIndex = 2;
        label3.Text = "IDNP";
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.Location = new System.Drawing.Point(12, 190);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(100, 23);
        label4.TabIndex = 3;
        label4.Text = "Data Nasterii";
        // 
        // addPlayerButton
        // 
        addPlayerButton.DialogResult = System.Windows.Forms.DialogResult.OK;
        addPlayerButton.Location = new System.Drawing.Point(248, 270);
        addPlayerButton.Name = "addPlayerButton";
        addPlayerButton.Size = new System.Drawing.Size(75, 23);
        addPlayerButton.TabIndex = 4;
        addPlayerButton.Text = "Adauga";
        addPlayerButton.UseVisualStyleBackColor = true;
        addPlayerButton.Click += addPlayerButton_Click;
        // 
        // cancelButton
        // 
        cancelButton.CausesValidation = false;
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        cancelButton.Location = new System.Drawing.Point(167, 270);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(75, 23);
        cancelButton.TabIndex = 5;
        cancelButton.Text = "Anuleaza";
        cancelButton.UseVisualStyleBackColor = true;
        // 
        // nameInput
        // 
        nameInput.Location = new System.Drawing.Point(12, 35);
        nameInput.Name = "nameInput";
        nameInput.Size = new System.Drawing.Size(292, 23);
        nameInput.TabIndex = 6;
        nameInput.WordWrap = false;
        // 
        // positionInput
        // 
        positionInput.Location = new System.Drawing.Point(12, 96);
        positionInput.Name = "positionInput";
        positionInput.Size = new System.Drawing.Size(292, 23);
        positionInput.TabIndex = 7;
        positionInput.WordWrap = false;
        // 
        // idnpInput
        // 
        idnpInput.Location = new System.Drawing.Point(12, 154);
        idnpInput.MaxLength = 13;
        idnpInput.Name = "idnpInput";
        idnpInput.Size = new System.Drawing.Size(292, 23);
        idnpInput.TabIndex = 8;
        idnpInput.WordWrap = false;
        // 
        // birthdayInput
        // 
        birthdayInput.CustomFormat = "dd.MM.yyyy";
        birthdayInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        birthdayInput.Location = new System.Drawing.Point(12, 216);
        birthdayInput.Name = "birthdayInput";
        birthdayInput.Size = new System.Drawing.Size(292, 23);
        birthdayInput.TabIndex = 7;
        birthdayInput.Value = new System.DateTime(2026, 9, 24, 22, 55, 31, 237);
        // 
        // NewPlayerWindow
        // 
        AcceptButton = addPlayerButton;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        CancelButton = cancelButton;
        ClientSize = new System.Drawing.Size(335, 305);
        Controls.Add(birthdayInput);
        Controls.Add(idnpInput);
        Controls.Add(positionInput);
        Controls.Add(nameInput);
        Controls.Add(cancelButton);
        Controls.Add(addPlayerButton);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Adauga Jucator";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.DateTimePicker birthdayInput;

    private System.Windows.Forms.TextBox nameInput;
    private System.Windows.Forms.TextBox positionInput;
    private System.Windows.Forms.TextBox idnpInput;

    private System.Windows.Forms.Button cancelButton;

    private System.Windows.Forms.Button addPlayerButton;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;

    #endregion
}