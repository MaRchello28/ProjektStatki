using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Gamemodes
{
    public class ClassicGameMode
    {
        public bool isRanked { get; set; }
        public Board board { get; set; }
        public int countShipsOnBoard { get; set; }
        public int countSpecialShips { get; set; }
        public List<Ship> ships { get; set; }
        public ClassicGameMode(bool isRanked)
        {
            this.isRanked = isRanked;
            board = SetBoard(10, 10);
            countShipsOnBoard = SetCountShipsOnBoard(5);
            countSpecialShips = SetCountSpecialShips(0);
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
        public void SelectShips()
        {

        }
        public void PlaceShip()
        {

        }
        public void PlayTurn()
        {

        }
    }
}
