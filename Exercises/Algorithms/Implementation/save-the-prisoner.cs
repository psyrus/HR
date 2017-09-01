using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static int saveThePrisoner(int numPrisoners, int numSweets, int startingPrisoner)
    {
        int figure = (startingPrisoner - 1 + numSweets) % numPrisoners;
        return figure > 0 ? figure : numPrisoners;
    }

    /// <summary>
    /// https://www.hackerrank.com/challenges/save-the-prisoner
    /// A jail has N prisoners, and each prisoner has a unique id number, S, ranging from 1 to N. There are M sweets that must be distributed to the prisoners.
    /// The jailer decides the fairest way to do this is by sitting the prisoners down in a circle(ordered by ascending ),
    /// and then, starting with some random S, distribute one candy at a time to each sequentially numbered prisoner until all candies are distributed.
    /// For example, if the jailer picks prisoner S=2, then his distribution order would be 2,3,4,5,n-1,n,1,2,3,4... until all M sweets are distributed.
    /// But wait—there's a catch—the very last sweet is poisoned! Can you find and print the ID number of the last prisoner to receive a sweet so he can be warned?
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            int s = Convert.ToInt32(tokens_n[2]);
            int result = saveThePrisoner(n, m, s);
            Console.WriteLine(result);
        }
    }
}
