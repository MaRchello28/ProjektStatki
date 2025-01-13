using ProjektStatki.Models.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Decorators
{
    public class ChangePlaceShipDecorator : ShipDecorator
    {
        public ChangePlaceShipDecorator(Ship ship) : base(ship)
        {
        }

        public override void Execute()
        {
            base.Execute();
            ChangePlace();
        }

        private void ChangePlace()
        {
            Console.WriteLine("Changing the ship's place...");
        }
    }
}
