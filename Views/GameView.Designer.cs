namespace ProjektStatki.Views
{
    partial class GameView
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
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            StrzałGracza1 = new DataGridViewTextBoxColumn();
            StrzałGracza2 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            listBox4 = new ListBox();
            label3 = new Label();
            listBox3 = new ListBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 9);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(450, 450);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(16, 6);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(450, 450);
            dataGridView2.TabIndex = 1;
            // 
            // dataGridView3
            // 
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { StrzałGracza1, StrzałGracza2 });
            dataGridView3.Location = new Point(542, 51);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(267, 49);
            dataGridView3.TabIndex = 2;
            // 
            // StrzałGracza1
            // 
            StrzałGracza1.HeaderText = "StrzałGracza1";
            StrzałGracza1.Name = "StrzałGracza1";
            // 
            // StrzałGracza2
            // 
            StrzałGracza2.HeaderText = "Strzał Gracza 2";
            StrzałGracza2.Name = "StrzałGracza2";
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(542, 12);
            label1.Name = "label1";
            label1.Size = new Size(267, 36);
            label1.TabIndex = 3;
            label1.Text = "Ruchy Graczy";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(334, 470);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(128, 109);
            listBox1.TabIndex = 7;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(16, 470);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(128, 109);
            listBox2.TabIndex = 9;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(0, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(488, 597);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBox2);
            groupBox2.Controls.Add(dataGridView2);
            groupBox2.Location = new Point(867, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(483, 597);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // button1
            // 
            button1.Location = new Point(608, 542);
            button1.Name = "button1";
            button1.Size = new Size(140, 58);
            button1.TabIndex = 12;
            button1.Text = "Poddaj się";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(608, 316);
            button2.Name = "button2";
            button2.Size = new Size(140, 59);
            button2.TabIndex = 13;
            button2.Text = "Rozpocznij symulację";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(listBox4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(listBox3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(595, 131);
            panel1.Name = "panel1";
            panel1.Size = new Size(165, 179);
            panel1.TabIndex = 14;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 15;
            listBox4.Items.AddRange(new object[] { "Czarne", "Pomarańczowe", "Różowy" });
            listBox4.Location = new Point(17, 109);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(125, 49);
            listBox4.TabIndex = 3;
            listBox4.SelectedIndexChanged += listBox4_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(3, 86);
            label3.Name = "label3";
            label3.Size = new Size(159, 20);
            label3.TabIndex = 2;
            label3.Text = "Wybierz kolor statków:";
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 15;
            listBox3.Items.AddRange(new object[] { "Białe", "Czerwone", "Zielone" });
            listBox3.Location = new Point(17, 34);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(125, 49);
            listBox3.TabIndex = 1;
            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(17, 11);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 0;
            label2.Text = "Wybierz kolor tła:";
            // 
            // GameView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1368, 624);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView3);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GameView";
            Text = "GameView";
            Load += GameView_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn StrzałGracza1;
        private DataGridViewTextBoxColumn StrzałGracza2;
        private Label label1;
        private ListBox listBox1;
        private ListBox listBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private ListBox listBox3;
        private Label label2;
        private ListBox listBox4;
        private Label label3;
    }
}