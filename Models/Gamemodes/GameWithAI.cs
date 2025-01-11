using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Gamemodes
{
    public class GameWithAI
    {
        public bool isRanked { get; set; }
        public GameWithAI()
        {

        }
        public Board SetBoard(int x, int y)
        {
            return new Board(x, y);
        }
        public int SetCountShipsOnBoard(int value)
        {
            return value;
        }
        public int SetCountSpecialShips(int value)
        {
            return value;
        }
        public void PlaceShip()
        {

        }
        public void PlayTurn()
        {

        }
    }
}
