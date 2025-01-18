using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Decorator
{
    public abstract class ShipDecorator : Ship
    {
        public Ship Ship;

        protected ShipDecorator(Ship ship)
        {
            this.Ship = ship;
        }

        public int Id { get { return Ship.Id; } set { Ship.Id = value; } }
        public List<Point> points { get { return Ship.points; } set { Ship.points = value; } }

        public List<Point> getPoints()
        {
            return Ship.getPoints();
        }

        public string getName()
        {
            return Ship.getName();
        }

        public Ship putShipOnBoard()
        {
            return Ship.putShipOnBoard();
        }

        public Point fire(int x, int y)
        {
            return Ship.fire(x, y);
        }

        public abstract void Execute(int x, int y, Board board);
    }
}
