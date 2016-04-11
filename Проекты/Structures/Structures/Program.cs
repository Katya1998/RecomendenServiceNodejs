using System;

namespace Structures
{
    struct Pixel
    {
        public int X;
        public int Y;
    }

    class PixelObj
    {
        public int X;
        public int Y;
    }


    class Program
    {
        static Pixel statPx;

        Pixel dynPx;

        static void ChangeStr(Pixel p)
        {
            p.X = 5;
        }

        static void ChangeObj(PixelObj p)
        {
            p.X = 5;
        }

        static void Main()
        {
            Pixel pix =new Pixel();

            ChangeStr(pix);
            Console.WriteLine(pix.X);

            var pixObj = new PixelObj();
            ChangeObj(pixObj);
            Console.WriteLine(pixObj.X);
            
            Console.ReadKey();

            //statPx.X = 2;

            //var obj = new Program();
            //obj.dynPx.X = 3;



        }
    }
}
