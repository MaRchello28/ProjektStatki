using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public interface Cell
    {
        bool isShip();
        bool wasShot();
        Point getPoint();
        void display();
    }
}
