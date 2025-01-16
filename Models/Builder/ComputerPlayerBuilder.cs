﻿using System;
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

        public void createSteps(string name)
        {
            
            _computerPlayer.name = name;
            _computerPlayer.DifficultyLevel = 1;
            _computerPlayer.PendingShots.Clear();
        }
        public void EasyMode(Board board)
        {
            Point target;
            target = GetRandomPoint(board);
            bool hit = ShootAt(board, target);
            if (hit)
            {
                Console.WriteLine($"Hit at ({target.wight}, {target.height})!");
            }
            else
            {
                Console.WriteLine($"Miss at ({target.wight}, {target.height}).");
            }
        }

        public void MediiumMode(Board board)
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
        public void HardMode(Board board)
        {
            Point target;

            if (_computerPlayer.PendingShots.Count > 0)
            {
                target = _computerPlayer.PendingShots[0];
                _computerPlayer.PendingShots.RemoveAt(0);
            }
            else
            {
                // Generujemy listę punktów do strzału
                List<Point> targetPool = GenerateTargetPool(board);

                // Losujemy punkt z tej listy
                target = targetPool[_random.Next(targetPool.Count)];
            }

            Console.WriteLine($"{_computerPlayer.name} shoots at ({target.wight}, {target.height})");

            // Wykonujemy strzał
            bool hit = ShootAt(board, target);

            if (hit)
            {
                Console.WriteLine($"Hit at ({target.wight}, {target.height})!");
                AddSurroundingPoints(board, target); // Dodaj sąsiadujące punkty, aby celować w statek
            }
            else
            {
                Console.WriteLine($"Miss at ({target.wight}, {target.height}).");
            }
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
                    !_computerPlayer.PendingShots.Contains(point)))
                {
                    _computerPlayer.PendingShots.Add(point);
                }
            }
        }

        public Player GetResult()
        {
            return _computerPlayer;
        }
    }
}

