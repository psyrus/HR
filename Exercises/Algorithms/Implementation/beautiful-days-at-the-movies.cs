using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Solution
{
    /// <summary>
    /// Lily likes to play games with integers and their reversals. For some integer x, we define reversed(x) to be the reversal of all digits in x. For example, reversed(123) = 321, reversed(21) = 12, and reversed(120) = 21.
    /// Logan wants to go to the movies with Lily on some day x satisfying i less than x less than j, but he knows she only goes to the movies on days she considers to be beautiful.
    /// Lily considers a day to be beautiful if the absolute value of the difference between x and reversed(x) is evenly divisible by k.
    /// Given i, j and k, count and print the number of beautiful days when Logan and Lily can go to the movies.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int[] vars = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
        int daysStart = vars[0];
        int daysEnd = vars[1];
        int beautyDivisor = vars[2];

        int beautifulDaysCount = 0;

        for (int candidateDay = daysStart; candidateDay <= daysEnd; candidateDay++)
        {
            double calulatedVal = (double)(Math.Abs(candidateDay - GetReverse(candidateDay))) / beautyDivisor;

            if (calulatedVal % 1 == 0)
            {
                beautifulDaysCount++;
            }
            
        }
        Console.WriteLine(beautifulDaysCount);
    }

    static int GetReverse(int numToReverse)
    {
        var stringRep = numToReverse.ToString();
        StringBuilder returnString = new StringBuilder();

        for (int i = stringRep.Length - 1; i >= 0; i--)
        {
            returnString.Append(stringRep[i]);
        }
        return int.Parse(returnString.ToString());
    }
}