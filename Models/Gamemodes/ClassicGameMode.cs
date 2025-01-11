using ProjektStatki.Models.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Gamemodes
{
    public class ClassicGameMode:GameMode
    {
        public bool isRanked { get; set; }
        public Board board1 { get; set; }
        public Board board2 { get; set; }
        public int countShipsOnBoard { get; set; }
        public int countSpecialShips { get; set; }
        public List<Ship> ships { get; set; }
        public ClassicGameMode(bool isRanked)
        {
            this.isRanked = isRanked;
            board1 = SetBoard(10, 10);
            board2 = SetBoard(10, 10);
            countShipsOnBoard = SetCountShipsOnBoard(5);
            countSpecialShips = SetCountSpecialShips(0);
            ships = SelectShips();
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
        public List<Ship> SelectShips()
        {
            List<Ship> selectedShips = new List<Ship>();
            NormalShipCreator normalShipCreator = new NormalShipCreator();

            selectedShips.Add(normalShipCreator.createShip(2, "Łudka"));
            selectedShips.Add(normalShipCreator.createShip(3, "Liniowiec-1"));
            selectedShips.Add(normalShipCreator.createShip(3, "Liniowiec-2"));
            selectedShips.Add(normalShipCreator.createShip(4, "Pancernik"));
            selectedShips.Add(normalShipCreator.createShip(5, "Lotniskowiec"));

            return selectedShips;
        }
        public void PlaceShip()
        {

        }
        public void PlayTurn()
        {

        }
    }
}
