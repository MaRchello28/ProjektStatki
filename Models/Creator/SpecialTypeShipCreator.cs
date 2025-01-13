using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Creator
{
    public class SpecialTypeShipCreator
    {
        public SpecialTypeShipCreator() { }
        public Ship createShip(List<Point> pointsToCreate, string name)
        {
            SpecialShipType spec;
            foreach (var point in pointsToCreate)
            {
                bool hasNeighbor = pointsToCreate.Any(other =>
                    (point != other) &&
                    (Math.Abs(point.wight - other.wight) + Math.Abs(point.height - other.height) == 1)
                );

                if (!hasNeighbor)
                {
                    throw new Exception("Nie można utworzyć takiego statku");
                }

                if (pointsToCreate.GroupBy(p => new { p.wight, p.height }).Any(g => g.Count() > 1))
                {
                    throw new Exception("Znaleziono zduplikowane punkty.");
                }

                if (pointsToCreate.Any(p => p.wight < 0 || p.height < 0))
                {
                    throw new Exception("Znaleziono punkt o współrzędnych mniejszych niż 0.");
                }

            }
            spec = new SpecialShipType(name);
            spec.points = pointsToCreate;
            return spec;

        }
    }
}
