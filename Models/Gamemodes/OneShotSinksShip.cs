using ProjektStatki.Models.Creator;
using ProjektStatki.Models.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Gamemodes
{
    public class OneShotSinksShip : GameMode
    {
        public bool isRanked { get; set; }
        public Board board1 { get; set; }
        public Board board2 { get; set; }
        public int countShipsOnBoard { get; set; }
        public int countSpecialShips { get; set; }
        public List<Ship> ships { get; set; }
        public string name { get; set; }
        public OneShotSinksShip() 
        { 
            isRanked = false;
            board1 = SetBoard(10, 10);
            board2 = SetBoard(10, 10);
            countShipsOnBoard = 5;
            countSpecialShips = 2;
            this.ships = SelectShips();
            name = "OneShotSinksShip";
        }

        public List<Ship> SelectShips()
        {
            OneHPShipDecorator decorator;
            List<Point> specPoints5 = new List<Point>()
            {
                new Point(1,0), new Point(0,1), new Point(1,1), new Point(2,1), new Point (1,2)
            };
            List<Point> specPoints1 = new List<Point>()
            {
                new Point(0,0), new Point(0,1), new Point(1,0)
            };
            List<Ship> selectedShips = new List<Ship>();

            NormalShipCreator normalShipCreator = new NormalShipCreator();
            SpecialTypeShipCreator special = new SpecialTypeShipCreator();

            selectedShips.Add(normalShipCreator.createShip(2, "Łudka"));
            selectedShips.Add(normalShipCreator.createShip(3, "Liniowiec-1"));
            selectedShips.Add(normalShipCreator.createShip(5, "Lotniskowiec"));

            selectedShips.Add(special.createShip(specPoints5, "Plus"));
            selectedShips.Add(special.createShip(specPoints1, "Szalupa"));

            //Dekorowanie
            selectedShips[0] = new OneHPShipDecorator(selectedShips[0]);
            selectedShips[1] = new OneHPShipDecorator(selectedShips[1]);
            selectedShips[2] = new OneHPShipDecorator(selectedShips[2]);
            selectedShips[3] = new OneHPShipDecorator(selectedShips[3]);
            selectedShips[4] = new OneHPShipDecorator(selectedShips[4]);

            return selectedShips;
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
