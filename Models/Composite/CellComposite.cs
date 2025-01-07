using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Composite
{
    public class CellComposite : Cell
    {
        private List<Cell> cells = new List<Cell>();

        public CellComposite() { }

        public void AddCell(Cell cell)
        {
            cells.Add(cell);
        }

        public void RemoveCell(Cell cell)
        {
            cells.Remove(cell);
        }

        public List<Cell> GetChildren()
        {
            return cells;
        }

        public bool isShip()
        {
            return false;
        }

        public bool wasShot()
        {
            return false;
        }

        public Point getPoint()
        {
            return new Point(0, 0);
        }

        public void display()
        {

        }
    }
}
