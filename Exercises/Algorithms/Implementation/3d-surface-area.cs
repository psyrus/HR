using System;
using System.IO;
/// <summary>
/// https://www.hackerrank.com/challenges/3d-surface-area/problem
/// </summary>
class Solution
{

    static int getOccludedFacesCount(int[][] A, int xPos, int yPos)
    {
        int totalOcclusions = 0;
        int maxOcclusionValue = A[xPos][yPos];
        Console.WriteLine(String.Format("Occlusions for [{0}][{1}] with height {2}", xPos, yPos, maxOcclusionValue));

        // Check each of the four sides
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    continue;
                }
                try
                {
                    int adjascentHeight = A[xPos + i][yPos + j];
                    int thisOcclusion = Math.Min(adjascentHeight, maxOcclusionValue);
                    totalOcclusions += thisOcclusion;
                    Console.WriteLine(String.Format("\tThe block at [{0}][{1}] has a height of {2} and added occlusion was {3}", xPos + i, yPos + j, adjascentHeight, thisOcclusion));
                }
                catch (IndexOutOfRangeException ex)
                {
                    //Console.WriteLine(String.Format("Of course you can't get array value [{0}][{1}]", xPos + i, yPos + j));
                }
            }
        }

        Console.WriteLine(String.Format("\tOcclusions total is {0}", totalOcclusions));
        return totalOcclusions;
    }

    // Complete the surfaceArea function below.
    static int surfaceArea(int[][] A)
    {
        int total = 0;
        // Loop through each row
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < A[i].Length; j++)
            {
                int height = A[i][j];
                total += 2 + height * 4;

                total -= getOccludedFacesCount(A, i, j);
            }
        }

        return total;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] HW = Console.ReadLine().Split(' ');

        int H = Convert.ToInt32(HW[0]);

        int W = Convert.ToInt32(HW[1]);

        int[][] A = new int[H][];

        for (int i = 0; i < H; i++)
        {
            A[i] = Array.ConvertAll(Console.ReadLine().Split(' '), ATemp => Convert.ToInt32(ATemp));
        }

        int result = surfaceArea(A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
