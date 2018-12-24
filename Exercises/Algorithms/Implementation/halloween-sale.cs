using System;
using System.IO;

namespace Exercises.Algorithms.Implementation
{
    /// <summary>
    /// You wish to buy video games from the famous online video game store Mist.
    /// Usually, all games are sold at the same price, P dollars.
    /// However, they are planning to have the seasonal Halloween Sale next month in which you can buy games at a cheaper price.
    /// Specifically, the first game you buy during the sale will be sold at P dollars, but every subsequent game you buy
    /// will be sold at exactly D dollars less than the cost of the previous one you bought.
    /// This will continue until the cost becomes less than or equal to M dollars, after which every game you buy will cost M dollars each.
    /// </summary>
    class Solution
    {

        // Complete the howManyGames function below.
        static int HowManyGames(int p, int d, int m, int s)
        {
            int totalCashRemaining = s;
            int numberOfGames = 0;
            int currentCost = p;
            // Return the number of games you can buy
            while (totalCashRemaining > 0)
            {
                if (totalCashRemaining < currentCost)
                {
                    break;
                }
                numberOfGames++;
                Console.WriteLine($"Game #{numberOfGames} purchased at {currentCost}");
                totalCashRemaining -= currentCost;
                Console.WriteLine($"Total cash remaining: {totalCashRemaining}");

                currentCost = currentCost <= m ? m : currentCost - d;


            }
            return numberOfGames;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] pdms = Console.ReadLine().Split(' ');

            int p = Convert.ToInt32(pdms[0]);

            int d = Convert.ToInt32(pdms[1]);

            int m = Convert.ToInt32(pdms[2]);

            int s = Convert.ToInt32(pdms[3]);

            int answer = HowManyGames(p, d, m, s);

            textWriter.WriteLine(answer);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
