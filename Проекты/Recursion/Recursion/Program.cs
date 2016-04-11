using System;
using System.Diagnostics;

namespace Recursion
{


    class Program
    {
        static void GetMs(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            Console.WriteLine("Прошло {0} мс", stopwatch.ElapsedMilliseconds);
        }

        static ulong FibSeq(int n)
        {
            var counter = 0;
            ulong result = 0;
            var seq = new Sequence();
            foreach (var fib in seq.Fibonacci())
            {
                if (++counter > n)
                {
                    result = (ulong)fib;
                    break;
                }
            }

            return result;
           
        }

        static ulong FibRec(int n)
        {
            if (n < 2)
                return 1;
            else
                return FibRec(n - 1) + FibRec(n - 2);
        }

        static void Main()
        {
            const int m = 40;

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            Console.WriteLine(FibRec(m));
            GetMs(stopwatch);

            stopwatch.Restart();
            Console.WriteLine(FibSeq(m));
            GetMs(stopwatch);

            Console.ReadKey();
        }
    }
}
