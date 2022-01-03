using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// https://www.hackerrank.com/challenges/dynamic-array/problem

class Solution
{

    // Complete the dynamicArray function below.
    static List<int> dynamicArray(int n, List<List<int>> queries)
    {
        int lastAnswer = 0;
        List<List<int>> sequences = new List<List<int>>();
        //Add the outer lists for proper indexing
        for (int i = 0; i < n; i++)
        {
            sequences.Add(new List<int>());
        }

        List<int> returnArray = new List<int>();
        int queryNum = 0;
        foreach (List<int> row in queries)
        {
            int query = row[0];
            int x = row[1];
            int y = row[2];

            //int v = Convert.ToInt32(x == lastAnswer);

            int seqNum = XOR(x, lastAnswer) % n;
            if (query == 1)
            {
                sequences[seqNum].Add(y);
            }
            else
            {
                lastAnswer = sequences[seqNum][y % sequences[seqNum].Count];
                returnArray.Add(lastAnswer);
            }
            Console.WriteLine($"***** Query #{queryNum} *****");
            for (int i = 0; i < sequences.Count; i++)
            {
                Console.WriteLine($"Seq #{i}: [{string.Join(", ", sequences[i])}]");

            }
            Console.WriteLine($"Query Type: {query}");
            Console.WriteLine($"X value: {x}");
            Console.WriteLine($"Y value: {y}");
            Console.WriteLine($"LastAnswer value: {lastAnswer}");
            Console.WriteLine($"Target Sequence ({lastAnswer} XOR {x} % {n}): {seqNum}");
            Console.WriteLine($"*************");
            queryNum++;
        }
        return returnArray;
    }
    static int XOR(int num1, int num2)
    {
        num1 = num1 == 0 ? 0 : 1;
        num2 = num2 == 0 ? 0 : 1;

        return Convert.ToInt32(num1 + num2 == 1);
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nq = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nq[0]);

        int q = Convert.ToInt32(nq[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> result = dynamicArray(n, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
