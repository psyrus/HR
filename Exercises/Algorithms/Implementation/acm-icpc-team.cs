using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/acm-icpc-team
    /// You are given a list of N people who are attending ACM-ICPC World Finals. Each of them are either well versed in a topic or they are not. Find out the maximum number of topics a 2-person team can know. And also find out how many teams can know that maximum number of topics.
    /// Note Suppose a, b, and c are three different people, then (a, b) and(b, c) are counted as two different teams.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] studentsTopics = new string[n];

        Dictionary<int, HashSet<int>> knows = new Dictionary<int, HashSet<int>>();
        for (int studentIndex = 0; studentIndex < n; studentIndex++)
        {
            studentsTopics[studentIndex] = Console.ReadLine();

            for (int i = 0; i < m; i++)
            {
                int convertedVal = studentsTopics[studentIndex][i] - '0';
                if (!knows.ContainsKey(i))
                {
                    knows.Add(i, new HashSet<int>());
                }
 
                if (convertedVal == 1)
                {
                    knows[i].Add(studentIndex);
                }
            }
        }

        foreach (var item in knows)
        {
            Console.Write(item.Key + " is known by: ");
            Console.Write(String.Join(" ", item.Value));
            Console.WriteLine();
        }
    }
}
