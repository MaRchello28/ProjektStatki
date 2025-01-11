using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class Cell
    {
        public bool isShip { get; set; }
        public bool wasShot { get; set; }
        public Point point { get; set; }
        public Cell(bool isShip, bool wasShot, Point point) 
        { 
            this.isShip = isShip;
            this.wasShot = wasShot;
            this.point = point;
        }

        public Cell(Cell otherCell)
        {
            this.wasShot = otherCell.wasShot;
            this.isShip = otherCell.isShip;
            this.point = new Point(otherCell.point);
        }
    }
}
