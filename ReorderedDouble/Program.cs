using System;
using System.Collections.Generic;
using System.Linq;

namespace ReorderedDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] A = { 4, -2, 2, -4 };
            CanReorderDoubled(A);
        }
        public static bool CanReorderDoubled(int[] A)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            A = A.OrderBy(Math.Abs).ToArray();
            for (int i = 0; i < A.Length; i++)
            {
                if (hash.ContainsKey(A[i]))
                    hash[A[i]] += 1;
                else
                    hash.Add(A[i], 1);
            }
            for (int i = 0; i < A.Length; i++)
            {
                if (hash[A[i]] == 0)
                    continue;
                if (!hash.ContainsKey(2 * A[i]))
                    return false;
                if (hash[2 * A[i]] == 0)
                    return false;
                hash[A[i]] = hash[A[i]] - 1;
                hash[2 * A[i]] = hash[2 * A[i]] - 1;
            }
            return true;

        }
    }
}
