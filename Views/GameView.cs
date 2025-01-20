using ProjektStatki.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = ProjektStatki.Models.Point;
using System.Threading;
using ProjektStatki.Models.Data;
using ProjektStatki.Models.Creator;
using ProjektStatki.Models.Decorator;
using ProjektStatki.Models.Decorators;

namespace ProjektStatki.Views
{
    public partial class GameView : Form
    {
        MyDbContext db;
        Game game;
        int currentPlayer = 1;
        private List<Point> shipPoints = new List<Point>();
        private Ship selectedShip = null;
        Board currentPlayerBoard = null;
        DataGridView currentDataGridView = null;
        Board board1;
        Board board2;
        private List<Ship> player1Ships = new List<Ship>();
        private List<Ship> player2Ships = new List<Ship>();
        private int backgroundSkin = 1;
        private Color shipColor = Color.Black;
        Ship copiedShip = null;
        public GameView(Game game, MyDbContext db)
        {
            InitializeComponent();
            this.game = game;
            this.db = db;
            dataGridView1.ClearSelection();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            listBox1.KeyDown += new KeyEventHandler(listBox1_KeyDown);
            listBox2.KeyDown += new KeyEventHandler(listBox2_KeyDown);
            listBox3.KeyDown += listBox1_KeyDown;
            listBox4.KeyDown += listBox1_KeyDown;
            board1 = game.boardPlayer1;
            board2 = game.boardPlayer2;
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView2.CellClick += DataGridView2_CellClick;
            dataGridView3.ReadOnly = true;
            dataGridView3.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            if (game.player1 is ComputerPlayer)
            {
                PlaceShipsRandomly(board1);
                if (game.player2 is ComputerPlayer)
                {
                    PlaceShipsRandomly(board2);
                }
            }
        }

        public (int maxX, int maxY) GetMaxCoordinates(Board board)
        {
            int maxX = 0;
            int maxY = 0;

            foreach (var cell in board.cells)
            {
                if (cell.point.wight > maxX)
                {
                    maxX = cell.point.wight;
                }
                if (cell.point.height > maxY)
                {
                    maxY = cell.point.height;
                }
            }

            return (maxX, maxY);
        }

        public void PlaceShipsRandomly(Board board)
        {
            Random rand = new Random();
            List<Ship> ships = game.gameMode.ships;

            foreach (Ship ship in ships)
            {
                bool placed = false;

                while (!placed)
                {
                    var (maxX, maxY) = GetMaxCoordinates(board);
                    int x = rand.Next(0, maxX + 1);
                    int y = rand.Next(0, maxY + 1);
                    int direction = rand.Next(0, 2);

                    List<Point> shipPoints = GetShipPoints(x, y, ship, direction);

                    if (IsShipWithinBounds(shipPoints, board) && !IsShipColliding(shipPoints, board))
                    {
                        PlaceShipOnBoard(shipPoints, board);
                        placed = true;
                    }
                }
            }
        }

        private List<Point> GetShipPoints(int startX, int startY, Ship ship, int direction)
        {
            List<Point> points = new List<Point>();

            for (int i = 0; i < ship.points.Count; i++)
            {
                if (direction == 0) // Poziomo
                {
                    points.Add(new Point(startX + i, startY));
                }
                else // Pionowo
                {
                    points.Add(new Point(startX, startY + i));
                }
            }

            return points;
        }

        private bool IsShipWithinBounds(List<Point> shipPoints, Board board)
        {
            var (maxX, maxY) = GetMaxCoordinates(board); // Używamy funkcji GetMaxCoordinates

            foreach (var point in shipPoints)
            {
                if (point.wight < 0 || point.wight > maxX || point.height < 0 || point.height > maxY)
                {
                    return false; // Statek wychodzi poza granice planszy
                }
            }
            return true;
        }

        private bool IsShipColliding(List<Point> shipPoints, Board board)
        {
            foreach (var point in shipPoints)
            {
                // Zakładając, że komórki są przechowywane w board.Cells w postaci 2D
                Cell cell = board.cells.FirstOrDefault(c => c.point.wight == point.height && c.point.height == point.wight);
                if (cell != null && cell.isShip)
                {
                    return true; // W tym miejscu już znajduje się statek
                }
            }
            return false;
        }

