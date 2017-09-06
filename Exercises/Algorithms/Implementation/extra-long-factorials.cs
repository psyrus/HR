using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/extra-long-factorials
    /// You are given an integer N. Print the factorial of this number.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        BigInteger factorial = new BigInteger(n);

        int counter = 1;
        while (counter < n)
        {
            factorial = factorial * (n - counter);
            counter++;
        }

        Console.WriteLine(factorial);
    }
}
