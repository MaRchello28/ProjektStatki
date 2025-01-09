using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class Board
    {
        public Player? player {  get; set; }
        public List<Cell> cells = new List<Cell>();
        public Board(int x, int y) 
        {
            this.player = null;
            CreateBoard(x,y);
        }

        public Board(Player player, int x, int y)
        {
            this.player = player;
            CreateBoard(x, y);
        }

        public List<Cell> CreateBoard(int x, int y)
        {
            for(int i=0; i<x; i++)
            {
                for (int j=0; j<y; j++)
                {
                    cells.Add(new Cell(false, false, new Point(i, y)));
                }
            }
            return cells;
        }
    }
}
