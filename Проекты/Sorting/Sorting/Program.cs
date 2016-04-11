using System;
using System.Collections;



namespace Sorting
{
    class Point : IComparable
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point() : this(0,0) { }

        public double Distance(Point m)
        {
            return Math.Sqrt((X - m.X) * (X - m.X) + (Y - m.Y) * (Y - m.Y));
        }

        public int CompareTo(object obj)
        {
            var zeroPoint = new Point();
            var d1 = this.Distance(zeroPoint);
            var d2 = ((Point)obj).Distance(zeroPoint);
            return d1.CompareTo(d2); 
        }
    }

    class IntDecreaser : IComparer
    {

        public int Compare(object x, object y)
        {
            var a = (int)x;
            var b = (int)y;
            return -a.CompareTo(b);
        }
    }

    class FirstCharCaseSensitiveSorter : IComparer
    {

        public int Compare(object x, object y)
        {
            string strX = (string)x;
            string strY = (string)y;
            if (strX == "") return -1;
            else if (strY == "") return -1;
            return ((int)strX[0]).CompareTo((int)strY[0]);
        }
    }

    class Program
    {
        static void BubleSort(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int b = a[j]; //change for elements
                        a[j] = a[j + 1];
                        a[j + 1] = b;
                    }
                }
            }
        }

        static void BubleSortStr(string[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    if (a[j].CompareTo(a[j + 1]) > 0)
                    {
                        string b = a[j]; //change for elements
                        a[j] = a[j + 1];
                        a[j + 1] = b;
                    }
                }
            }
        }



        static void Main(string[] args)
        {
            var intArray = new int[] {2, -3, 1, 0, 2, 4};
            var stringArray = new string[] { "Z", "C", "a", "B" };
            var pointArray = new Point[] { new Point(-1, 1), new Point(), new Point(2, 3) };
            
            //BubleSort(intArray);
            //BubleSortStr(stringArray);

            Array.Sort(intArray);
            Array.Sort(stringArray);
            Array.Sort(pointArray);
            Array.Sort(intArray, new IntDecreaser());
            Array.Sort(stringArray, new FirstCharCaseSensitiveSorter());

            Console.ReadKey();
        }
    }
}
