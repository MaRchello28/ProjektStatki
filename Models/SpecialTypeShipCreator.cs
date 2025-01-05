using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class SpecialTypeShipCreator
    {
        public SpecialTypeShipCreator() { }
        public Ship createShip()
        {
            SpecialShipType spec = new SpecialShipType("korweta");
            return spec;
        }
    }
}
