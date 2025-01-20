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
            volumeTrackBar.Location = new Point(10, 9);
            volumeTrackBar.Margin = new Padding(3, 2, 3, 2);
            volumeTrackBar.Maximum = 100;
            volumeTrackBar.Name = "volumeTrackBar";
            volumeTrackBar.Size = new Size(267, 45);
            volumeTrackBar.TabIndex = 0;
            volumeTrackBar.TickFrequency = 10;
            volumeTrackBar.Value = 50;
            volumeTrackBar.Scroll += volumeTrackBar_Scroll;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            nameLabel.Location = new Point(10, 69);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(187, 19);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Nazwa gracza: [nazwa]";
            // 
            // ratingLabel
            // 
            ratingLabel.AutoSize = true;
            ratingLabel.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ratingLabel.Location = new Point(10, 97);
            ratingLabel.Name = "ratingLabel";
            ratingLabel.Size = new Size(185, 17);
            ratingLabel.TabIndex = 2;
            ratingLabel.Text = "Punkty rankingowe: [punkty]";
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            levelLabel.Location = new Point(10, 127);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(115, 17);
            levelLabel.TabIndex = 3;
            levelLabel.Text = "Poziom: [poziom]";
            // 
            // expLabel
            // 
            expLabel.AutoSize = true;
            expLabel.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            expLabel.Location = new Point(10, 160);
            expLabel.Name = "expLabel";
            expLabel.Size = new Size(321, 17);
            expLabel.TabIndex = 4;
            expLabel.Text = "Doświadczenie: [aktualne_exp] / [do_następnego]";
            // 
            // volumeLabel
            // 
            volumeLabel.AutoSize = true;
            volumeLabel.Location = new Point(94, 46);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(83, 15);
            volumeLabel.TabIndex = 5;
            volumeLabel.Text = "Głośność: 50%";
            volumeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SettingsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 202);
            Controls.Add(volumeLabel);
            Controls.Add(expLabel);
            Controls.Add(levelLabel);
            Controls.Add(ratingLabel);
            Controls.Add(nameLabel);
            Controls.Add(volumeTrackBar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SettingsView";
            Text = "SettingsView";
            Load += SettingsView_Load;
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