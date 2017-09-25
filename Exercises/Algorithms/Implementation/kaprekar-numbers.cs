using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/kaprekar-numbers
    /// A modified Kaprekar number is a positive whole number n with d digits, 
    /// such that when we split its square into two pieces - a right hand piece r with d digits and a left hand piece l that 
    /// contains the remaining d or d-1 digits, the sum of the pieces is equal to the original number (i.e. l + r = n).
    /// Note: r may have leading zeros.
    /// Here's an explanation from Wikipedia about the ORIGINAL Kaprekar Number (spot the difference!): 
    /// In mathematics, a Kaprekar number for a given base is a non-negative integer, 
    /// the representation of whose square in that base can be split into two parts that add up to the original number again. 
    /// For instance, 45 is a Kaprekar number, because 45² = 2025 and 20+25 = 45.
    /// 
    /// You are given the two positive integers p and q, where p is lower than q. 
    /// Write a program to determine how many Kaprekar numbers are there in the range between p and q (both inclusive) and display them all.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());

        List<int> kaprVals = new List<int>();
        for (int i = p; i <= q; i++)
        {
            if (isKaprekar(i))
            {
                //Console.WriteLine("\t It is a Kaprekar value");
                kaprVals.Add(i);
            }
        }
        if (kaprVals.Count > 0)
        {
            Console.WriteLine(String.Join(" ", kaprVals));
        }
        else
        {
            Console.WriteLine("INVALID RANGE");

        }
    }

    private static bool isKaprekar(int i)
    {
        long longversion = i;
        string squaredVal = (longversion * longversion).ToString();
        int rightIndex = (int)Math.Floor(squaredVal.Length / 2.0f);
        int rightSide = int.Parse(squaredVal.Substring(rightIndex));
        int leftSide = rightIndex > 0 ? int.Parse(squaredVal.Substring(0, rightIndex)) : 0;

        bool isKapr = rightSide + leftSide == i;
        //if (isKapr)
        //{
        //    Console.WriteLine($"Value of [{i}] is squared to [{squaredVal}], which splits into the L/R values respectively: [{leftSide}]/[{rightSide}]");
        //}

        return isKapr;
    }
}