using System;
using System.IO;

/// <summary>
/// https://www.hackerrank.com/challenges/arrays-ds/problem
/// An array is a type of data structure that stores elements of the same type in a contiguous block of memory.
/// In an array, A, of size N, each memory location has some unique index, I (where 0 lte i lte N), that can be referenced as A[I]
/// (you may also see it written as Ai).
/// Given an array, A, of N integers, print each element in reverse order as a single line of space-separated integers.
/// </summary>
class Solution
{

    // Complete the reverseArray function below.
    static int[] reverseArray(int[] a)
    {
        int[] newArray = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            int index = a.Length - 1 - i;
            newArray[index] = a[i];
        }
        return newArray;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int[] res = reverseArray(arr);

        textWriter.WriteLine(string.Join(" ", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
