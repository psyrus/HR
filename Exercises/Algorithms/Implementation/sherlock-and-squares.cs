using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/sherlock-and-squares
    /// Watson gives two integers (A and B) to Sherlock and asks if he can count the number of square integers between A and B (both inclusive).
    /// Note: A square integer is an integer which is the square of any integer.For example, 1, 4, 9, and 16 are some of the square integers as they are squares of 1, 2, 3, and 4, respectively.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int numTestCases = int.Parse(Console.ReadLine());

        for (int i = 0; i < numTestCases; i++)
        {
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            int lowRoot = (int)Math.Ceiling(Math.Sqrt(numbers[0]));
            int highRoot = (int)Math.Floor(Math.Sqrt(numbers[1]));

            int total = highRoot - lowRoot + 1;

            Console.WriteLine(total);
            //Console.WriteLine($"Low: {lowRoot} | High: {highRoot} \n");
        }
    }
}