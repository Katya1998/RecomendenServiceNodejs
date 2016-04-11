using System;


namespace DivideAndConquer
{
    class Program
    {
        static int MaxElem(int[] array, int start, int end)
        {
            var length = end - start + 1;
            if (array == null || array.Length == 0 || length < 1)
                throw new InvalidOperationException();
            else if (length == 1)
                return array[start];
            else
            {
                var threshold = start + length/2;
                var max1 = MaxElem(array, start, threshold - 1);
                var max2 = MaxElem(array, threshold, end);
                return max1 > max2 ? max1 : max2;
            }
        }

        static void Main()
        {
            var arr = new int[] { 10, 1, 2, 100, -5, 0, 7, 4, 25};
            Console.WriteLine(MaxElem(arr, 0, arr.Length - 1));
            Console.ReadKey();
        }
    }
}
