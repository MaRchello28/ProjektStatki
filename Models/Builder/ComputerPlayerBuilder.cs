using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Builder
{
    public class ComputerPlayerBuilder : PlayerBuilder
    {
        private ComputerPlayer _computerPlayer;
        private Random _random;

        public ComputerPlayerBuilder()
        {
            _random = new Random();
            reset();
        }

        public void reset()
        {
            _computerPlayer = new ComputerPlayer("DefaultBot", 1);
        }

        public void createSteps()
        {
            
            _computerPlayer.name = "EasyBot";
            _computerPlayer.DifficultyLevel = 1;
            _computerPlayer.PendingShots.Clear();
        }

        public void EasyMode(Board board)
        {
            
            Point target;

            if (_computerPlayer.PendingShots.Count > 0)
            {
                // Strzelanie wokół trafionego statku
                target = _computerPlayer.PendingShots[0];
                _computerPlayer.PendingShots.RemoveAt(0);
            }
            else
            {
                // Losowy strzał
                target = GetRandomPoint(board);
            }

            Console.WriteLine($"{_computerPlayer.name} shoots at ({target.wight}, {target.height})");

            bool hit = ShootAt(board, target);

            if (hit)
            {
                Console.WriteLine($"Hit at ({target.wight}, {target.height})!");
                AddSurroundingPoints(board, target);
            }
            else
            {
                Console.WriteLine($"Miss at ({target.wight}, {target.height}).");
            }
        }

        private Point GetRandomPoint(Board board)
        {
            List<Cell> availableCells = board.cells
                .Where(c => !c.wasShot)
                .ToList();

            if (!availableCells.Any())
            {
                throw new InvalidOperationException("Brak celów do strzału.");
            }

            Cell randomCell = availableCells[_random.Next(availableCells.Count)];
            return randomCell.point;
        }

        private bool ShootAt(Board board, Point target)
        {
            var cell = board.cells.FirstOrDefault(c => c.point.wight == target.wight && c.point.height == target.height);

            if (cell == null || cell.wasShot)
                return false; // Komórka już została trafiona lub jest nieprawidłowa

            cell.wasShot = true;

            return cell.isShip;
        }

        private void AddSurroundingPoints(Board board, Point hitPoint)
        {
            var potentialPoints = new List<Point>
            {
                new Point(hitPoint.wight - 1, hitPoint.height),
                new Point(hitPoint.wight + 1, hitPoint.height),
                new Point(hitPoint.wight, hitPoint.height - 1),
                new Point(hitPoint.wight, hitPoint.height + 1),
            };

            foreach (var point in potentialPoints)
            {
                if (board.cells.Any(c =>
                    c.point.wight == point.wight &&
                    c.point.height == point.height &&
                    !c.wasShot &&
                    !_computerPlayer.PendingShots.Contains(point)))
                {
                    _computerPlayer.PendingShots.Add(point);
                }
            }
        }

        public ComputerPlayer GetResult()
        {
            return _computerPlayer;
        }
    }
}

