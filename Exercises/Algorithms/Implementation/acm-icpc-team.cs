using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

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
        int maxValue = (int)Math.Pow(2, m-1);
        string[] topic = new string[n];
        BigInteger[] studentKnownIndexes = new BigInteger[n];

        BigInteger maxKnown = 0;
        int numKnowMax = 0;
        
        for (int topic_i = 0; topic_i < n; topic_i++)
        {
            studentKnownIndexes[topic_i] = Console.ReadLine().Aggregate(new BigInteger(), (b, c) => b * 2 + c - '0');
            for (int j = 0; j < topic_i; j++)
            {
                BigInteger thisCombo = studentKnownIndexes[topic_i] | studentKnownIndexes[j];
                if (thisCombo > maxKnown)
                {
                    maxKnown = thisCombo;
                    numKnowMax = 1;
                }
                else if (thisCombo == maxKnown)
                {
                    numKnowMax++;
                }
            }
        }
        string result = ToBinaryString(maxKnown);
        
        Console.WriteLine(GetTotalKnown(result));
        Console.WriteLine(numKnowMax);
    }

    private static int GetTotalKnown(string result)
    {
        int numKnown = 0;
        foreach (var item in result)
        {
            if (item == '1')
            {
                numKnown++;
            }
        }

        return numKnown;
    }

    public static string ToBinaryString(BigInteger bigint)
    {
        var bytes = bigint.ToByteArray();
        var idx = bytes.Length - 1;

        // Create a StringBuilder having appropriate capacity.
        var base2 = new StringBuilder(bytes.Length * 8);

        // Convert first byte to binary.
        var binary = Convert.ToString(bytes[idx], 2);

        // Ensure leading zero exists if value is positive.
        if (binary[0] != '0' && bigint.Sign == 1)
        {
            base2.Append('0');
        }

        // Append binary string to StringBuilder.
        base2.Append(binary);

        // Convert remaining bytes adding leading zeros.
        for (idx--; idx >= 0; idx--)
        {
            base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
        }

        return base2.ToString();
    }
}
