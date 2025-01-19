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
        public string Id { get; set; }
        public string name { get; set; }
        public int DifficultyLevel { get; set; }
        public List<Point> PendingShots { get; set; }
        private Random _random = new Random(); 

        public ComputerPlayer(string name, int difficultyLevel)
        {
            name = name;
            DifficultyLevel = difficultyLevel;
            PendingShots = new List<Point>();
        }

        public Point Shot(Board board)
        {
            Point point;
            if(DifficultyLevel == 1)
            {
                point = EasyMode(board);
            }
            else if(DifficultyLevel == 2)
            {
                point = MediumMode(board);
            }
            else
            {
                point = HardMode(board);
            }
            return point;
        }

        public Point EasyMode(Board board)
        {
            Point target;
            target = GetRandomPoint(board);
            return target;
        }

        public Point MediumMode(Board board)
        {

            Point target;

            if (PendingShots.Count > 0)
            {
                // Strzelanie wokół trafionego statku
                target = PendingShots[0];
                PendingShots.RemoveAt(0);
            }
            else
            {
                // Losowy strzał
                target = GetRandomPoint(board);
            }

            return target;
        }
        public Point HardMode(Board board)
        {
            Point target;

            if (PendingShots.Count > 0)
            {
                target = PendingShots[0];
                PendingShots.RemoveAt(0);
            }
            else
            {
                // Generujemy listę punktów do strzału
                List<Point> targetPool = GenerateTargetPool(board);

                // Losujemy punkt z tej listy
                target = targetPool[_random.Next(targetPool.Count)];
            }

            return target;
        }

        private List<Point> GenerateTargetPool(Board board)
        {
            var targetPool = new List<Point>();
            var availableCells = board.cells
                .Where(c => !c.wasShot && !c.isShip)
                .ToList();

            int pointsToAdd = Math.Min(4, availableCells.Count);
            for (int i = 0; i < pointsToAdd; i++)
            {
                Cell randomCell = availableCells[_random.Next(availableCells.Count)];
                targetPool.Add(randomCell.point);
                availableCells.Remove(randomCell); // Usuwamy, aby nie powtarzać punktów
            }

            // Dodajemy punkt, w którym znajduje się statek, jeśli taki istnieje
            Cell shipCell = board.cells.FirstOrDefault(c => !c.wasShot && c.isShip);
            if (shipCell != null)
            {
                targetPool.Add(shipCell.point);
            }

            return targetPool;
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
                    !PendingShots.Contains(point)))
                {
                    PendingShots.Add(point);
                }
            }
        }
    }
}
