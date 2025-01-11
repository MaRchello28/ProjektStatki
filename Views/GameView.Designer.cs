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
            label2 = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(600, 573);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(1240, 12);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(600, 573);
            dataGridView2.TabIndex = 1;
            // 
            // dataGridView3
            // 
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { StrzałGracza1, StrzałGracza2 });
            dataGridView3.Location = new Point(802, 51);
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
            label1.Location = new Point(802, 12);
            label1.Name = "label1";
            label1.Size = new Size(267, 36);
            label1.TabIndex = 3;
            label1.Text = "Ruchy Graczy";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 588);
            label2.Name = "label2";
            label2.Size = new Size(466, 109);
            label2.TabIndex = 6;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(484, 588);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(128, 109);
            listBox1.TabIndex = 7;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(1712, 588);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(128, 109);
            listBox2.TabIndex = 9;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(1240, 588);
            label3.Name = "label3";
            label3.Size = new Size(466, 109);
            label3.TabIndex = 8;
            // 
            // GameView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1852, 900);
            Controls.Add(listBox2);
            Controls.Add(label3);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GameView";
            Text = "GameView";
            Load += GameView_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn StrzałGracza1;
        private DataGridViewTextBoxColumn StrzałGracza2;
        private Label label1;
        private Label label2;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label label3;
    }
}