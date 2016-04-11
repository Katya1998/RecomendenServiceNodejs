using System;
using System.Collections;


namespace LazySequences
{
    class Sequence
    {
        public IEnumerable Fibonacci()
        {
            ulong a, b, c;
            yield return a = 1;
            yield return b = 1;
            while (true)
            {
                c = a + b;
                a = b;
                b = c;
                yield return c;
            }
        }
    }
}