        private void PlaceShipOnBoard(List<Point> shipPoints, Board board)
        {
            foreach (var point in shipPoints)
            {
                // Zakładając, że w komórkach planszy `IsShip` oznacza, że w tej komórce jest statek
                Cell cell = board.cells.FirstOrDefault(c => c.point.wight == point.height && c.point.height == point.wight);
                if (cell != null)
                {
                    cell.isShip = true; // Ustawiamy, że ta komórka jest zajęta przez statek
                }
            }
        }

        public void AddShotToList(int x, int y, bool wasShot)
        {
            if (currentPlayer == 1)
            {
                if (wasShot)
                {
                    dataGridView3.Rows.Add((x + 1).ToString() + (Convert.ToChar('a' + (y))).ToString(), "");
                    dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
                }
                else
                {
                    dataGridView3.Rows.Add((x + 1).ToString() + (Convert.ToChar('a' + (y))).ToString(), "");
                    dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Green;
                }
            }
            else
            {
                if (wasShot)
                {
                    dataGridView3.Rows.Add("", (x + 1).ToString() + (Convert.ToChar('a' + (y))).ToString());
                    dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
                }
                else
                {
                    dataGridView3.Rows.Add("", (x + 1).ToString() + (Convert.ToChar('a' + (y))).ToString());
                    dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Green;
                }
            }

            int rowHeight = dataGridView3.Rows[dataGridView3.Rows.Count - 1].Height;
            if (dataGridView3.Height < 300)
            {
                dataGridView3.Height += rowHeight;
            }

        }

        public bool PlayerWon()
        {
            if (currentPlayer == 1)
            {
                List<Cell> cel = board2.cells.Where(c => c.isShip == true).ToList();
                if (!cel.Any(c => c.wasShot == false))
                {
                    WinView();
                    MessageBox.Show("Wygrałeś!!!");
                    return true;
                }
            }
            else
            {
                List<Cell> cel = board1.cells.Where(c => c.isShip == true).ToList();
                if (!cel.Any(c => c.wasShot == false))
                {
                    WinView();
                    MessageBox.Show("Wygrałeś!!!");
                    return true;
                }
            }
            return false;
        }

        public void WinP1()
        {
            var playerWon = db.users.FirstOrDefault(u => u.name == game.player1.name);
            var playerLose = db.users.FirstOrDefault(u => u.name == game.player2.name);

            if (playerWon != null)
            {
                if (game.gameMode.isRanked == true)
                {
                    playerWon.UpdateRanking(true, playerLose.raitingPoints);
                }
                playerWon.LevelUp(true);
            }
            if (playerLose != null)
            {
                if (game.gameMode.isRanked == true)
                {
                    playerLose.UpdateRanking(false, playerWon.raitingPoints);
                }
                playerLose.LevelUp(false);
            }
            if (game.player1 is HumanPlayer && game.player2 is HumanPlayer && playerLose != null && playerWon != null)
            {
                GameHistoryModel ghm = new GameHistoryModel(game.player1.Id, game.player2.Id, game.player1.name + "Wygrał",
                    game.gameMode.name, DateTime.Now);
                db.gameHistory.Add(ghm);
            }
            db.SaveChanges();
            this.Close();
        }

        public void WinView()
        {
            if (currentPlayer == 1)
            {
                WinP1();
            }
            else
            {
                WinP2();
            }
        }

