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
        public Board SetBoard(int x, int y);
        public int SetCountShipsOnBoard(int value);
        public int SetCountSpecialShips(int value);
        public void PlaceShip();
        public void PlayTurn();
    }
}
