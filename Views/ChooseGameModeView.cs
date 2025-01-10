using ProjektStatki.Models;
using ProjektStatki.Models.Gamemodes;
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
    public partial class ChooseGameModeView : Form
    {
        public GameMode gameMode = null;
        public ChooseGameModeView()
        {
            InitializeComponent();
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
        }

        private void ChooseGameModeView_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode != null)
            {
                TreeNode parentNode = selectedNode.Parent;
                if (parentNode != null)
                {
                    if (parentNode.Name == "normal" || parentNode.Name == "specjalne")
                    {
                        panel1.Visible = true;
                        panel2.Visible = false;
                        label1.Text = selectedNode.Text;
                    }
                    else
                    {
                        panel1.Visible = false;
                        panel2.Visible = true;
                        panel2.Location = panel1.Location;
                        label4.Text = selectedNode.Text;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {

            }
            else if (panel2.Visible == true)
            {
                int x = (int)numericUpDown5.Value;
                int y = (int)numericUpDown4.Value;
                Board board = new Board(x, y);
                int shipCount = (int)numericUpDown3.Value;
                int specialShipCount = (int)numericUpDown6.Value;
                if (IsPossibleToCreateGame(board, shipCount, specialShipCount))
                {
                    //Game game = new Game(board, board, gameMode, ); Do dokończenia bo teraz nie ma jak tego zrobić
                }
            }
            else
            {
                MessageBox.Show("Coś poszło nie tak");
            }
            this.Close();
        }

        public bool IsPossibleToCreateGame(Board board, int shipCount, int specialShipCount)
        {
            int maxBoardSize = 15;
            if (board == null || shipCount <= 0 || specialShipCount <= 0)
            {
                MessageBox.Show("Podano niepoprawne wartości!");
                return false;
            }
            else if(board.cells.Any(c => c.point.wight > maxBoardSize))
            {
                MessageBox.Show("Szerokość nie może być większa niż 15!");
                return false;
            }
            else if(board.cells.Any(c => c.point.height > maxBoardSize))
            {
                MessageBox.Show("Wysokość nie może być większa niż 15!");
                return false;
            }
            else if(shipCount < specialShipCount)
            {
                MessageBox.Show("Nie może być więcej statków specjalnych niż zwykłych");
                return false;
            }
            return true;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
