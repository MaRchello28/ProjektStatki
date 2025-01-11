using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjektStatki.Models
{
    public class ComputerPlayer:Player
    {
        public string name { get; set; }
        public int DifficultyLevel { get; set; }
        private List<Point> _pendingShots;
        private Random _random;

        public ComputerPlayer(string name, int difficultyLevel)
        {
            name = name;
            DifficultyLevel = difficultyLevel;
            _random = new Random();
            _pendingShots = new List<Point>();
        }
        public void InitializePendingShots()
        {
            _pendingShots = new List<Point>();
        }

        public void EasyMode(Board board)
        {
            Point target;

            if (_pendingShots.Count > 0)
            {
                // Strzelanie wokół trafionego statku
                target = _pendingShots[0];
                _pendingShots.RemoveAt(0);
            }
            else
            {
                // Losowy strzał
                target = GetRandomPoint(board);
            }

            Console.WriteLine($"{name} shoots at ({target.wight}, {target.height})");

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
                    !_pendingShots.Contains(point)))
                {
                    _pendingShots.Add(point);
                }
            }
        }


        public void MediumMode()
        {

        }

        public void HardMode()
        {

        }

        public void ChooseDiffLevel()
        {

        }
    }
}
