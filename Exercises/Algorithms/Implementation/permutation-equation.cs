using System;

namespace Exercises.Algorithms.Implementation
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/permutation-equation
    /// You are given a sequence of N integers, p(1),p(2),p(3),p(n). Each element in the sequence is distinct and satisfies 1 lte p(x) lte n. For each x  where 1 lte x lte n, find any integer y such that p(p(y)) == x and print the value of y on a new line.
    /// </summary>
    class Solution
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            int numEntries = Int32.Parse(Console.ReadLine());
            int maxEntries = 50;
            string[] text_items = Console.ReadLine().Split(' ');
            int[] items = new int[numEntries];
            int[] indexForValue = new int[maxEntries+1];

            for (int i = 0; i < numEntries; i++)
            {
                items[i] = int.Parse(text_items[i]);
                indexForValue[items[i]] = i+1;
            }
            //Console.WriteLine(String.Join(" ", indexForValue));

            for (int i = 1; i <= numEntries; i++)
            {
                int searchVal = indexForValue[i];
                int yVal = indexForValue[searchVal];
                //Console.WriteLine($"{i}->{searchVal}->{yVal}");

                Console.WriteLine(yVal);
            }
        }
    }
}
