using System;
using System.Threading;


namespace LazySequences
{
    class Program
    {
        static ulong Fib(int m)
        {
            var n = 0;
            ulong result = 0;
            var seq = new Sequence();

            foreach (ulong f in seq.Fibonacci())
            {
                n++;
                if (n > m)
                {
                    result = f;
                    break;
                }
            }
            return result;
        }

        static void Main()
        {
            
            

            // так не надо делать
            //var fib = new ulong[m];

            //fib[0] = 1;
            //fib[1] = 1;
            //for (var i = 2; i < m; i++)
            //    fib[i] = fib[i - 1] + fib[i - 2];
            ////foreach (var numb in fib)
            ////    Console.WriteLine(numb);

            //Console.WriteLine(fib[40]);

            

            //foreach (ulong f in seq.Fibonacci())
            //{
            //    Console.WriteLine(f);
            //    Thread.Sleep(250);
            //    if (Console.KeyAvailable) break;
            //}
            //Console.ReadKey();
            const int m = 100;
            
            Console.WriteLine(Fib(5));

            Console.ReadKey();
        }
    }
}
