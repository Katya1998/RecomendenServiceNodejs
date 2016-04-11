using System;

namespace Shapes
{
    class Program
    {
        static void PrintNumberOfPoints(IPointy iface)
        {
            Console.WriteLine("Число вершин {0}",
                iface.NumberOfPoints());
        }

        static IMeasurable GetTheLargest(params object[] figures) 
        {
            IMeasurable result = null;

            foreach (object figure in figures)
            {
                if (figure is IMeasurable)
                {
                    var iface = (IMeasurable)figure;
                    if (result == null ||
                        iface.GetArea() > result.GetArea())
                        result = iface;
                }
            }

            return result;
        }

        static void Main()
        {
            var myPoint = new Point(1, 2);
            //Console.WriteLine(myPoint);
            //myPoint.PrintInfo();

            var myCircle = new Circle() { Radius = 2, Center = myPoint };
            //myCircle.PrintInfo();

            var myTriangle = new Triangle()
            {
                Name = "ABC",
                A = new Point(0, 0),
                B = new Point(1, 0),
                C = new Point(0, 1) 
            };

            //myTriangle.PrintInfo();
            //Console.WriteLine("Число вершин {0}",
            //    myTriangle.NumberOfPoints());
            //PrintNumberOfPoints(myTriangle);

            var myRectangle = new Rectangle() 
                { A = new Point(1, 1), C = new Point(-1, -1), 
                Name = "ABCD"};
            //myRectangle.PrintInfo();
            //Console.WriteLine("Число вершин {0}",
            //    myRectangle.NumberOfPoints());
            //PrintNumberOfPoints(myRectangle);

            var myLine = new Line() { A = new Point(), B = new Point(1, 1) };

            IPrintable[] ifacePr = new IPrintable[] 
                {   (IPrintable)myCircle, 
                    myTriangle,
                    myLine,
                    myRectangle, 
                    myPoint 
                };
            foreach (var figure in ifacePr)
            {
                figure.PrintInfo();
                if (figure is IPointy)
                    PrintNumberOfPoints((IPointy)figure);
                if (figure is IMeasurable)
                    Console.WriteLine("Площадь равна {0:F3} кв. ед.", 
                        ((IMeasurable)figure).GetArea());
                if (figure is IPolygone)
                    Console.WriteLine("Число диагоналей равно " +
                        ((IPolygone)figure).NumberOfDiagonals);
            }


            Console.WriteLine("Фигура наибольшей площади имеет площадь {0:F3}",
                GetTheLargest(myPoint, myTriangle, myCircle, myLine).GetArea());

            myCircle.Draw();
            var ifaceScreen = (IScreenable)myCircle;
            var IfacePlotter = (IPlottarable)myCircle;
            ifaceScreen.Draw();
            IfacePlotter.Draw();

            foreach (Point vertex in myTriangle)
                vertex.PrintInfo();

            myTriangle.A = new Point(-1, -1);
            myTriangle.PrintInfo();
            foreach (Point vertex in myTriangle)
                vertex.PrintInfo();

            myRectangle.PrintInfo();
            foreach (Point vert in myRectangle)
                vert.PrintInfo();

            //var iEnum = myRectangle.GetEnumerator();

            //while (true)
            //{
            //    if (iEnum.MoveNext())
            //    {
            //        var p = iEnum.Current as Point;
            //        p.PrintInfo();
            //    }
            //    else
            //        iEnum.Reset();

            //    if (Console.KeyAvailable)
            //        break;
            //}


            var myQuadrangle = new Quadrangle()
            {
                A = new Point(),
                B = new Point(5, 0),
                C = new Point(5, 5),
                D = new Point(-5, 0)
            };
            myQuadrangle.PrintInfo();

            foreach (Point vert in myQuadrangle)
                vert.PrintInfo();

            Console.ReadKey();
           
        }
    }
}
