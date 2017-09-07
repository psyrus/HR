using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/jumping-on-the-clouds
    /// Emma is playing a new mobile game involving  clouds numbered from 0 to n-1. A player initially starts out on cloud 0, and they must jump to cloud n-1. In each step, she can jump from any cloud i to cloud i+1 or cloud i+2.
    /// There are two types of clouds, ordinary clouds and thunderclouds.The game ends if Emma jumps onto a thundercloud, but if she reaches the last cloud(i.e., n-1), she wins the game!
    /// Can you find the minimum number of jumps Emma must make to win the game? It is guaranteed that clouds 0 and n-1 are ordinary-clouds and it is always possible to win the game.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] c_temp = Console.ReadLine().Split(' ');
        int[] c = Array.ConvertAll(c_temp, Int32.Parse);

        int currentPos = 0;
        int totalJumps = 0;
        while (currentPos < n-1)
        {
            currentPos += TakeAJump(c, currentPos);
            totalJumps++;
        }

        Console.WriteLine(totalJumps);
    }

    private static int TakeAJump(int[] clouds, int currentPos)
    {
        int jumpAmount = clouds.Length > currentPos + 2 && clouds[currentPos + 2] == 0 ? 2 : 1;
        return jumpAmount;
    }

}
