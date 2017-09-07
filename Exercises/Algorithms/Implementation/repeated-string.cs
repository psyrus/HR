using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/repeated-string
    /// Lilah has a string, s, of lowercase English letters that she repeated infinitely many times.
    /// Given an integer, n, find and print the number of letter a's in the first  letters of Lilah's infinite string.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string s = Console.ReadLine();
        long n = Convert.ToInt64(Console.ReadLine());

        int stringLength = s.Length;

        long repeats = n / stringLength;
        long extra = n % stringLength;

        int aInString = 0;
        foreach (var item in s)
        {
            if (item == 'a')
            {
                aInString++;
            }
        }

        long totalAs = repeats * aInString;
        int indexTracker = 0;
        while (extra > 0)
        {
            if (s[indexTracker] == 'a')
            {
                totalAs++;
            }
            extra--;
            indexTracker++;
        }

        Console.WriteLine(totalAs);
    }
}
