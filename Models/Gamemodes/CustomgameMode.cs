using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Gamemodes
{
    public class CustomgameMode:GameMode
    {
        public bool isRanked { get; set; }
        public Board board1 { get; set; }
        public Board board2 { get; set; }
        public int countShipsOnBoard { get; set; }
        public int countSpecialShips { get; set; }
        public List<Ship> ships { get; set; }
        public string name { get; set; }

        public CustomgameMode(Board board1, Board board2, int countShipsOnBoard, int countSpecialShips, List<Ship> ships)
        {
            isRanked = false;
            this.board1 = board1;
            this.board2 = board2;
            this.countShipsOnBoard = countShipsOnBoard;
            this.countSpecialShips = countSpecialShips;
            this.ships = ships;
            name = "CustomgameMode";
        }

        public Board SetBoard(int x, int y)
        {
            return new Board(x, y);
        }
        public int SetCountShipsOnBoard(int value)
        {
            return countShipsOnBoard;
        }
        public int SetCountSpecialShips(int value)
        {
            return countSpecialShips;
        }
        public void PlaceShip()
        {

        }
        public void PlayTurn()
        {

        }
    }
}
