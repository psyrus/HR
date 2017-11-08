using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/manasa-and-stones/problem
    /// Manasa is out on a hike with friends. She finds a trail of stones with numbers on them. She starts following the trail and notices that two consecutive stones have a difference of either a or b. Legend has it that there is a treasure trove at the end of the trail and if Manasa can guess the value of the last stone, the treasure would be hers. Given that the number on the first stone was 0, find all the possible values for the number on the last stone.
    /// Note: The numbers on the stones are in increasing order.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int numTestCases = int.Parse(Console.ReadLine());
        for (int i = 0; i < numTestCases; i++)
        {
            int numStones = int.Parse(Console.ReadLine());
            int minIncrement = int.Parse(Console.ReadLine());
            int maxIncrement = int.Parse(Console.ReadLine());
            List<int> totals = new List<int>();
            HashSet<int> seen = new HashSet<int>();

            for (int j = 0; j < numStones; j++)
            {
                int value = maxIncrement * j + minIncrement * (numStones - j - 1);
                if (!seen.Contains(value))
                {
                    seen.Add(value);
                    totals.Add(value);
                }
            }

            totals.Sort();
            Console.WriteLine(String.Join(" ", totals));
        }
    }
}
