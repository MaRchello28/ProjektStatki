using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class CellOnBoard : Cell
    {
        public CellOnBoard() { }

        public bool isShip()
        {
            return false;
        }

        public bool wasShot()
        {
            return true;
        }

        public Point getPoint()
        {
            return new Point(0, 0);
        }

        public void display()
        {

        }
    }
}