        public void WinP2()
        {
            var playerWon = db.users.FirstOrDefault(u => u.name == game.player2.name);
            var playerLose = db.users.FirstOrDefault(u => u.name == game.player1.name);

            if (playerWon != null)
            {
                if (game.gameMode.isRanked == true)
                {
                    playerWon.UpdateRanking(true, playerLose.raitingPoints);
                }
                playerWon.LevelUp(true);
            }
            if (playerLose != null)
            {
                if (game.gameMode.isRanked == true)
                {
                    playerLose.UpdateRanking(false, playerWon.raitingPoints);
                }
                playerLose.LevelUp(false);
            }
            if (game.player1 is HumanPlayer && game.player2 is HumanPlayer && playerLose != null && playerWon != null)
            {
                GameHistoryModel ghm = new GameHistoryModel(game.player1.Id, game.player2.Id, game.player2.name + " Wygrał",
                    game.gameMode.name, DateTime.Now);
                db.gameHistory.Add(ghm);
            }
            db.SaveChanges();
            this.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                Point selectedCell = new Point(e.RowIndex, e.ColumnIndex);

                ShotPlayer2(selectedCell);
            }
        }
        public void ShotPlayer1(Point selectedCell)
        {
            Cell cell = board2.cells.FirstOrDefault(c => c.point.height == selectedCell.wight &&
                                        c.point.wight == selectedCell.height);

            if (cell != null)
            {
                if (cell.isShip == false && cell.wasShot == false)
                {
                    dataGridView2.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.Green;
                    cell.wasShot = true;
                    MessageBox.Show("Pudło!. Następny gracz");
                    AddShotToList(cell.point.wight, cell.point.height, cell.isShip);
                    NextMove(false);
                }
                else if (cell.isShip == true && cell.wasShot == false)
                {
                    dataGridView2.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.Red;
                    cell.wasShot = true;
                    var hitShip = player2Ships.FirstOrDefault(s => s.points.Any(p => p.wight == cell.point.height && p.height == cell.point.wight));
                    if (hitShip != null)
                    {
                        hitShip.Execute(cell.point.wight, cell.point.height, board2);
                    }
                    if (!PlayerWon())
                        MessageBox.Show("Trafiony!. Ruszasz się ponownie");
                    AddShotToList(cell.point.wight, cell.point.height, cell.isShip);
                    NextMove(true);
                }
                else if (cell.isShip == false && cell.wasShot == true)
                {
                    //MessageBox.Show("Nie możesz oddać strzału w te samo miejsce co wtedy!");
                }
                else if (cell.isShip == true && cell.wasShot == true)
                {
                    //MessageBox.Show("Nie możesz oddać strzału w te samo miejsce co wtedy!");
                }
            }
            else
            {
                MessageBox.Show("Coś nie tak ze strzałem");
            }
            dataGridView1.ClearSelection();
            groupBox1.Show();
            groupBox2.Show();
            dataGridView3.Show();
            PlayerTurn();
        }

