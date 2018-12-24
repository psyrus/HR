using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
// https://www.hackerrank.com/challenges/dynamic-array/problem

class Solution {

    // Complete the dynamicArray function below.
    static List<int> dynamicArray(int n, List<List<int>> queries) {
        int lastAnswer = 0;
        List<List<int>> sequences = List<List<int>>(2);
        foreach (List<int> row in queries)
        {
            int query = row[0];
            int x = row[1];
            int y = row[2];

            bool v = (x == lastAnswer);
            var seqNum = v % 2;
            if (query == 1)
            {
                sequences[seqNum].Add(y);
            }
            else
            {
                var elemVal = 
            }
        }
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nq = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nq[0]);

        int q = Convert.ToInt32(nq[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++) {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> result = dynamicArray(n, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
