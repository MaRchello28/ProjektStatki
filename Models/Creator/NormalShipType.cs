using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Creator
{
    public class NormalShipType : Ship
    {
        public List<Point> points {  get; set; }
        public string name;
        public int Id {  get; set; }

        public NormalShipType(string name)
        {
            points = new List<Point>();
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

        public Point fire(int x, int y)
        {
            Point point = new Point(x, y);
            return point;
        }

        public void Execute(int x, int y, Board board)
        {

        }
    }
}
