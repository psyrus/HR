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

        // Set up tracking variables
        int[] alicePos = new int[m];
        int currentAliceScoreIndex = m - 1;
        int currentCheckIndex = 0;
        int savedScore = 0;
        int currentRank = 1;

        // Loop through the arrays, comparing the scores to determine alice's score's position on the leaderboard.
        // Loops forward through the scores array, but backwards through Alice's scores
        while (currentAliceScoreIndex >= 0 && currentCheckIndex < n)
        {
            // Only increment the rank when we start looking at the next leaderboard score (tied scores are ignored)
            if (savedScore > scores[currentCheckIndex])
            {
                currentRank++;
            }
            savedScore = scores[currentCheckIndex];

            // If Alice's score is higher or equal, her current score's position will be the same as the current rank on the leaderboard.
            // Otherwise, move to the next score on the leaderboard
            if (alice[currentAliceScoreIndex] >= scores[currentCheckIndex])
            {
                alicePos[currentAliceScoreIndex] = currentRank;
                currentAliceScoreIndex--;
            }
            else
            {
                currentCheckIndex++;
                continue;
            }

        }

        // A final check in case some of Alice's scores were lower than the rest of the leaderboard,
        // in which case we have to rank all those scores as the lowest
        while (currentAliceScoreIndex >= 0)
        {
            if (alicePos[currentAliceScoreIndex] == 0)
            {
                alicePos[currentAliceScoreIndex] = currentRank + 1;
                currentAliceScoreIndex--;
            }
        }

        Console.WriteLine(String.Join("\n", alicePos));
    }
}
