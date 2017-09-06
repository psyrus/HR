using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/append-and-delete
    /// You have a string, s, of lowercase English alphabetic letters. You can perform two types of operations on s:
    /// 1) Append a lowercase English alphabetic letter to the end of the string.
    /// 2) Delete the last character in the string. Performing this operation on an empty string results in an empty string.
    /// Given an integer, k, and two strings, s and t, determine whether or not you can convert s to t by performing exactly of the above operations on s. If it's possible, print Yes; otherwise, print No.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        int k = Convert.ToInt32(Console.ReadLine());

        //If they start the same

        if (s == t || (s.Length >= t.Length && k > s.Length))
        {
            Console.WriteLine("Yes");
            return;
        }

        int diffChars = getDiffChars(s, t);
        //Console.WriteLine($"K={k}");
        //Console.WriteLine($"diff={diffChars}");

        if (k >= diffChars && (k - diffChars) % 2 == 0)
        {
            Console.WriteLine("Yes");
            return;
        }

        Console.WriteLine("No");
    }

    static int getDiffChars(string s, string t)
    {
        int same = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (i >= t.Length || s[i] != t[i])
            {
                break;
            }
            else if (s[i] == t[i])
            {
                same++;
            }
        }

        int diffS = s.Length - same;
        int diffT = t.Length - same;
        int totalDiff = diffS + diffT;
        return totalDiff;
    }
}
