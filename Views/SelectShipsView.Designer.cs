namespace ProjektStatki.Views
{
    partial class SelectShipsView
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
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            listBox2 = new ListBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            listBox3 = new ListBox();
            label3 = new Label();
            button2 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 33);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(142, 349);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(142, 21);
            label1.TabIndex = 1;
            label1.Text = "Statki standardowe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(549, 9);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 2;
            label2.Text = "Statki specjalne";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(549, 33);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(142, 349);
            listBox2.TabIndex = 3;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(175, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(350, 350);
            dataGridView1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(175, 389);
            button1.Name = "button1";
            button1.Size = new Size(209, 35);
            button1.TabIndex = 5;
            button1.Text = "Wybierz";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 15;
            listBox3.Location = new Point(390, 411);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(135, 169);
            listBox3.TabIndex = 6;
            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(399, 386);
            label3.Name = "label3";
            label3.Size = new Size(115, 21);
            label3.TabIndex = 7;
            label3.Text = "Wybrane Statki";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(175, 430);
            button2.Name = "button2";
            button2.Size = new Size(209, 35);
            button2.TabIndex = 8;
            button2.Text = "Usuń wybrany";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(175, 506);
            label4.Name = "label4";
            label4.Size = new Size(209, 25);
            label4.TabIndex = 9;
            label4.Text = "Zostało do wybrania:";
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(175, 531);
            label5.Name = "label5";
            label5.Size = new Size(209, 25);
            label5.TabIndex = 10;
            label5.Text = "Statki:";
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(175, 556);
            label6.Name = "label6";
            label6.Size = new Size(209, 25);
            label6.TabIndex = 11;
            label6.Text = "Statki specjalne:";
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 14F);
            button3.Location = new Point(175, 471);
            button3.Name = "button3";
            button3.Size = new Size(209, 32);
            button3.TabIndex = 12;
            button3.Text = "Zapisz";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // SelectShipsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 605);
            Controls.Add(button3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(listBox3);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(listBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "SelectShipsView";
            Text = "SelectShipsView";
            Load += SelectShipsView_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private ListBox listBox2;
        private DataGridView dataGridView1;
        private Button button1;
        private ListBox listBox3;
        private Label label3;
        private Button button2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button3;
    }
}