namespace ProjektStatki.Views
{
    partial class ChooseGameModeView
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            button1 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(281, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(252, 366);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(0, 19);
            label1.Name = "label1";
            label1.Size = new Size(252, 23);
            label1.TabIndex = 1;
            label1.Text = "Nazwa Trybu Gry";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.AI;
            pictureBox1.Location = new Point(0, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(252, 127);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 14F);
            label2.ImageAlign = ContentAlignment.TopCenter;
            label2.Location = new Point(0, 163);
            label2.Name = "label2";
            label2.Size = new Size(252, 23);
            label2.TabIndex = 2;
            label2.Text = "Zasady";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(0, 186);
            label3.Name = "label3";
            label3.Size = new Size(252, 178);
            label3.TabIndex = 3;
            label3.Text = "OpisTrybu";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.arrow_forward_ios_24dp_5F6368_FILL0_wght400_GRAD0_opsz24;
            pictureBox2.Location = new Point(119, 164);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(97, 94);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.arrow_back_ios_new_24dp_5F6368_FILL0_wght400_GRAD0_opsz24;
            pictureBox3.Location = new Point(590, 164);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(97, 94);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(339, 384);
            button1.Name = "button1";
            button1.Size = new Size(147, 35);
            button1.TabIndex = 3;
            button1.Text = "Zatwierdź";
            button1.UseVisualStyleBackColor = true;
            // 
            // ChooseGameModeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(groupBox1);
            Name = "ChooseGameModeView";
            Text = "ChooseGameModeView";
            Load += ChooseGameModeView_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button button1;
    }
}