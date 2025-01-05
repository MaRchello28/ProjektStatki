using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class SpecialShipType : Ship
    {
        private List<Point> points;
        private string name;

        public SpecialShipType(string name)
        {
            this.points = new List<Point>();
            this.name = name;
        }

        public List<Point> getPoints()
        {
            return points;
        }

        public string getName()
        {
            return name;
        }

        public Ship putShipOnBoard()
        {
            return this;
        }

        public Point fire()
        {
            int x = 0, y = 0;
            Point point = new Point(x, y);
            return point;
        }
    }
}
