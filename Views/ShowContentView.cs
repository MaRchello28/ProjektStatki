using ProjektStatki.Models.ElementsToUnlock;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjektStatki.Views
{
    public partial class ShowContentView : Form
    {
        private ShowContentPresenter presenter;

        public ShowContentView(List<Element> elements)
        {
            InitializeComponent();
            presenter = new ShowContentPresenter(this, elements);
            presenter.InitializeDataGridView();
        }

        public void DisplayElements(List<(string Type, string Name, int RequiredLevel)> elements)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Type";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Required Level";

            foreach (var element in elements)
            {
                dataGridView1.Rows.Add(element.Type, element.Name, element.RequiredLevel);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class ShowContentPresenter
    {
        private readonly ShowContentView view;
        private readonly List<Element> elements;

        public ShowContentPresenter(ShowContentView view, List<Element> elements)
        {
            this.view = view;
            this.elements = elements;
        }

        public void InitializeDataGridView()
        {
            // Przekształcamy dane z listy elementów na odpowiedni format
            var elementsData = elements.Select(element =>
                (element.type, element.name, element.Requiredlvl))
                .ToList();

            // Wyświetlamy dane w widoku
            view.DisplayElements(elementsData);
        }
    }
}
