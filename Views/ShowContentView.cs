using ProjektStatki.Models.ElementsToUnlock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektStatki.Views
{
    public partial class ShowContentView : Form
    {
        private List<Element> elements;
        public ShowContentView(List<Element> elements)
        {
            InitializeComponent();
            this.elements = elements;
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            // Ustawienia DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Type";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Required Level";

            // Dodajemy dane do DataGridView
            foreach (var element in elements)
            {
                dataGridView1.Rows.Add(element.type, element.name, element.Requiredlvl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}