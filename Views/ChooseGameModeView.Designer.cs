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
            TreeNode treeNode1 = new TreeNode("Nie rankingowa");
            TreeNode treeNode2 = new TreeNode("Rankingowa");
            TreeNode treeNode3 = new TreeNode("Zwykła", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("Tryb Symulacji");
            TreeNode treeNode5 = new TreeNode("SpecjalneStatki");
            TreeNode treeNode6 = new TreeNode("Specjalne", new TreeNode[] { treeNode4, treeNode5 });
            TreeNode treeNode7 = new TreeNode("Gracz vs AI");
            TreeNode treeNode8 = new TreeNode("Stwórz Własną");
            TreeNode treeNode9 = new TreeNode("Customowe", new TreeNode[] { treeNode7, treeNode8 });
            button1 = new Button();
            treeView1 = new TreeView();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            panel1 = new Panel();
            textBox3 = new TextBox();
            label14 = new Label();
            label12 = new Label();
            textBox1 = new TextBox();
            checkBox1 = new CheckBox();
            panel2 = new Panel();
            textBox4 = new TextBox();
            label15 = new Label();
            label13 = new Label();
            checkBox2 = new CheckBox();
            textBox2 = new TextBox();
            panel6 = new Panel();
            label11 = new Label();
            numericUpDown6 = new NumericUpDown();
            panel5 = new Panel();
            label7 = new Label();
            numericUpDown3 = new NumericUpDown();
            panel3 = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            label9 = new Label();
            label10 = new Label();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(269, 459);
            button1.Name = "button1";
            button1.Size = new Size(147, 35);
            button1.TabIndex = 3;
            button1.Text = "Zatwierdź";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // treeView1
            // 
            treeView1.Font = new Font("Segoe UI", 14F);
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeNode1.Name = "nieRankingowa";
            treeNode1.Text = "Nie rankingowa";
            treeNode2.Name = "rankingowa";
            treeNode2.Text = "Rankingowa";
            treeNode3.Name = "normal";
            treeNode3.Text = "Zwykła";
            treeNode4.Name = "trybSymulacji";
            treeNode4.Text = "Tryb Symulacji";
            treeNode5.Name = "specjalneStatki";
            treeNode5.Text = "SpecjalneStatki";
            treeNode6.Name = "specjalne";
            treeNode6.Text = "Specjalne";
            treeNode7.Name = "graczVsAI";
            treeNode7.Text = "Gracz vs AI";
            treeNode8.Name = "stwórzWłasną";
            treeNode8.Text = "Stwórz Własną";
            treeNode9.Name = "custom";
            treeNode9.Text = "Customowe";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode6, treeNode9 });
            treeView1.Size = new Size(194, 441);
            treeView1.TabIndex = 4;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(247, 34);
            label1.TabIndex = 0;
            label1.Text = "Nazwa Trybu Gry";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(3, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(247, 129);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(3, 178);
            label2.Name = "label2";
            label2.Size = new Size(247, 161);
            label2.TabIndex = 2;
            label2.Text = "Zasady";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(212, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(256, 441);
            panel1.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(3, 402);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(124, 23);
            textBox3.TabIndex = 7;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(3, 384);
            label14.Name = "label14";
            label14.Size = new Size(133, 15);
            label14.TabIndex = 6;
            label14.Text = "Podaj hasło przeciwnika";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(3, 339);
            label12.Name = "label12";
            label12.Size = new Size(135, 15);
            label12.TabIndex = 5;
            label12.Text = "Podaj login przeciwnika ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 357);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(124, 23);
            textBox1.TabIndex = 4;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(133, 417);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(118, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Użyj konta gościa";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(checkBox2);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(502, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(256, 441);
            panel2.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 402);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(121, 23);
            textBox4.TabIndex = 8;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 384);
            label15.Name = "label15";
            label15.Size = new Size(133, 15);
            label15.TabIndex = 8;
            label15.Text = "Podaj hasło przeciwnika";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(5, 339);
            label13.Name = "label13";
            label13.Size = new Size(135, 15);
            label13.TabIndex = 8;
            label13.Text = "Podaj login przeciwnika ";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(133, 417);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(118, 19);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "Użyj konta gościa";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(5, 357);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(123, 23);
            textBox2.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(label11);
            panel6.Controls.Add(numericUpDown6);
            panel6.Location = new Point(1, 182);
            panel6.Name = "panel6";
            panel6.Size = new Size(254, 59);
            panel6.TabIndex = 11;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 10F);
            label11.Location = new Point(3, 9);
            label11.Name = "label11";
            label11.Size = new Size(154, 43);
            label11.TabIndex = 6;
            label11.Text = "Wybierz llcizbę statków specjalnych:";
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(170, 20);
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(82, 23);
            numericUpDown6.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(label7);
            panel5.Controls.Add(numericUpDown3);
            panel5.Location = new Point(2, 143);
            panel5.Name = "panel5";
            panel5.Size = new Size(254, 43);
            panel5.TabIndex = 10;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(3, 9);
            label7.Name = "label7";
            label7.Size = new Size(154, 21);
            label7.TabIndex = 6;
            label7.Text = "Wybierz llcizbę statków:";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(170, 9);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(82, 23);
            numericUpDown3.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(numericUpDown2);
            panel3.Controls.Add(numericUpDown1);
            panel3.Location = new Point(2, 51);
            panel3.Name = "panel3";
            panel3.Size = new Size(254, 92);
            panel3.TabIndex = 9;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(numericUpDown4);
            panel4.Controls.Add(numericUpDown5);
            panel4.Location = new Point(-1, -1);
            panel4.Name = "panel4";
            panel4.Size = new Size(254, 92);
            panel4.TabIndex = 10;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(1, 5);
            label3.Name = "label3";
            label3.Size = new Size(162, 21);
            label3.TabIndex = 8;
            label3.Text = "Wybierz rozmiar planszy:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(181, 73);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 5;
            label9.Text = "wysokość";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(181, 29);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 4;
            label10.Text = "szerokość";
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(169, 47);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(82, 23);
            numericUpDown4.TabIndex = 3;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(169, 3);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(82, 23);
            numericUpDown5.TabIndex = 2;
            numericUpDown5.ValueChanged += numericUpDown5_ValueChanged;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(1, 5);
            label8.Name = "label8";
            label8.Size = new Size(162, 21);
            label8.TabIndex = 8;
            label8.Text = "Wybierz rozmiar planszy:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(181, 73);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 5;
            label6.Text = "wysokość";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(181, 29);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 4;
            label5.Text = "szerokość";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(169, 47);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(82, 23);
            numericUpDown2.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(169, 3);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(82, 23);
            numericUpDown1.TabIndex = 2;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(3, 9);
            label4.Name = "label4";
            label4.Size = new Size(247, 34);
            label4.TabIndex = 0;
            label4.Text = "Custom";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChooseGameModeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 506);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(treeView1);
            Controls.Add(button1);
            Name = "ChooseGameModeView";
            Text = "ChooseGameModeView";
            Load += ChooseGameModeView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private TreeView treeView1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel panel1;
        private Panel panel2;
        private Label label4;
        private Label label6;
        private Label label5;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Label label7;
        private Label label8;
        private NumericUpDown numericUpDown3;
        private Panel panel3;
        private Panel panel4;
        private Label label3;
        private Label label9;
        private Label label10;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private Panel panel5;
        private Panel panel6;
        private Label label11;
        private NumericUpDown numericUpDown6;
        private Label label12;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label14;
        private TextBox textBox4;
        private Label label15;
        private Label label13;
    }
}