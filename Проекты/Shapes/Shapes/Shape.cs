using System;
using System.Collections;


namespace Shapes
{
    class Point : IPrintable
    {
        public double X;
        public double Y;
        public override string ToString()
        {
            return String.Format("({0}; {1})", X, Y);
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {
            X = Y = 0;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Точка " + this);
        }

        public double Distance(Point m)
        {
            return Math.Sqrt((X - m.X) * (X - m.X) + (Y - m.Y) * (Y - m.Y));
        }

    }

    abstract class Shape : IPrintable
    {
        public abstract string Name { get; set; }
        public abstract void PrintInfo();
    }

    class Circle : Shape, IMeasurable, IScreenable, IPlottarable
    {
        public Point Center;
        public double Radius { get; set;}


        public override string Name
        {
            get ;
            
            set ;
            
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Круг радиуса {0} с центром в точке {1}",
                Radius, Center);
        }

        public double GetArea()
        {
            return Math.PI*Radius*Radius;
        }

        public void Draw()
        {
            Console.WriteLine("Рисуем круг");
        }

        void IScreenable.Draw()
        {
            Console.WriteLine("Рисуем круг на экране");
        }

        void IPlottarable.Draw()
        {
            Console.WriteLine("Рисуем круг на плоттере");
        }
    }

    class Triangle : Shape, IPolygone, IEnumerable
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }


        public override string Name { get; set; }
        

        public override void PrintInfo()
        {
            Console.WriteLine("Треугольник {3} с вершинами {0}, {1}, {2}",
                A, B, C, Name);
        }

        public uint NumberOfPoints()
        {
            return 3;
        }

        public double GetArea()
        {
            double a, b, c, p;
            a = A.Distance(B);
            b = B.Distance(C);
            c = C.Distance(A);
            p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public int NumberOfDiagonals
        {
            get { return 0; }
        }

        public IEnumerator GetEnumerator()
        {
           var vertexes = new Point[] { A, B, C };
           return vertexes.GetEnumerator(); 
        }
    }

    class Rectangle : Shape, IPolygone, IEnumerable
    {
        //прямоугольник со сторонами, параллельными координатным осям
        private Point a;
        private Point b;
        private Point c;
        private Point d;

        public Point A 
        {
            get
            {
                return a;
            }

            set
            {
                a = value;
            }
        }
        public Point C 
        {
            get 
            {
                return c;
            }

            set
            {
                c = value;
            }
        }
        public Point B
        {
            get
            {
                b.X = A.X;
                b.Y = C.Y;
                return b;
            }
        }

        public Point D
        {
            get
            {
                d.X = C.X;
                d.Y = A.Y;
                return d;
            }
        }

        public Rectangle()
        {
            a = new Point();
            b = new Point();
            c = new Point();
            d = new Point();
        }

        public class RectEnumerator : IEnumerator
        {
            private Rectangle rect;
            private Point curr;

            public RectEnumerator(Rectangle myRectangle)
            {
                rect = myRectangle;
                curr = null;
            }


            public object Current
            {
                get { return curr; }
            }

            public bool MoveNext()
            {
                var flag = true;
                if (curr == null)
                    curr = rect.A;
                else if (curr == rect.A)
                    curr = rect.B;
                else if (curr == rect.B)
                    curr = rect.C;
                else if (curr == rect.C)
                    curr = rect.D;
                else
                    flag = false;
                return flag;
            }

            public void Reset()
            {
                curr = null;
            } 
        }


        public override string Name
        {
            get;
            set;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Прямоугольник {0} с вершинами {1}, {2}, {3}, {4}",
                Name, A, B, C, D);
        }

        public uint NumberOfPoints()
        {
            return 4;
        }

        public double GetArea()
        {
            return A.Distance(B)*A.Distance(D);
        }

        public int NumberOfDiagonals
        {
            get { return 2; }
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return new RectEnumerator(this);
        //}



        public IEnumerator GetEnumerator()
        {
            return new RectEnumerator(this);
        }
    }

    class Quadrangle : Shape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }

        public override string Name { get; set; }


        public override string ToString()
        {
            return base.ToString();
        }

        public override void PrintInfo()
        {                  
            Console.WriteLine("Четырехугольник {0} с вершинами {1}, {2}, {3}, {4}",
                Name, A, B, C, D);
        }

        public IEnumerator GetEnumerator()
        {
            yield return A;
            yield return B;
            yield return C;
            yield return D;
        }
        
    }

    class Line : Shape
    {
        public Point A;
        public Point B;

        public override string Name { get; set; }
       

        public override void PrintInfo()
        {
            Console.WriteLine("Прямая, проходящая через точки {0} и {1}",
                A, B);
        }
    }
}
