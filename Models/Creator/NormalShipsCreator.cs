using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Creator
{
    public class NormalShipsCreator
    {
        public NormalShipsCreator() { }
        public Ship createShip()
        {
            NormalShipType normal = new NormalShipType("łutka");
            return normal;
        }
    }
}
