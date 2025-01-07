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
        Ship wrappe;
        public ShipDecorator(Ship ship)
        {
            wrappe = ship;
        }

        public void Execute()
        {

        }
    }
}
