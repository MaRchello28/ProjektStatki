namespace ProjektStatki.Views
{
    partial class SettingsView
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
        private void InitializeComponent()
        {
            volumeTrackBar = new TrackBar();
            nameLabel = new Label();
            ratingLabel = new Label();
            levelLabel = new Label();
            expLabel = new Label();
            volumeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)volumeTrackBar).BeginInit();
            SuspendLayout();
            // 
            // volumeTrackBar
            // 
            volumeTrackBar.Location = new Point(12, 12);
            volumeTrackBar.Maximum = 100;
            volumeTrackBar.Name = "volumeTrackBar";
            volumeTrackBar.Size = new Size(305, 56);
            volumeTrackBar.TabIndex = 0;
            volumeTrackBar.TickFrequency = 10;
            volumeTrackBar.Value = 50;
            volumeTrackBar.Scroll += volumeTrackBar_Scroll;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            nameLabel.Location = new Point(12, 92);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(226, 24);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Nazwa gracza: [nazwa]";
            // 
            // ratingLabel
            // 
            ratingLabel.AutoSize = true;
            ratingLabel.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ratingLabel.Location = new Point(12, 129);
            ratingLabel.Name = "ratingLabel";
            ratingLabel.Size = new Size(185, 22);
            ratingLabel.TabIndex = 2;
            ratingLabel.Text = "Punkty rankingowe: [punkty]";
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            levelLabel.Location = new Point(12, 169);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(121, 22);
            levelLabel.TabIndex = 3;
            levelLabel.Text = "Poziom: [poziom]";
            // 
            // expLabel
            // 
            expLabel.AutoSize = true;
            expLabel.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            expLabel.Location = new Point(12, 213);
            expLabel.Name = "expLabel";
            expLabel.Size = new Size(322, 22);
            expLabel.TabIndex = 4;
            expLabel.Text = "Doświadczenie: [aktualne_exp] / [do_następnego]";
            // 
            // volumeLabel
            // 
            volumeLabel.AutoSize = true;
            volumeLabel.Location = new Point(107, 62);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(103, 20);
            volumeLabel.TabIndex = 5;
            volumeLabel.Text = "Głośność: 50%";
            volumeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SettingsView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 270);
            Controls.Add(volumeLabel);
            Controls.Add(expLabel);
            Controls.Add(levelLabel);
            Controls.Add(ratingLabel);
            Controls.Add(nameLabel);
            Controls.Add(volumeTrackBar);
            Name = "SettingsView";
            Text = "SettingsView";
            ((System.ComponentModel.ISupportInitialize)volumeTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar volumeTrackBar;
        private Label nameLabel;
        private Label ratingLabel;
        private Label levelLabel;
        private Label expLabel;
        private Label volumeLabel;
    }
}