        public void ShotPlayer2(Point selectedCell)
        {
            Cell cell = board1.cells.FirstOrDefault(c => c.point.height == selectedCell.wight &&
                                        c.point.wight == selectedCell.height);

            if (cell != null)
            {
                if (cell.isShip == false && cell.wasShot == false)
                {
                    dataGridView1.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.Green;
                    cell.wasShot = true;
                    MessageBox.Show("Pudło!. Następny gracz");
                    AddShotToList(cell.point.wight, cell.point.height, cell.isShip);
                    NextMove(false);
                }
                else if (cell.isShip == true && cell.wasShot == false)
                {
                    dataGridView1.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.Red;
                    cell.wasShot = true;
                    var hitShip = player1Ships.FirstOrDefault(s => s.points.Any(p => p.wight == cell.point.height && p.height == cell.point.wight));
                    if (hitShip != null)
                    {
                        hitShip.Execute(cell.point.wight, cell.point.height, board1);
                    }
                    if (!PlayerWon())
                        MessageBox.Show("Trafiony!. Ruszasz się ponownie");
                    AddShotToList(cell.point.wight, cell.point.height, cell.isShip);
                    NextMove(true);
                }
                else if (cell.isShip == false && cell.wasShot == true)
                {
                    //MessageBox.Show("Nie możesz oddać strzału w te samo miejsce co wtedy!");
                }
                else if (cell.isShip == true && cell.wasShot == true)
                {
                    //MessageBox.Show("Nie możesz oddać strzału w te samo miejsce co wtedy!");
                }
            }
            else
            {
                MessageBox.Show("Coś nie tak ze strzałem");
            }
            dataGridView2.ClearSelection();
            PlayerTurn();
            groupBox1.Show();
            groupBox2.Show();
            dataGridView3.Show();
            label1.Show();
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView2.ClearSelection();
                dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                Point selectedCell = new Point(e.RowIndex, e.ColumnIndex);

                ShotPlayer1(selectedCell);
            }
        }

        public void NextMove(bool shipHit)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            if (shipHit)
            {

            }
            else
            {
                if (currentPlayer == 1)
                {
                    currentPlayer = 2;
                    currentPlayerBoard = board2;
                    currentDataGridView = dataGridView2;
                    if (game.player1 is HumanPlayer)
                    {
                        label1.Hide();
                        groupBox1.Hide();
                        groupBox2.Hide();
                        dataGridView3.Hide();

                    }
                    //MessageBox.Show("Teraz rusza się gracz: " + game.player2.name);
                }
                else
                {
                    currentPlayer = 1;
                    currentPlayerBoard = board1;
                    currentDataGridView = dataGridView1;
                    if (game.player2 is HumanPlayer)
                    {
                        label1.Hide();
                        groupBox1.Hide();
                        groupBox2.Hide();
                        dataGridView3.Hide();

                    }
                    //MessageBox.Show("Teraz rusza się gracz: " + game.player1.name);
                }
            }
        }


        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void GameView_Load(object sender, EventArgs e)
        {

            groupBox2.Visible = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            DrawBoard(game.boardPlayer1, dataGridView1);
            DrawBoard(game.boardPlayer2, dataGridView2);
            dataGridView3.Columns[0].HeaderText = game.player1.name;
            dataGridView3.Columns[1].HeaderText = game.player2.name;
            NameRowsAndColumns(dataGridView1);
            NameRowsAndColumns(dataGridView2);
            PutShipsOnBoard(game.player1.name);
            currentPlayerBoard = game.boardPlayer1;
            currentDataGridView = dataGridView1;
            dataGridView1.CurrentCell = null;
            dataGridView2.CurrentCell = null;
            if (LoadShips())
            {
                groupBox1.Visible = false;
                button2.Visible = true;
            }
        }

        private bool IsAbleToPlaceShip()
        {
            Board board = currentPlayerBoard;
            foreach (var checkingPoint in shipPoints)
            {
                if (board.cells.Any(c => c.isShip == true && c.point.height == checkingPoint.wight && c.point.wight == checkingPoint.height))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CanRotateRight(ref List<Point> shipPoints, Board board, DataGridView grid)
        {
            List<Point> rotatedPoints = new List<Point>(shipPoints);

            int xOffset = shipPoints[0].wight;
            int yOffset = shipPoints[0].height;

            for (int i = 0; i < rotatedPoints.Count; i++)
            {
                int x = rotatedPoints[i].wight - xOffset;
                int y = rotatedPoints[i].height - yOffset;

                rotatedPoints[i] = new Point(xOffset - y, yOffset + x);
            }

            foreach (Point point in rotatedPoints)
            {
                if (point.wight < 0 || point.wight >= grid.RowCount || point.height < 0 || point.height >= grid.ColumnCount)
                {
                    return false;
                }
            }

            return true;
        }

        private void RotateRight(ref List<Point> shipPoints)
        {
            int xOffset = shipPoints[0].wight;
            int yOffset = shipPoints[0].height;

            for (int i = 0; i < shipPoints.Count; i++)
            {
                int x = shipPoints[i].wight - xOffset;
                int y = shipPoints[i].height - yOffset;

                shipPoints[i] = new Point(xOffset - y, yOffset + x);
            }
        }

        private bool CanRotateLeft(ref List<Point> shipPoints, Board board, DataGridView grid)
        {
            List<Point> rotatedPoints = new List<Point>(shipPoints);

            int xOffset = shipPoints[0].wight;
            int yOffset = shipPoints[0].height;

            for (int i = 0; i < rotatedPoints.Count; i++)
            {
                int x = rotatedPoints[i].wight - xOffset;
                int y = rotatedPoints[i].height - yOffset;

                rotatedPoints[i] = new Point(xOffset + y, yOffset - x);
            }

            foreach (Point point in rotatedPoints)
            {
                if (point.wight < 0 || point.wight >= grid.RowCount || point.height < 0 || point.height >= grid.ColumnCount)
                {
                    return false;
                }
            }

            return true;
        }

        private void RotateLeft(ref List<Point> shipPoints)
        {
            int xOffset = shipPoints[0].wight;
            int yOffset = shipPoints[0].height;

            for (int i = 0; i < shipPoints.Count; i++)
            {
                int x = shipPoints[i].wight - xOffset;
                int y = shipPoints[i].height - yOffset;

                shipPoints[i] = new Point(xOffset + y, yOffset - x);
            }
        }

        public void PlaceShip2(DataGridView grid)
        {
            selectedShip = game.gameMode.ships.Find(s => s.getName() == listBox2.SelectedItem.ToString());
            Ship originalShip = selectedShip;

            // Usuwanie dekoratora, jeśli statek jest udekorowany
            while (originalShip is ShipDecorator decorator)
            {
                originalShip = decorator.Ship;
            }

            // Teraz oryginalny statek jest przechowywany w originalShip, bez dekoratora
            if (originalShip is NormalShipType || originalShip is SpecialShipType)
            {
                // Kopiowanie statku
                if (originalShip is NormalShipType normalShip)
                {
                    copiedShip = new NormalShipType(normalShip.getName());
                }
                else if (originalShip is SpecialShipType specialShip)
                {
                    copiedShip = new SpecialShipType(specialShip.getName());
                }

                // Kopiowanie punktów statku
                copiedShip.points = shipPoints;

                // Teraz sprawdzamy, czy statek był dekorowany
                if (selectedShip is ShipDecorator decoratedShip)
                {
                    if (decoratedShip is OneHPShipDecorator)
                    {
                        copiedShip = new OneHPShipDecorator(copiedShip);
                    }
                    else if (decoratedShip is ChangePlaceShipDecorator)
                    {
                        copiedShip = new ChangePlaceShipDecorator(copiedShip);
                    }
                    else
                    {
                        throw new InvalidOperationException("Nieznany dekorator");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Nieznany typ statku.");
            }
            player2Ships.Add(copiedShip);
            foreach (Point point in shipPoints)
            {
                if (point.height >= 0 && point.height < grid.ColumnCount && point.wight >= 0 && point.wight < grid.RowCount)
                {
                    Cell cell = game.boardPlayer2.cells.FirstOrDefault(c => c.point.wight == point.height &&
                    c.point.height == point.wight);

                    if (cell != null)
                    {
                        cell.isShip = true;
                    }

                }
                else
                {
                    MessageBox.Show("Coś poszło nie tak");
                }
            }

            listBox2.Items.Remove(listBox2.SelectedItem);
            listBox2.SelectedIndex = -1;
        }

        private void MoveShip(Keys key, List<Point> shipPoints, DataGridView grid, Board board)
        {
            dataGridView1.CurrentCell = null;
            dataGridView2.CurrentCell = null;
            List<Point> previousShipPoints = new List<Point>(shipPoints);
            int x = 0; int y = 0;
            switch (key)
            {
                case Keys.Up:
                    {
                        x = -1;
                        break;
                    }
                case Keys.Down:
                    {
                        x = 1;
                        break;
                    }
                case Keys.Left:
                    {
                        y = -1;
                        break;
                    }
                case Keys.Right:
                    {
                        y = +1;
                        break;
                    }
                case Keys.E:
                    {
                        if (CanRotateRight(ref shipPoints, board, grid))
                        {
                            RotateRight(ref shipPoints);
                        }
                        else
                        {
                            MessageBox.Show("Nie można obrócić statku");
                        }
                        break;
                    }
                case Keys.R:
                    {
                        if (CanRotateLeft(ref shipPoints, board, grid))
                        {
                            RotateLeft(ref shipPoints);
                        }
                        else
                        {
                            MessageBox.Show("Nie można obrócić statku");
                        }
                        break;
                    }
                case Keys.Enter:
                    {
                        if (!IsAbleToPlaceShip())
                        {
                            MessageBox.Show("Te miejsce jest już zajęte");
                        }
                        else
                        {
                            HighlightShotCells(grid, board);
                            if (currentPlayer == 1)
                            {
                                PlaceShip1(grid);

                                if (listBox1.Items.Count == 0)
                                {
                                    SwitchToPlayer2();
                                }
                            }
                            else
                            {
                                PlaceShip2(grid);

                                if (listBox2.Items.Count == 0)
                                {
                                    HighlightShotCells(dataGridView1, board1);
                                    HighlightShotCells(dataGridView2, board2);
                                    groupBox2.Visible = false;
                                    StartGame();
                                    PlayerTurn();
                                    return;
                                }
                            }
                        }
                        break;
                    }
            }

            if (CanMoveShip(x, y, shipPoints, grid))
            {
                for (int i = 0; i < shipPoints.Count; i++)
                {
                    shipPoints[i] = new Point(shipPoints[i].wight + x, shipPoints[i].height + y);
                }

                ClearGrid(previousShipPoints, grid, board);
                DisplayShipInGrid(shipPoints, grid);
            }
        }

        public void PlaceShip1(DataGridView grid)
        {
            selectedShip = game.gameMode.ships.Find(s => s.getName() == listBox1.SelectedItem.ToString());
            Ship originalShip = selectedShip;

            // Usuwanie dekoratora, jeśli statek jest udekorowany
            while (originalShip is ShipDecorator decorator)
            {
                originalShip = decorator.Ship;
            }

            // Teraz oryginalny statek jest przechowywany w originalShip, bez dekoratora
            if (originalShip is NormalShipType || originalShip is SpecialShipType)
            {
                // Kopiowanie statku
                if (originalShip is NormalShipType normalShip)
                {
                    copiedShip = new NormalShipType(normalShip.getName());
                }
                else if (originalShip is SpecialShipType specialShip)
                {
                    copiedShip = new SpecialShipType(specialShip.getName());
                }

                // Kopiowanie punktów statku
                copiedShip.points = shipPoints;

                // Teraz sprawdzamy, czy statek był dekorowany
                if (selectedShip is ShipDecorator decoratedShip)
                {
                    if (decoratedShip is OneHPShipDecorator)
                    {
                        copiedShip = new OneHPShipDecorator(copiedShip);
                    }
                    else if (decoratedShip is ChangePlaceShipDecorator)
                    {
                        copiedShip = new ChangePlaceShipDecorator(copiedShip);
                    }
                    else
                    {
                        throw new InvalidOperationException("Nieznany dekorator");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Nieznany typ statku.");
            }
            player1Ships.Add(copiedShip);
            foreach (Point point in shipPoints)
            {
                if (point.height >= 0 && point.height < grid.ColumnCount && point.wight >= 0 && point.wight < grid.RowCount)
                {
                    Cell cell = game.boardPlayer1.cells.FirstOrDefault(c => c.point.wight == point.height &&
                    c.point.height == point.wight);

                    if (cell != null)
                    {
                        cell.isShip = true;
                    }

                }
                else
                {
                    MessageBox.Show("Coś poszło nie tak");
                }
            }

            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox1.SelectedIndex = -1;
        }

        public void StartGame()
        {
            panel1.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            currentPlayer = 1;
            currentPlayerBoard = game.boardPlayer1;
            currentDataGridView = dataGridView1;
            if (game.player1 is ComputerPlayer && game.player2 is ComputerPlayer)
            {
                button1.Visible = false;
            }
            button1.Visible = true;
            dataGridView1.Enabled = true;
            dataGridView2.Enabled = true;
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            //groupBox1.Show();
            //groupBox2.Show();
        }

        public void PlayerView(DataGridView grid1, DataGridView grid2, Board board1, Board board2)
        {
            HighlightShotCells(grid1, board1);
            HighlightShotCells(grid2, board2);
            grid1.Visible = false; grid2.Visible = false;
            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                for (int j = 0; j < grid1.Columns.Count; j++)
                {
                    var cell = board1.cells.FirstOrDefault(c => c.point.wight == j && c.point.height == i);
                    if (cell != null)
                    {
                        if (cell.isShip == false && cell.wasShot == false)
                        {
                            grid1.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.White;
                        }
                        else if (cell.isShip == true && cell.wasShot == false)
                        {
                            grid1.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = shipColor;
                        }
                        else if (cell.isShip == false && cell.wasShot == true)
                        {
                            grid1.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.Green;
                        }
                        else if (cell.isShip == true && cell.wasShot == true)
                        {
                            grid1.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono komórki");
                    }
                }
            }

            for (int i = 0; i < grid2.Rows.Count; i++)
            {
                for (int j = 0; j < grid2.Columns.Count; j++)
                {
                    var cell = board2.cells.FirstOrDefault(c => c.point.wight == j && c.point.height == i);
                    if (cell != null)
                    {
                        if (cell.isShip == false && cell.wasShot == false)
                        {
                            grid2.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.White;
                        }
                        else if (cell.isShip == true && cell.wasShot == false)
                        {
                            grid2.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.White;
                        }
                        else if (cell.isShip == false && cell.wasShot == true)
                        {
                            grid2.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.Green;
                        }
                        else if (cell.isShip == true && cell.wasShot == true)
                        {
                            grid2.Rows[cell.point.height].Cells[cell.point.wight].Style.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono komórki");
                    }
                }
            }
            grid1.Visible = true; grid2.Visible = true;
        }

        public void Turn1()
        {
            groupBox1.Hide(); groupBox2.Hide(); dataGridView3.Hide(); label1.Hide();
            MessageBox.Show("Teraz rusza się gracz: " + game.player1.name);
            groupBox1.Show(); groupBox2.Show(); dataGridView3.Show(); label1.Show();
            dataGridView1.ClearSelection();
            PlayerView(dataGridView1, dataGridView2, board1, board2);
            dataGridView2.Enabled = true;
            dataGridView1.Enabled = false;
            if (game.player1 is HumanPlayer)
            {

            }
            else
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox1.Show();
                groupBox2.Show();
                Point p = game.player1.Shot(board1);
                ShotPlayer1(p);
            }
        }

        public void PlayerTurn()
        {
            listBox1.Visible = false;
            listBox2.Visible = false;
            if(game.player1 is ComputerPlayer && game.player2 is ComputerPlayer)
            {
                if(dataGridView3.Rows.Count % 10 == 0)
                {
                    DialogResult result = MessageBox.Show("Czy chcesz zakończyć grę?", "Zakończenie gry", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        return;
                    }
                }
            }
            if (currentPlayer == 1)
            {
                Turn1();
            }
            else
            {
                Turn2();
            }
        }

        public void Turn2()
        {
            if (game.player1 is HumanPlayer && game.player2 is HumanPlayer)
                groupBox1.Hide(); groupBox2.Hide(); dataGridView3.Hide(); label1.Hide();
            MessageBox.Show("Teraz rusza się gracz: " + game.player2.name);
            dataGridView2.ClearSelection();
            groupBox1.Show(); groupBox2.Show(); dataGridView3.Show(); label1.Show();
            if (!(game.player1 is HumanPlayer && game.player2 is ComputerPlayer))
                PlayerView(dataGridView2, dataGridView1, board2, board1);
            dataGridView1.Enabled = true;
            dataGridView2.Enabled = false;
            if (game.player2 is HumanPlayer)
            {

            }
            else
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox1.Show();
                groupBox2.Show();
                Point p = game.player2.Shot(board2);
                ShotPlayer2(p);
            }
        }

        private void SwitchToPlayer2()
        {
            groupBox1.Visible = false;

            groupBox2.Visible = true;

            PutShipsOnBoard(game.player2.name);

            currentPlayer = 2;
            currentPlayerBoard = game.boardPlayer2;
            currentDataGridView = dataGridView2;

            if (game.player2 is ComputerPlayer)
            {
                PlaceShipsRandomly(board2);
                StartGame();
            }
        }

        private void ClearGrid(List<Point> previousShipPoints, DataGridView grid, Board board)
        {
            foreach (Point point in previousShipPoints)
            {
                if (point.height >= 0 && point.height < grid.ColumnCount && point.wight >= 0 && point.wight < grid.RowCount)
                {
                    Cell cell = board.cells.FirstOrDefault(c => c.point.wight == point.height &&
                                        c.point.height == point.wight);

                    if (cell != null && !cell.isShip)
                    {
                        grid.Rows[point.wight].Cells[point.height].Style.BackColor = Color.White;
                    }
                }
            }
        }

        private void DisplayShipInGrid(List<Point> shipPoints, DataGridView grid)
        {
            foreach (Point point in shipPoints)
            {
                if (point.wight >= 0 && point.wight < grid.RowCount && point.height >= 0 && point.height < grid.ColumnCount)
                {
                    grid.Rows[point.wight].Cells[point.height].Style.BackColor = shipColor;
                }
            }
        }

        private bool CanMoveShip(int deltaX, int deltaY, List<Point> shipPoints, DataGridView grid)
        {
            foreach (Point point in shipPoints)
            {
                int newX = point.wight + deltaX;
                int newY = point.height + deltaY;

                if (newX < 0 || newX >= grid.RowCount || newY < 0 || newY >= grid.ColumnCount)
                {
                    return false;
                }
            }
            return true;
        }

        private void HighlightShotCells(DataGridView grid, Board board)
        {
            for (int row = 0; row < grid.RowCount; row++)
            {
                for (int col = 0; col < grid.ColumnCount; col++)
                {
                    Cell cell = board.cells.FirstOrDefault(c => c.point.wight == col && c.point.height == row);

                    if (cell != null)
                    {
                        if (cell.isShip)
                        {

                        }
                        else
                        {
                            grid.Rows[row].Cells[col].Style.BackColor = Color.White;
                        }
                    }
                }
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell = null;
            HighlightShotCells(dataGridView2, game.boardPlayer2);
            if (listBox2.SelectedIndex != -1)
            {
                if (currentPlayer == 2)
                {
                    selectedShip = game.gameMode.ships.Find(s => s.getName() == listBox2.SelectedItem.ToString());
                    if (selectedShip != null)
                    {
                        shipPoints = new List<Point>(selectedShip.points);

                        DisplayShipInGrid(shipPoints, dataGridView2);
                    }
                    else
                    {
                        MessageBox.Show("Coś poszło nie tak");
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            HighlightShotCells(dataGridView1, game.boardPlayer1);
            if (listBox1.SelectedIndex != -1)
            {
                if (currentPlayer == 1)
                {
                    selectedShip = game.gameMode.ships.Find(s => s.getName() == listBox1.SelectedItem.ToString());
                    if (selectedShip != null)
                    {
                        shipPoints = new List<Point>(selectedShip.points);

                        DisplayShipInGrid(shipPoints, dataGridView1);
                    }
                    else
                    {
                        MessageBox.Show("Coś poszło nie tak");
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && selectedShip != null)
            {
                MoveShip(e.KeyCode, shipPoints, currentDataGridView, currentPlayerBoard);
            }
            else if (listBox2.SelectedIndex != -1 && selectedShip != null)
            {
                MoveShip(e.KeyCode, shipPoints, currentDataGridView, currentPlayerBoard);
            }
        }

        public void PutShipsOnBoard(string name)
        {
            MessageBox.Show("Teraz " + name + " będzie ustawiał statki na swojej planszy");
        }

        public bool LoadShips()
        {
            List<Ship> ships = game.gameMode.ships;
            Models.Point lastPoint;
            bool p1 = false, p2 = false;
            if (board1.cells.Any(c => c.isShip == true))
            {
                p1 = true;
            }
            if (board2.cells.Any(c => c.isShip == true))
            {
                p2 = true;
            }

            if (p1 && p2)
            {
                return true;
            }
            else if (p1 == true && p2 == false)
            {
                for (int i = 0; i < ships.Count; i++)
                {
                    listBox2.Items.Add(ships[i].getName());
                }
            }
            else if (p1 == false && p2 == true)
            {
                for (int i = 0; i < ships.Count; i++)
                {
                    listBox1.Items.Add(ships[i].getName());
                }
            }
            else
            {
                for (int i = 0; i < ships.Count; i++)
                {
                    listBox1.Items.Add(ships[i].getName());
                    listBox2.Items.Add(ships[i].getName());
                }
            }
            return false;
        }

        public void NameRowsAndColumns(DataGridView data)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                char letter = (char)('a' + i);
                data.Rows[i].HeaderCell.Value = letter.ToString();
            }

            for (int i = 0; i < data.Columns.Count; i++)
            {
                int number = i + 1;
                data.Columns[i].HeaderCell.Value = number.ToString();
            }
        }


        private void DrawBoard(Board board, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            int maxX = board.cells.Max(cell => cell.point.height) + 1;
            int maxY = board.cells.Max(cell => cell.point.wight) + 1;

            dataGridView.ColumnCount = maxY;
            dataGridView.RowCount = maxX;

            int cellWidth = dataGridView.ClientSize.Width / (maxX + 1);
            int cellHeight = dataGridView.ClientSize.Height / (maxY + 1);

            for (int i = 0; i < maxY; i++)
            {
                dataGridView.Columns[i].Width = cellHeight;
            }
            for (int i = 0; i < maxX; i++)
            {
                dataGridView.Rows[i].Height = cellWidth;
            }

            foreach (var cell in board.cells)
            {
                int x = cell.point.height;
                int y = cell.point.wight;

                dataGridView[y, x].Value = "";
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Poddałeś się");
            WinView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            dataGridView3.Visible = true;
            StartGame();
            PlayerTurn();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == 0)
            {
                this.BackColor = Color.White;
            }
            else if (listBox3.SelectedIndex == 1)
            {
                this.BackColor = Color.Red;
            }
            else if (listBox3.SelectedIndex == 2)
            {
                this.BackColor = Color.Green;
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex == 0)
            {
                shipColor = Color.Black;
            }
            else if (listBox4.SelectedIndex == 1)
            {
                shipColor = Color.Orange;
            }
            else if(listBox4.SelectedIndex == 2)
            {
                if(game.player1 is HumanPlayer)
                {
                    var user = db.users.FirstOrDefault(u => u.Id == game.player1.Id);
                    if(user.level.level < 4)
                    {
                        MessageBox.Show("Ta zawartość nie jest odblokowana!");
                    }
                    else
                    {
                        shipColor = Color.Pink;
                    }
                }
                else
                {
                    shipColor = Color.Pink;
                }
            }
        }
    }
}