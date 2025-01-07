using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektStatki.Models.Composite;

namespace ProjektStatki.Models
{
    public class Board
    {
        public CellOnBoard cellOnBoard;
        public Player playerBoard { get; set; }
        public Board(CellOnBoard cellOnBoard, Player player) 
        { 
            this.cellOnBoard = cellOnBoard;
            this.playerBoard = player;
        }

        public void ShowBoard()
        {

        }
    }
}
