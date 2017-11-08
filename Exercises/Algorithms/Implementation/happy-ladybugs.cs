using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/happy-ladybugs/problem
    /// Happy Ladybugs is a board game having the following properties:
    /// - The board is represented by a string, b, of length n.The ith character of the string, bi, denotes the ith cell of the board.
    /// -- If bi is an underscore (i.e., _), it means the ith cell of the board is empty.
    /// -- If bi is an uppercase English alphabetic letter (i.e., A through Z), it means the ith cell contains a ladybug of color bi.
    /// -- String b will not contain any other characters.
    /// - A ladybug is happy only when its left or right adjacent cell (i.e.,bi+/-1 ) is occupied by another ladybug having the same color.
    /// - In a single move, you can move a ladybug from its current position to any empty cell.
    /// Given the values of  and  for  games of Happy Ladybugs, determine if it's possible to make all the ladybugs happy. For each game, print YES on a new line if all the ladybugs can be made happy through some number of moves; otherwise, print NO to indicate that no number of moves will result in all the ladybugs being happy.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int numGames = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < numGames; a0++)
        {
            int numCells = Convert.ToInt32(Console.ReadLine());
            string grid = Console.ReadLine();

            Dictionary<char, int> types = new Dictionary<char, int>();
            char previousItem = ' ';
            int minConcurrent = numCells;
            int concurrentCount = 0;
            for (int i = 0; i < numCells; i++)
            {
                char item = grid[i];

                //If the char has not yet been seen, add it. Increment seen values.
                if (!types.ContainsKey(item))
                {
                    types.Add(item, 0);
                }
                types[item]++;

                //Check if this is a perfect set (pairs or more of each ladybug next to each other)
                if (previousItem != item && concurrentCount > 0)
                {
                    if (concurrentCount < minConcurrent)
                    {
                        minConcurrent = concurrentCount;
                    }
                    concurrentCount = 1;
                }
                else
                {
                    concurrentCount++;

                }
                previousItem = item;

            }

            //Final check on the last character to see if it's not a loner.
            if (concurrentCount < minConcurrent)
            {
                minConcurrent = concurrentCount;
            }

            //If there is at least one space, >1 of all bug types OR no ladybugs. OR if it is already a perfect set (minConcurrent > 1)
            if (types.ContainsKey('_'))
            {
                if (types.Keys.Count < 2 || AllOk(types))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");

                }
            }
            else if (minConcurrent > 1)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }

    private static bool AllOk(Dictionary<char, int> bugCounts)
    {
        foreach (var key in bugCounts.Keys)
        {
            if (bugCounts[key] == 1 && key != '_')
            {
                return false;
            }
        }
        return true;
    }
}
