namespace ProjektStatki.Views
{
    partial class PlayerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerView));
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label4 = new Label();
            label1 = new Label();
            label5 = new Label();
            button5 = new Button();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.person_24dp_5F6368_FILL0_wght400_GRAD0_opsz24__1_;
            pictureBox1.Location = new Point(829, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(93, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(829, 105);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(93, 14);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16F);
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(144, 100);
            button1.TabIndex = 2;
            button1.Text = "Graj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 16F);
            button2.Location = new Point(162, 12);
            button2.Name = "button2";
            button2.Size = new Size(144, 100);
            button2.TabIndex = 3;
            button2.Text = "Wyświetl Historię Gier";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 16F);
            button4.Location = new Point(162, 122);
            button4.Name = "button4";
            button4.Size = new Size(144, 100);
            button4.TabIndex = 5;
            button4.Text = "Wyświetl Dodatkową Zawartość";
            button4.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = Properties.Resources.settings_24dp_5F6368_FILL0_wght400_GRAD0_opsz24__1_;
            pictureBox2.Location = new Point(755, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(31, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(829, 12);
            label2.Name = "label2";
            label2.Size = new Size(58, 23);
            label2.TabIndex = 10;
            label2.Text = "nazwa";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Location = new Point(2, 4);
            label3.Name = "label3";
            label3.Size = new Size(535, 239);
            label3.TabIndex = 11;
            label3.Text = resources.GetString("label3.Text");
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label3);
            panel1.Location = new Point(383, 207);
            panel1.Name = "panel1";
            panel1.Size = new Size(539, 248);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label4);
            panel2.Location = new Point(383, 174);
            panel2.Name = "panel2";
            panel2.Size = new Size(539, 32);
            panel2.TabIndex = 13;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(-2, 5);
            label4.Name = "label4";
            label4.Size = new Size(535, 23);
            label4.TabIndex = 11;
            label4.Text = "Ciekawostki na ten tydzień";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(888, 12);
            label1.Name = "label1";
            label1.Size = new Size(34, 23);
            label1.TabIndex = 14;
            label1.Text = "lv";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Location = new Point(829, 122);
            label5.Name = "label5";
            label5.Size = new Size(93, 16);
            label5.TabIndex = 15;
            label5.Text = "Do kolejnego lv";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 16F);
            button5.Location = new Point(12, 122);
            button5.Name = "button5";
            button5.Size = new Size(144, 100);
            button5.TabIndex = 16;
            button5.Text = "Wyświetl Ranking Graczy";
            button5.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Image = Properties.Resources.logout_24dp_5F6368_FILL0_wght400_GRAD0_opsz24__1_;
            pictureBox3.Location = new Point(792, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(31, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // PlayerView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 467);
            Controls.Add(pictureBox3);
            Controls.Add(button5);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Name = "PlayerView";
            Text = "BattleshipClient";
            Load += PlayerView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ProgressBar progressBar1;
        private Button button1;
        private Button button2;
        private Button button4;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private Label label4;
        private Label label1;
        private Label label5;
        private Button button5;
        private PictureBox pictureBox3;
    }
}