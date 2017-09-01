using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/circular-array-rotation
    /// John Watson performs an operation called a right circular rotation on an array of integers, [a0 to an-1]. After performing one right circular rotation operation, the array is transformed from [a0 to an-1] to [an-1, a0 to an-2].
    /// Watson performs this operation K times. To test Sherlock's ability to identify the current element at a particular position in the rotated array,
    /// Watson asks q queries, where each query consists of a single integer, M,
    /// for which you must print the element at index M in the rotated array (i.e., the value of am).
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int numEntries = Convert.ToInt32(tokens_n[0]);
        int timesRotated = Convert.ToInt32(tokens_n[1]);
        int queriesCount = Convert.ToInt32(tokens_n[2]);
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp, Int32.Parse);
        for (int a0 = 0; a0 < queriesCount; a0++)
        {
            int indexToCheck = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(a[(indexToCheck + timesRotated) % numEntries]);
        }
    }
}
