using System;
using System.IO;
/// <summary>
/// https://www.hackerrank.com/challenges/2d-array
/// Given a 6x6 2D Array, arr
/// We define an hourglass in A to be a subset of values with indices falling in this pattern in arr's graphical representation...
/// 
/// There are 16 hourglasses in arr, and an hourglass sum is the sum of an hourglass' values. Calculate the hourglass sum for every hourglass in arr, then print the maximum hourglass sum.
/// </summary>
class Solution
{
    static int ARRAY_WIDTH = 6;
    static int ARRAY_HEIGHT = 6;
    // Complete the hourglassSum function below.
    static int hourglassSum(int[][] arr)
    {
        int maxSum = int.MinValue;
        for (int arrRow = 0; arrRow <= ARRAY_HEIGHT / 2; arrRow++)
        {
            for (int arrColumn = 0; arrColumn <= ARRAY_WIDTH / 2; arrColumn++)
            {
                Console.WriteLine($"Evaluating the I starting from [{arrRow}][{arrColumn}]");
                int thisSum = singleHourglassSum(arr, arrRow, arrColumn);
                Console.WriteLine($"Sum is: {thisSum}");
                if (thisSum > maxSum)
                {
                    maxSum = thisSum;
                }
            }
        }
        return maxSum;
    }

    /// <summary>
    /// Function to calculate the sum of an hourglass in a 2d array.
    /// Assumes index is legitimate start of an hourglass (within bounds)
    /// </summary>
    /// <param name="arr">The array to check</param>
    /// <param name="col">Starting X coordinate from top left</param>
    /// <param name="row">Starting Y coordinate from top left</param>
    /// <returns>Sum of hourglass values.</returns>
    static int singleHourglassSum(int[][] arr, int col, int row)
    {
        return arr[row][col] + arr[row][col + 1] + arr[row][col + 2] + arr[row + 1][col + 1] + arr[row + 2][col] + arr[row + 2][col + 1] + arr[row + 2][col + 2];
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
