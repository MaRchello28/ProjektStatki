using ProjektStatki.Controllers;
using ProjektStatki.Models;
using ProjektStatki.Models.Data;
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
        public Player enemy = null;
        MyDbContext db;
        public ChooseGameModeView(MyDbContext db)
        {
            InitializeComponent();
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.db = db;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public GameMode ChoseGamemode()
        {
            return gameMode;
        }

        public Player Enemy()
        {
            return enemy;
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
                        if (label1.Text == "Nie rankingowa")
                        {
                            label2.Text = "" +
                                "Rankingowa = Nie \n\r" +
                                "Rozmiar Planszy = 10x10 \n\r" +
                                "Ile statków = 5 \n\r" +
                                "W tym specjalnych = 0 \n\r";
                        }
                        else if (label1.Text == "Rankingowa")
                        {
                            label2.Text = "" +
                                "Rankingowa = Tak \n\r" +
                                "Rozmiar Planszy = 10x10 \n\r" +
                                "Ile statków = 5 \n\r" +
                                "W tym specjalnych = 0 \n\r";
                        }
                        else if (label1.Text == "Tryb Symulacji")
                        {
                            label2.Text = "" +
                                "Rankingowa = Nie \n\r" +
                                "Rozmiar Planszy = 10x10 \n\r" +
                                "Ile statków = 5 \n\r" +
                                "W tym specjalnych = 2 \n\r" +
                                "Zasady: Możliwość oglądania testowej gry botów w trybie standardowym \n\r";
                        }
                        else if (label1.Text == "SpecjalneStatki")
                        {
                            label2.Text = "" +
                                "Rankingowa = Nie \n\r" +
                                "Rozmiar Planszy = 10x10 \n\r" +
                                "Ile statków = 5 \n\r" +
                                "W tym specjalnych = 2 \n\r" +
                                "Zasady: Każdy statek zostaje zatopiony po 1 trafieniu \n\r";
                        }
                        else
                        {
                            label2.Text = "Wyskoczył błąd";
                        }

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
                if(label1.Text == "Nie rankingowa")
                {
                    gameMode = new ClassicGameMode(false);
                    if(string.IsNullOrEmpty(textBox1.Text))
                    {
                        if(!(checkBox1.Checked))
                        {
                            MessageBox.Show("Musisz wybrać przeciwnika");
                        }
                        else
                        {
                            enemy = new HumanPlayer("GOŚĆ", "1234");
                        }
                    }
                    else
                    {
                        string login = textBox1.Text;
                        string password = textBox3.Text;
                        if(db.users.Any(u => u.name == login && u.password == password))
                        {
                            enemy = db.users.FirstOrDefault(u => u.name == login);
                        }
                        else
                        {
                            MessageBox.Show("Nie istnieje taki użytkownik lub podano złe dane");
                        }
                    }
                }
                else if(label1.Text == "Rankingowa")
                {
                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        if (!(checkBox1.Checked))
                        {
                            MessageBox.Show("Musisz wybrać przeciwnika");
                        }
                        else
                        {
                            MessageBox.Show("W tym trybie przeciwnik nie może być Gościem");
                        }
                    }
                    else
                    {
                        string login = textBox1.Text;
                        string password = textBox3.Text;
                        if (db.users.Any(u => u.name == login && u.password == password))
                        {
                            enemy = db.users.FirstOrDefault(u => u.name == login);
                        }
                        else
                        {
                            MessageBox.Show("Nie istnieje taki użytkownik lub podano złe dane");
                        }
                    }
                    gameMode = new ClassicGameMode(true);
                }
                else if(label1.Text == "Tryb Symulacji")
                {
                    MessageBox.Show("trybSymulacji");
                }
                else if(label1.Text == "SpecjalneStatki")
                {
                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        if (!(checkBox1.Checked))
                        {
                            MessageBox.Show("Musisz wybrać przeciwnika");
                        }
                        else
                        {
                            enemy = new HumanPlayer("GOŚĆ", "1234");
                        }
                    }
                    else
                    {
                        string login = textBox1.Text;
                        string password = textBox3.Text;
                        if (db.users.Any(u => u.name == login && u.password == password))
                        {
                            enemy = db.users.FirstOrDefault(u => u.name == login);
                        }
                        else
                        {
                            MessageBox.Show("Nie istnieje taki użytkownik lub podano złe dane");
                        }
                    }
                    gameMode = new OneShotSinksShip();
                }
                else
                {
                    MessageBox.Show("Nie wybrano trybu w panel1");
                }
            }
            else if (panel2.Visible == true)
            {
                if (label4.Text == "Gracz vs AI")
                {
                    MessageBox.Show("graczVsAI");
                }
                else if (label4.Text == "Stwórz Własną")
                {
                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        if (!(checkBox2.Checked))
                        {
                            MessageBox.Show("Musisz wybrać przeciwnika");
                        }
                        else
                        {
                            enemy = new HumanPlayer("GOŚĆ", "1234");
                        }
                    }
                    else
                    {
                        string login = textBox2.Text;
                        string password = textBox4.Text;
                        if (db.users.Any(u => u.name == login && u.password == password))
                        {
                            enemy = db.users.FirstOrDefault(u => u.name == login);
                        }
                        else
                        {
                            MessageBox.Show("Nie istnieje taki użytkownik lub podano złe dane");
                        }
                    }
                    Board board = new Board((int)numericUpDown5.Value, (int)numericUpDown4.Value);
                    Board board1 = new Board(board);
                    Board board2 = new Board(board);
                    int shipsCount = (int)numericUpDown3.Value;
                    int specShipsCount = (int)numericUpDown6.Value;
                    SelectShipsView select = new SelectShipsView(shipsCount, specShipsCount);
                    select.ShowDialog();
                    List<Ship> ships = select.GetSelectedShips();
                    if(IsPossibleToCreateGame(board, shipsCount, specShipsCount))
                    {
                        gameMode = new CustomgameMode(board1, board2, shipsCount, specShipsCount, ships);
                    }
                }
                else
                {
                    MessageBox.Show("Nie wybrano trybu w panel2");
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
            if (board == null || shipCount <= 0)
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
