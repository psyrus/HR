using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/find-digits
    /// Given an integer, N, traverse its digits (1,2,...,n) and determine how many digits evenly divide N (i.e.: count the number of times N divided by each digit i has a remainder of 0). Print the number of evenly divisible digits.
    /// Note: Each digit is considered to be unique, so each occurrence of the same evenly divisible digit should be counted(i.e.: for , the answer is ).
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            string originalNum = Console.ReadLine();
            int n = Convert.ToInt32(originalNum);
            int dividedNums = 0;
            for (int i = 0; i < originalNum.Length; i++)
            {
                int checkNum = Int32.Parse(originalNum[i].ToString());
                //Console.WriteLine($"Checking if the element [{checkNum}] is part of [{originalNum}]");
                if (checkNum == 0)
                {
                    continue;
                }
                if (n % checkNum == 0)
                {
                    dividedNums++;
                }
            }
            Console.WriteLine(dividedNums);
        }
    }
}
