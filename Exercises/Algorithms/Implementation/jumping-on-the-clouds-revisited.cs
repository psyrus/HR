using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/jumping-on-the-clouds-revisited
    /// Aerith is playing a cloud game! In this game, there are n clouds numbered sequentially from 0 to n-1. Each cloud is either an ordinary cloud or a thundercloud.
    /// Aerith starts out on cloud 0 with energy level E=100.She can use 1 unit of energy to make a jump of size k to cloud (i+k) % n, and she jumps until she gets back to cloud 0.If Aerith lands on a thundercloud, her energy (E) decreases by 2 additional units.The game ends when Aerith lands back on cloud 0.
    /// Given the values of n, k, and the configuration of the clouds, can you determine the final value of E after the game ends?
    /// If ci=0, then cloud i is an ordinary cloud.
    /// If ci=1, then cloud i is a thundercloud.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int numClouds = Convert.ToInt32(tokens_n[0]);
        int jumpsize = Convert.ToInt32(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');
        int[] clouds = Array.ConvertAll(c_temp, Int32.Parse);

        int currentEnergy = 100;
        int currentCloudIndex = 0;
        while (currentEnergy == 100 || (currentEnergy > 0 && currentCloudIndex != 0))
        {
            currentCloudIndex = (currentCloudIndex + jumpsize) % (numClouds);
            currentEnergy -= (1 + (clouds[currentCloudIndex] * 2));
            //Console.WriteLine($"Jumped to index [{currentCloudIndex}] where the val is [{clouds[currentCloudIndex]}], current energy is now [{currentEnergy}]");
        }

        Console.WriteLine(currentEnergy);
    }
}
