using ProjektStatki.Models;
using ProjektStatki.Models.Creator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = ProjektStatki.Models.Point;

namespace ProjektStatki.Views
{
    public partial class SelectShipsView : Form
    {
        public List<Ship> normalShips = new List<Ship>();
        public List<Ship> specialShips = new List<Ship>();
        public List<Ship> selectedShips = new List<Ship>();
        public int shipsCount;
        public int specialShipsCount;
        public SelectShipsView(int shipsCount, int specialShipsCount)
        {
            InitializeComponent();
            dataGridView1.ClearSelection();
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 7;
            dataGridView1.RowCount = 7;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            int cellWidth = dataGridView1.ClientSize.Width / 8;
            int cellHeight = dataGridView1.ClientSize.Height / 8;
            this.shipsCount = shipsCount;
            this.specialShipsCount = specialShipsCount;
            this.StartPosition = FormStartPosition.CenterScreen;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = cellWidth;
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Height = cellHeight;
            }
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
            listBox3.SelectionMode = SelectionMode.One;
            LoadShipsToListBoxes();
            label5.Text += shipsCount;
            label6.Text += specialShipsCount;
        }

        private void Label5TextRestart()
        {
            label5.Text = "Statki: "+ shipsCount;
        }

        private void Label6TextRestart()
        {
            label6.Text = "Statki specjalne: " + specialShipsCount;
        }

        public void LoadShipsToListBoxes()
        {
            List<Point> specPoints1 = new List<Point>()
            {
                new Point(0,0), new Point(0,1), new Point(1,0)
            };
            List<Point> specPoints2 = new List<Point>()
            {
                new Point(0,0), new Point(1,0), new Point(1,1), new Point(1,2), new Point(0,2)
            };
            List<Point> specPoints3 = new List<Point>()
            {
                new Point(0,0), new Point(1,0), new Point(2,0), new Point(2,1), new Point(2,2), new Point(0,1), new Point(1,2), new Point(0,2)
            };
            List<Point> specPoints4 = new List<Point>()
            {
                new Point(0,0), new Point(0,1), new Point(1,1), new Point(1,2), new Point(2,2), new Point(2,3), new Point(3,3)
            };
            List<Point> specPoints5 = new List<Point>()
            {
                new Point(1,0), new Point(0,1), new Point(1,1), new Point(2,1), new Point (1,2)
            };
            List<string> names = new List<string>
            {
                "Kajak", "Łudka", "Liniowiec", "Krążownik", "Lotniskowiec", "Pancernik"
            };

            List<string> specNames = new List<string>
            {
                "Szalupa", "U", "O", "Grom", "Plus"
            };

            List<List<Point>> specPoints = new List<List<Point>>()
            {
                specPoints1, specPoints2, specPoints3, specPoints4, specPoints5
            };



            NormalShipCreator normal = new NormalShipCreator();
            for (int i = 0; i < 6; i++)
            {
                Ship ship = normal.createShip(i + 1, names[i]);
                normalShips.Add(ship);
            }

            foreach (var ship in normalShips)
            {
                listBox1.Items.Add(ship.getName());
            }

            //Tu będą statki specjalne
            SpecialTypeShipCreator special = new SpecialTypeShipCreator();

            for(int i=0; i< 5; i++)
            {
                Ship ship = special.createShip(specPoints[i], specNames[i]);
                specialShips.Add(ship);
            }

            foreach (var ship in specialShips)
            {
                listBox2.Items.Add(ship.getName());
            }
        }

        public void DisplayShip(Ship ship)
        {
            for (int i = 0; i < ship.points.Count; i++)
            {
                int row = ship.points[i].wight;
                int col = ship.points[i].height;
                dataGridView1.Rows[row].Cells[col].Style.BackColor = Color.Black;
            }
        }

        public List<Ship> GetSelectedShips()
        {
            return selectedShips;
        }

        private void SelectShipsView_Load(object sender, EventArgs e)
        {
            
        }

        private void DataGridViewReset()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = null;
                    cell.Style.BackColor = Color.White;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewReset();
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.ClearSelected();
                string selectedShipName = listBox1.SelectedItem.ToString();
                Ship ship = normalShips.FirstOrDefault(s => s.getName() == selectedShipName);
                if (ship != null)
                {
                    DisplayShip(ship);
                }
                else
                {
                    MessageBox.Show("Problem ze znalezieniem statku");
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewReset();
            if (listBox2.SelectedIndex != -1)
            {
                listBox1.ClearSelected();
                string selectedShipName = listBox2.SelectedItem.ToString();
                Ship ship = specialShips.FirstOrDefault(s => s.getName() == selectedShipName);
                if (ship != null)
                {
                    DisplayShip(ship);
                }
                else
                {
                    MessageBox.Show("Problem ze znalezieniem statku");
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 || listBox2.SelectedIndex != -1)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    if(shipsCount > 0 && shipsCount > specialShipsCount)
                    {
                        string selectedShipName = listBox1.SelectedItem.ToString();
                        Ship ship = normalShips.FirstOrDefault(s => s.getName() == selectedShipName);
                        if (ship != null)
                        {
                            selectedShips.Add(ship);
                            listBox3.Items.Add(ship.getName());
                            shipsCount--;
                            Label5TextRestart();
                        }
                        else
                        {
                            MessageBox.Show("Problem ze znalezieniem statku");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie możesz już stawiać statków");
                    }
                }
                else
                {
                    if (specialShipsCount > 0)
                    {
                        string selectedShipName = listBox2.SelectedItem.ToString();
                        Ship ship = specialShips.FirstOrDefault(s => s.getName() == selectedShipName);
                        if (ship != null)
                        {
                            selectedShips.Add(ship);
                            listBox3.Items.Add(ship.getName());
                            shipsCount--;
                            specialShipsCount--;
                            Label5TextRestart();
                            Label6TextRestart();
                        }
                        else
                        {
                            MessageBox.Show("Problem ze znalezieniem statku");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Masz wybrane wszystkie statki specjalne");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano elementu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                Ship shipToDelete = selectedShips.FirstOrDefault(s => s.getName() == listBox3.SelectedItem.ToString());
                if (shipToDelete != null)
                {
                    listBox3.Items.Remove(listBox3.SelectedItem);
                    selectedShips.Remove(shipToDelete);
                    if (shipToDelete is NormalShipType)
                    {
                        shipsCount++;
                        Label5TextRestart();
                    }
                    else
                    {
                        shipsCount++;
                        specialShipsCount++;
                        Label5TextRestart();
                        Label6TextRestart();
                    }
                }
                else
                {
                    MessageBox.Show("Zaznaczony statek ma błąd i nie został usuięty z listy");
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano statku do usunięcia!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
