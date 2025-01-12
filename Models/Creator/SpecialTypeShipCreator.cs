using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Creator
{
    public class SpecialTypeShipCreator
    {
        public SpecialTypeShipCreator() { }
        public Ship createShip(int type, string name) // type to jaki to statek ma byc
        {
            SpecialShipType ship = new SpecialShipType(name);
            List<Point> points = new List<Point>();
            switch (type)
            {
                case 0:
                    {
                        points.Add(new Point(0, 1));
                        points.Add(new Point(0, 2));
                        points.Add(new Point(1, 1));
                        points.Add(new Point(0, 3));
                        points.Add(new Point(1, 2));
                        ship.points = points;
                        return ship;
                    }
                case 1:
                    {
                        points.Add(new Point(0, 1));
                        points.Add(new Point(0, 2));
                        points.Add(new Point(1, 2));
                        points.Add(new Point(2, 2));
                        ship.points = points;
                        return ship;
                    }
                default:
                    {
                        return ship;
                    }
            }
        }
    }
}
