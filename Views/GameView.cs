using ProjektStatki.Models;
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
    public partial class GameView : Form
    {
        Game game;
        public GameView(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void GameView_Load(object sender, EventArgs e)
        {
            DrawBoard(game.boardPlayer1, dataGridView1);
            DrawBoard(game.boardPlayer2, dataGridView1);
        }

        private void DrawBoard(Board board, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            int maxX = board.cells.Max(cell => cell.point.wight) + 1;
            int maxY = board.cells.Max(cell => cell.point.height) + 1;

            dataGridView.ColumnCount = maxX;
            dataGridView.RowCount = maxY;

            for (int i = 0; i < maxX; i++)
            {
                dataGridView.Columns[i].Width = 30;
            }
            for (int i = 0; i < maxY; i++)
            {
                dataGridView.Rows[i].Height = 30;
            }

            foreach (var cell in board.cells)
            {
                int x = cell.point.wight;
                int y = cell.point.height;

                // Set cell value or style
                dataGridView[x, y].Value = cell.wasShot ? "O" : "";
                //dataGridView[x, y].Style.BackColor = cell.IsHit ? Color.Red : Color.White;
            }
        }
    }
}
