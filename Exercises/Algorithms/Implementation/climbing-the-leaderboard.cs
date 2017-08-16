using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/climbing-the-leaderboard
    /// Alice is playing an arcade game and wants to climb to the top of the leaderboard. Can you help her track her ranking as she beats each level? The game uses Dense Ranking, so its leaderboard works like this:
    /// The player with the highest score is ranked number  on the leaderboard.
    /// Players who have equal scores receive the same ranking number, and the next player(s) receive the immediately following ranking number.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] scores_temp = Console.ReadLine().Split(' ');
        int[] scores = Array.ConvertAll(scores_temp, Int32.Parse);
        int m = Convert.ToInt32(Console.ReadLine());
        string[] alice_temp = Console.ReadLine().Split(' ');
        int[] alice = Array.ConvertAll(alice_temp, Int32.Parse);
        // your code goes here

        int[] alicePos = new int[m];
        int currentAliceScoreIndex = m-1;
        int currentCheckIndex = 0;
        int currentScore = 0;
        int currentRank = 1;

        while (currentAliceScoreIndex >= 0 && currentCheckIndex < n)
        {
            if (scores[currentCheckIndex] < currentScore)
            {
                currentRank++;

                Console.WriteLine(String.Format("***Increasing observed rank by 1 to: {0}***", currentRank));
            }

            Console.WriteLine(String.Format("Alice[{0}] ({1}) >= Scores[{2}] ({3}) ?", currentAliceScoreIndex, alice[currentAliceScoreIndex], currentCheckIndex, scores[currentCheckIndex]));
            if (alice[currentAliceScoreIndex] >= scores[currentCheckIndex])
            {
                Console.WriteLine(String.Format("\tYes! -> Setting Alice[{0}] to Rank: {1}", currentAliceScoreIndex, currentRank));
                alicePos[currentAliceScoreIndex] = currentRank;
                currentAliceScoreIndex--;
                Console.WriteLine(String.Format("\tDecrementing Alice's index"));
            }

            Console.WriteLine(String.Format("\tSetting CurrentScore to: {0}", scores[currentCheckIndex]));

            currentScore = scores[currentCheckIndex];
            currentCheckIndex++;
        }
        if (alicePos[currentAliceScoreIndex] == 0)
        {
            Console.WriteLine(String.Format("The first score was the lowest in the group, setting appropriately."));
            currentRank++;
            alicePos[currentAliceScoreIndex] = currentRank;
        }

        Console.WriteLine(String.Join("\n", alicePos));
    }
}
