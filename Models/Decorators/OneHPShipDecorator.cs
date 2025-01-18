using ProjektStatki.Models.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Decorators
{
    public class OneHPShipDecorator:ShipDecorator
    {
        public Ship Ship { get; set; }
        public OneHPShipDecorator(Ship ship) : base(ship)
        {
            this.Ship = ship;
        }

        public override void Execute(int x, int y, Board board)
        {
            foreach(Point point in Ship.points)
            {
                var changeCell = board.cells.FirstOrDefault(c => c.point.wight == point.height && c.point.height == point.wight);
                if(changeCell != null)
                {
                    changeCell.wasShot = true;
                }
            }
        }
    }
}
