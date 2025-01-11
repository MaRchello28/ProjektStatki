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

namespace ProjektStatki.Views
{
    public partial class GameView : Form
    {
        Game game;
        int currentPlayer = 1;
        private List<Point> shipPoints = new List<Point>();
        private Ship selectedShip = null;
        Board currentPlayerBoard = null;
        DataGridView currentDataGridView = null;
        public GameView(Game game)
        {
            InitializeComponent();
            this.game = game;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            listBox1.KeyDown += new KeyEventHandler(listBox1_KeyDown);
            listBox2.KeyDown += new KeyEventHandler(listBox2_KeyDown);
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
            LoadShips();
            PutShipsOnBoard(game.player1.name);
            currentPlayerBoard = game.boardPlayer1;
            currentDataGridView = dataGridView1;
            dataGridView1.CurrentCell = null;
            dataGridView2.CurrentCell = null;
        }

        private bool IsAbleToPlaceShip()
        {
            Board board = currentPlayerBoard;
            foreach (var checkingPoint in shipPoints)
            {
                if (board.cells.Any(c => c.isShip == true && c.point.height == checkingPoint.height && c.point.wight == checkingPoint.wight))
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
                if (point.wight < 0 || point.wight >= grid.ColumnCount || point.height < 0 || point.height >= grid.RowCount)
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
                if (point.wight < 0 || point.wight >= grid.ColumnCount || point.height < 0 || point.height >= grid.RowCount)
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
                            if (currentPlayer == 1)
                            {
                                foreach (Point point in shipPoints)
                                {
                                    if (point.height >= 0 && point.height < grid.ColumnCount && point.wight >= 0 && point.wight < grid.RowCount)
                                    {
                                        Cell cell = game.boardPlayer1.cells.FirstOrDefault(c => c.point.wight == point.wight &&
                                        c.point.height == point.height);

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

                                if (listBox1.Items.Count == 0)
                                {
                                    SwitchToPlayer2();
                                }
                            }
                            else
                            {
                                foreach (Point point in shipPoints)
                                {
                                    if (point.height >= 0 && point.height < grid.ColumnCount && point.wight >= 0 && point.wight < grid.RowCount)
                                    {
                                        Cell cell = game.boardPlayer2.cells.FirstOrDefault(c => c.point.wight == point.wight &&
                                        c.point.height == point.height);

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

                                if (listBox2.Items.Count == 0)
                                {
                                    StartGame();
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

        public void StartGame()
        {
            MessageBox.Show("Teraz rozpocznie się gra. Rusza się gracz: "+ game.player1.name);
            currentPlayer = 1;
            currentPlayerBoard = game.boardPlayer1;
            currentDataGridView = dataGridView1;
        }

        public void PlayerTurn()
        {

        }

        private void SwitchToPlayer2()
        {
            groupBox1.Visible = false;

            groupBox2.Visible = true;

            PutShipsOnBoard(game.player2.name);

            currentPlayer = 2;
            currentPlayerBoard = game.boardPlayer2;
            currentDataGridView = dataGridView2;
        }

        private void ClearGrid(List<Point> previousShipPoints, DataGridView grid, Board board)
        {
            foreach (Point point in previousShipPoints)
            {
                if (point.height >= 0 && point.height < grid.ColumnCount && point.wight >= 0 && point.wight < grid.RowCount)
                {
                    Cell cell = board.cells.FirstOrDefault(c => c.point.wight == point.wight &&
                                        c.point.height == point.height);

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
                    grid.Rows[point.wight].Cells[point.height].Style.BackColor = Color.Black;
                }
            }
        }

        private bool CanMoveShip(int deltaX, int deltaY, List<Point> shipPoints, DataGridView grid)
        {
            foreach (Point point in shipPoints)
            {
                int newX = point.wight + deltaX;
                int newY = point.height + deltaY;

                if (newX < 0 || newX >= grid.ColumnCount || newY < 0 || newY >= grid.RowCount)
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
                    Cell cell = board.cells.FirstOrDefault(c => c.point.wight == row && c.point.height == col);

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
            else if(listBox2.SelectedIndex != -1 && selectedShip != null)
            {
                MoveShip(e.KeyCode, shipPoints, currentDataGridView, currentPlayerBoard);
            }
        }

        public void PutShipsOnBoard(string name)
        {
            MessageBox.Show("Teraz " + name + " będzie ustawiał statki na swojej planszy");
        }

        public void LoadShips()
        {
            List<Ship> ships = game.gameMode.ships;
            Models.Point lastPoint;

            for (int i = 0; i < ships.Count; i++)
            {
                listBox1.Items.Add(ships[i].getName());
                listBox2.Items.Add(ships[i].getName());
            }
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

            int maxX = board.cells.Max(cell => cell.point.wight) + 1;
            int maxY = board.cells.Max(cell => cell.point.height) + 1;

            dataGridView.ColumnCount = maxX;
            dataGridView.RowCount = maxY;

            // Obliczanie szerokości i wysokości komórek w oparciu o rozmiar DataGridView
            int cellWidth = dataGridView.ClientSize.Width / (maxX + 1);
            int cellHeight = dataGridView.ClientSize.Height / (maxY + 1);

            for (int i = 0; i < maxX; i++)
            {
                dataGridView.Columns[i].Width = cellWidth;
            }
            for (int i = 0; i < maxY; i++)
            {
                dataGridView.Rows[i].Height = cellHeight;
            }

            foreach (var cell in board.cells)
            {
                int x = cell.point.wight;
                int y = cell.point.height;

                dataGridView[x, y].Value = "";
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

    }
}
