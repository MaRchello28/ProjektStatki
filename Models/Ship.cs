using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public interface Ship
    {
        List<Point> getPoints();
        string getName();
        Ship putShipOnBoard();
        Point fire();
    }
}
