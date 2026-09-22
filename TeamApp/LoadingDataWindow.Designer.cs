using System.ComponentModel;

namespace TeamApp
{
    partial class LoadingDataWindow
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
        private void InitializeComponent()
        {
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // loadingBar
            // 
            this.loadingBar.Location = new System.Drawing.Point(12, 87);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(430, 23);
            this.loadingBar.TabIndex = 0;
            this.loadingBar.UseWaitCursor = true;
            // 
            // LoadingDataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 212);
            this.Controls.Add(this.loadingBar);
            this.Name = "LoadingDataWindow";
            this.Text = "LoadingDataWindow";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ProgressBar loadingBar;

        #endregion
    }
}