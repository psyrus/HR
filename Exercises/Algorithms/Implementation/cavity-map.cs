using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/cavity-map/problem
    /// You are given a square map of size n x n. Each cell of the map has a value denoting its depth. We will call a cell of the map a cavity if and only if this cell is not on the border of the map and each cell adjacent to it has strictly smaller depth. Two cells are adjacent if they have a common side (edge).
    /// You need to find all the cavities on the map and depict them with the uppercase character X.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] grid = new int[n][];
        for (int grid_i = 0; grid_i < n; grid_i++)
        {
            grid[grid_i] = new int[n];
            string thisLine = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                grid[grid_i][i] = int.Parse(thisLine[i].ToString());
            }
        }
        
        string finalString = "";

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (IsCavity(i, j, grid))
                {
                    finalString += "X";
                }
                else
                {
                    finalString += grid[i][j];
                }
            }
            finalString += (i < n - 1 ? "\n" : "");
        }
        Console.WriteLine(finalString);
    }

    /// <summary>
    /// Checks if all surrounding edges have a depth less than the index in question. 
    /// </summary>
    /// <param name="i">Column of current item</param>
    /// <param name="j">Row of current item</param>
    /// <param name="grid">Grid containing all depth values</param>
    /// <returns>True/False whether the item is a cavity or not.</returns>
    private static bool IsCavity(int i, int j, int[][] grid)
    {
        if (i == 0 || j == 0 || i == grid.Length - 1 || j == grid.Length - 1)
        {
            return false;
        }
 
        int thisVal = grid[i][j];
        bool upIsLess = thisVal > grid[i][j-1];
        bool downIsLess = thisVal > grid[i][j+1];
        bool leftIsLess = thisVal > grid[i-1][j];
        bool rightIsLess = thisVal > grid[i+1][j];

        return upIsLess && downIsLess && leftIsLess && rightIsLess;
    }
}

