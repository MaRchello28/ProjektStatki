using System;
using System.Collections.Generic;

namespace ProjektStatki.Models.Creator
{
    // Klasa reprezentująca punkty siza statku, nie wiem jak to napisac, nie mój problem
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }

    // Klasa bazowa dla statków
    public abstract class Ship
    {
        public string Name { get; protected set; }
        public List<Point> Size { get; protected set; }

        protected Ship(string name, List<Point> size)
        {
            Name = name;
            Size = size;
        }

        public override string ToString()
        {
            string sizeString = string.Join(", ", Size);
            return $"{Name} (Rozmiar: {sizeString})";
        }
    }

    // Konkretne implementacje statków
    public class SmallShip : Ship
    {
        public SmallShip() : base("Łutka", new List<Point> { new Point(0, 0), new Point(0, 1) }) { }
    }

    public class MediumShip3 : Ship
    {
        public MediumShip3() : base("Niszczyciel", new List<Point>
        {
            new Point(0, 0),
            new Point(0, 1),
            new Point(0, 2)
        })
        { }
    }

    public class MediumShip4 : Ship
    {
        public MediumShip4() : base("Krążownik", new List<Point>
        {
            new Point(0, 0),
            new Point(0, 1),
            new Point(0, 2),
            new Point(0, 3)
        })
        { }
    }

    public class LargeShip : Ship
    {
        public LargeShip() : base("Bismark", new List<Point>
        {
            new Point(0, 0),
            new Point(0, 1),
            new Point(0, 2),
            new Point(0, 3),
            new Point(0, 4)
        })
        { }
    }

    // Klasa Creator (Factory Method)
    public abstract class ShipsCreator
    {
        public abstract Ship CreateShip();
    }

    public class SmallShipCreator : ShipsCreator
    {
        public override Ship CreateShip()
        {
            return new SmallShip();
        }
    }

    public class MediumShip3Creator : ShipsCreator
    {
        public override Ship CreateShip()
        {
            return new MediumShip3();
        }
    }

    public class MediumShip4Creator : ShipsCreator
    {
        public override Ship CreateShip()
        {
            return new MediumShip4();
        }
    }

    public class LargeShipCreator : ShipsCreator
    {
        public override Ship CreateShip()
        {
            return new LargeShip();
        }
    }
}
