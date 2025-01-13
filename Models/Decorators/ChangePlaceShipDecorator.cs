using ProjektStatki.Models.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjektStatki.Models.Decorators
{
    public class ChangePlaceShipDecorator : ShipDecorator
    {
        public Ship Ship { get; set; }
        public ChangePlaceShipDecorator(Ship ship) : base(ship)
        {
            this.Ship = ship;
        }

        public void Execute(int x, int y, Board board)
        {
            int count = 0;
            //Ship.Execute(x, y);
            while (ChangePlace(x, y, board)) 
            { 
                if(count > 20)
                {
                    break;
                }
                count++;
            }
        }

        private bool ChangePlace(int maxX, int maxY, Board board)
        {
            Random _random = new Random();
            int newX = _random.Next(0, maxX + 1);
            int newY = _random.Next(0, maxY + 1);

            bool isHorizontal = _random.Next(0, 2) == 0;

            int shipLength = this.Ship.points.Count;

            List<Point> newPoints = new List<Point>();

            if (isHorizontal)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    newPoints.Add(new Point(newX + i, newY));
                }
            }
            else
            {
                for (int i = 0; i < shipLength; i++)
                {
                    newPoints.Add(new Point(newX, newY + i));
                }
            }

            if (CanPlaceShip(newPoints, board))
            {
                this.Ship.points = newPoints;
                Console.WriteLine("Statek " + this.Ship.getName() + " został przeniesiony na nową pozycję.");
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CanPlaceShip(List<Point> newPoints, Board board)
        {
            for(int i=0; i< newPoints.Count; i++)
            {
                Cell cell = board.cells.FirstOrDefault(c => c.point == newPoints[i]);
                if(cell != null)
                {
                    if (cell.wasShot || cell.isShip)
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Cell było null");
                }
            }

            return true;
        }
    }
}
