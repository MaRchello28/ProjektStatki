using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public interface Ship
    {
        public int Id { get; set; }
        public List<Point> getPoints();
        string getName();
        Ship putShipOnBoard();
        Point fire(int x, int y);
    }
}
