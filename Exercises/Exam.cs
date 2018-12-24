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

class Solution
{
    // Complete the maxRegion function below.
    static int maxRegion(int[][] grid)
    {
        HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
        int maxGridSize = 0;
        for (int i = 0; i < grid.Count(); i++)
        {
            for (int j = 0; j < grid[i].Count(); j++)
            {
                if (visited.Contains(new Tuple<int, int>(i, j)))
                {
                    continue;
                }
                if (grid[i][j] == 1)
                {
                    int gs = FindGridSize(grid, visited, i, j);
                    if (maxGridSize < gs)
                    {
                        maxGridSize = gs;
                    }
                }
            }
        }
        return maxGridSize;

    }

    static int FindGridSize(int[][] grid, HashSet<Tuple<int, int>> visited, int x, int y)
    {
        int totalInGrid = 0;
        foreach (int[] pair in GetAdjacent(grid, x, y))
        {
            visited.Add(new Tuple<int, int>(pair[0], pair[1]));
            if (grid[pair[0]][pair[1]] == 1)
            {
                totalInGrid++;
                totalInGrid += FindGridSize(grid, visited, pair[0], pair[1]);
            }
        }
        return totalInGrid;
    }

    static int[][] GetAdjacent(int[][] grid, int x, int y)
    {
        List<int, int> items = new List<int, int>();
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                if (x + i >= 0 && y + j >= 0 && x + i < grid.Count() && y + j < grid[0].Count() && !visited.Contains((x + i, y + j)))
                {
                    items.Add((x + i, y + j));
                }
            }
        }

        return items.ToArray();
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        int[][] grid = new int[n][];

        for (int i = 0; i < n; i++)
        {
            grid[i] = Array.ConvertAll(Console.ReadLine().Split(' '), gridTemp => Convert.ToInt32(gridTemp));
        }

        int res = maxRegion(grid);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
