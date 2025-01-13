using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Decorator
{
    //Dodać do tego dziedziczące konkretne dekoratory
    public class ShipDecorator
    {
        Ship wrappedShip;
        public ShipDecorator(Ship ship)
        {
            wrappedShip = ship;
        }

        public virtual void Execute()
        {
            wrappedShip.Execute();
        }
    }
}
