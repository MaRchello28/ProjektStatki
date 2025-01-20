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
        public Player player1 = null;
        MyDbContext db;
        private string loggedUserid = null;
        public ChooseGameModeView(MyDbContext db, string loggedUserId)
        {
            InitializeComponent();
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.db = db;
            this.StartPosition = FormStartPosition.CenterScreen;
            label16.Visible = false;
            label17.Visible = false;
            listBox1.Visible = false;
            listBox2.Visible = false;
            this.loggedUserid = loggedUserId;
        }

        public GameMode ChoseGamemode()
        {
            return gameMode;
        }

        public Player Enemy()
        {
            return enemy;
        }

        public Player Player1()
        {
            return player1;
        }

        private void ChooseGameModeView_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void ComputerDifficultyView(bool visible)
        {
            if(panel1.Visible)
            {
                label16.Visible = visible;
                listBox1.Visible = visible;
                listBox3.Visible = visible;
            }
            else
            {
                label17.Visible = visible;
                listBox2.Visible = visible;
            }
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
                            ComputerDifficultyView(false);
                            label2.Text = "" +
                                "Rankingowa = Nie \n\r" +
                                "Rozmiar Planszy = 10x10 \n\r" +
                                "Ile statków = 5 \n\r" +
                                "W tym specjalnych = 0 \n\r";
                        }
                        else if (label1.Text == "Rankingowa")
                        {
                            ComputerDifficultyView(false);
                            label2.Text = "" +
                                "Rankingowa = Tak \n\r" +
                                "Rozmiar Planszy = 10x10 \n\r" +
                                "Ile statków = 5 \n\r" +
                                "W tym specjalnych = 0 \n\r";
                        }
                        else if (label1.Text == "Tryb Symulacji")
                        {
                            ComputerDifficultyView(true);
                            label2.Text = "" +
                                "Rankingowa = Nie \n\r" +
                                "Rozmiar Planszy = 10x10 \n\r" +
                                "Ile statków = 5 \n\r" +
                                "W tym specjalnych = 2 \n\r" +
                                "Zasady: Możliwość oglądania testowej gry botów w trybie standardowym \n\r";
                        }
                        else if (label1.Text == "SpecjalneStatki")
                        {
                            ComputerDifficultyView(false);
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
                        if (label4.Text == "Gracz vs AI")
                        {
                            ComputerDifficultyView(true);
                        }
                        else
                        {
                            ComputerDifficultyView(false);
                        }
                    }
                }
            }
        }

        public void Unranked()
        {
            gameMode = new ClassicGameMode(false);
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
        }

        public void Ranked()
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

        public void Simulation()
        {
            if (listBox1.SelectedIndex == -1 || listBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano poziomu trudności dla wszystkich botów");
            }
            else
            {
                gameMode = new ClassicGameMode(true);
                List<string> names = new List<string>()
                        {
                            "Mieszko", "Bolesław", "Kazimierz", "Władysław", "Stanisław", "Leszek"
                        };

                if (listBox1.SelectedIndex == 0)
                {
                    player1 = new ComputerPlayer(names[0], 1);
                    player1.name = names[0];
                }
                else if (listBox1.SelectedIndex == 1)
                {
                    player1 = new ComputerPlayer(names[1], 2);
                    player1.name = names[1];
                }
                else if (listBox1.SelectedIndex == 2)
                {
                    player1 = new ComputerPlayer(names[2], 3);
                    player1.name = names[2];
                }
                else
                {
                    MessageBox.Show("Bład podczas konstrukcji player1");
                }

                if (listBox3.SelectedIndex == 0)
                {
                    enemy = new ComputerPlayer(names[3], 1);
                    enemy.name = names[3];
                }
                else if (listBox3.SelectedIndex == 1)
                {
                    enemy = new ComputerPlayer(names[4], 2);
                    enemy.name = names[4];
                }
                else if (listBox3.SelectedIndex == 2)
                {
                    enemy = new ComputerPlayer(names[5], 3);
                    enemy.name = names[5];
                }
                else
                {
                    MessageBox.Show("Bład podczas konstrukcji player2");
                }
                gameMode.board1.player = player1;
                gameMode.board2.player = enemy;
            }
        }

        public void SpecialShips()
        {
            var user = db.users.FirstOrDefault(u => u.Id == loggedUserid);
            if (user != null)
            {
                if (user.level.level < 6)
                {
                    MessageBox.Show("Ta zawartość nie została odblokowana!");
                }
                else
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
                }
            }
            gameMode = new OneShotSinksShip();
        }

        public void PlayerVsAI()
        {
            if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano poziomu trudności dla wszystkich bota");
            }
            else
            {
                List<string> names = new List<string>()
                        {
                            "Mieszko", "Bolesław", "Kazimierz"
                        };

                if (listBox2.SelectedIndex == 0)
                {
                    enemy = new ComputerPlayer(names[0], 1);
                    enemy.name = names[0];
                }
                else if (listBox2.SelectedIndex == 1)
                {
                    enemy = new ComputerPlayer(names[1], 2);
                    enemy.name = names[1];
                }
                else if (listBox2.SelectedIndex == 2)
                {
                    enemy = new ComputerPlayer(names[2], 3);
                    enemy.name = names[2];
                }
                else
                {
                    MessageBox.Show("Bład podczas konstrukcji player2");
                }
                Board board = new Board((int)numericUpDown5.Value, (int)numericUpDown4.Value);
                Board board1 = new Board(board);
                board1.player = player1;
                Board board2 = new Board(board);
                board2.player = enemy;
                int shipsCount = (int)numericUpDown3.Value;
                int specShipsCount = (int)numericUpDown6.Value;
                SelectShipsView select = new SelectShipsView(shipsCount, specShipsCount);
                select.ShowDialog();
                List<Ship> ships = select.GetSelectedShips();
                if (IsPossibleToCreateGame(board, shipsCount, specShipsCount))
                {
                    gameMode = new CustomgameMode(board1, board2, shipsCount, specShipsCount, ships);
                }
            }
        }

        public void Custom()
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
            board1.player = player1;
            Board board2 = new Board(board);
            board2.player = enemy;
            int shipsCount = (int)numericUpDown3.Value;
            int specShipsCount = (int)numericUpDown6.Value;
            SelectShipsView select = new SelectShipsView(shipsCount, specShipsCount);
            select.ShowDialog();
            List<Ship> ships = select.GetSelectedShips();
            if (IsPossibleToCreateGame(board, shipsCount, specShipsCount))
            {
                gameMode = new CustomgameMode(board1, board2, shipsCount, specShipsCount, ships);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                if(label1.Text == "Nie rankingowa")
                {
                    Unranked();
                }
                else if(label1.Text == "Rankingowa")
                {
                    Ranked();
                }
                else if(label1.Text == "Tryb Symulacji")
                {
                    Simulation();
                }
                else if(label1.Text == "SpecjalneStatki")
                {
                    SpecialShips();
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
                    PlayerVsAI();
                    
                }
                else if (label4.Text == "Stwórz Własną")
                {
                    Custom();
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
