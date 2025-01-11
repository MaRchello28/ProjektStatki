using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class Point
    {
        public int wight {  get; set; }
        public int height { get; set; }
        public Point(int x, int y)
        {
            this.wight = x;
            this.height = y;
        }

        public Point(Point otherPoint)
        {
            this.wight = otherPoint.wight;
            this.height = otherPoint.height;
        }
    }
}
