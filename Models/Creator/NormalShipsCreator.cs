using System;
using System.Collections.Generic;

namespace ProjektStatki.Models.Creator
{
    class NormalShipCreator : ShipCreator
    {
        public NormalShipCreator()
        {

        }

        public Ship createShip(int x, string name)
        {
            List<Point> points = new List<Point>();
            NormalShipType ship = new NormalShipType(name);
            for (int i = 0; i < x; i++)
            {
                points.Add(new Point(0, i));
            }
            ship.points = points;
            return ship;
        }

        public void Execute()
        {

        }
    }
}
