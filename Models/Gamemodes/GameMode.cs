using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Gamemodes
{
    public interface GameMode
    {
        public bool isRanked { get; set; }
        public Board SetBoard();
        public int SetCountShipsOnBoard();
        public int SetCountSpecialShips();
        public void PlaceShip();
        public void PlayTurn();
    }
}
