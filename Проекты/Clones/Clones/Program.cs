using System;

namespace Clones
{
    class PointDescription
    {
        public string Name {get; set;}
        public readonly Guid ID;
        public PointDescription(string name)
        {
            Name = name;
            ID = Guid.NewGuid();
        }
    }

    class Point : ICloneable
    {
        public double X;
        public double Y;
        public PointDescription Description;

        public override string ToString()
        {
            return String.Format("({0}; {1})", X, Y);
        }

        public Point(double x, double y, string name)
        {
            X = x;
            Y = y;
            Description = new PointDescription(name);
        }

        public Point(double x, double y) : this(x, y, "No-name") { }

        public Point() : this(0, 0, "No-name") { } 

        public void PrintInfo()
        {
            Console.WriteLine("Точка " + Description.Name + this);
            Console.WriteLine("ID = " + Description.ID + "\n");
        }

        public double Distance(Point m)
        {
            return Math.Sqrt((X - m.X) * (X - m.X) + (Y - m.Y) * (Y - m.Y));
        }

        public object Clone()
        {
            return new Point(X,Y,Description.Name);
        }
    }

    class Program
    {
        static void Main()
        {
            var a = new Point(1, 1, "A");
            var b = a.Clone() as Point;
            
            a.X = 2;
            b.Description.Name = "B";

           

            a.PrintInfo();
            b.PrintInfo();

            Console.ReadKey();
        }
    }
}
