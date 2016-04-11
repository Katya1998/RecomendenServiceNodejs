using System;


namespace MethodOverride
{
    class Point
    {
        public double X;
        public double Y;

        public override string ToString()
        {
            return String.Format("({0}, {1})", X, Y);
        }
    }

    class Program
    {
        static void Main()
        {
            var myPoint = new Point() { X = 1, Y = 2 };

            Console.WriteLine(myPoint);

            Console.ReadKey();
        }
    }
}
