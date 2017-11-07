using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/fair-rations
    /// You are the benevolent ruler of Rankhacker Castle, and today you're distributing bread to a straight line of N subjects. Each ith subject (where i lte N) already has  Bi loaves of bread.
    /// Times are hard and your castle's food stocks are dwindling, so you must distribute as few loaves as possible according to the following rules:
    /// 1) Every time you give a loaf of bread to some person , you must also give a loaf of bread to the person immediately in front of or behind them in the line (i.e., persons i+1 or i-1 ). In other words, you can only give a loaf of bread each to two adjacent people at a time.
    /// 2) After all the bread is distributed, each person must have an even number of loaves.
    /// Given the number of loaves already held by each citizen, find and print the minimum number of loaves you must distribute to satisfy the two rules above. If this is not possible, print NO.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        string[] B_temp = Console.ReadLine().Split(' ');
        int[] B = Array.ConvertAll(B_temp, Int32.Parse);

        int totalOddsDistance = 0;
        int numOdds = 0;

        for (int i = 0; i < N; i++)
        {
            int thisNum = B[i];

            //If we find an odd number, increment the counter
            if (thisNum % 2 == 1)
            {
                numOdds++;
            }

            //If the number of odd numbers is odd, we count all steps as distance between the odds
            if (numOdds % 2 == 1)
            {
                totalOddsDistance++;
            }
        }

        //If there are an odd number of odds, it's impossible to solve the problem
        if (numOdds % 2 == 1)
        {
            Console.WriteLine("NO");
        }
        else
        {
            Console.WriteLine(totalOddsDistance * 2);
        }

    }
}
