using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/chocolate-feast
    /// Little Bobby loves chocolate, and he frequently goes to his favorite 5&10 store, Penny Auntie, with n dollars to buy chocolates. Each chocolate has a flat cost of c dollars, and the store has a promotion where they allow you to trade in m chocolate wrappers in exchange for 1 free piece of chocolate.
    /// For example, if m=2 and Bobby has dollars that he uses to buy 4 chocolates at dollar c=1 apiece, he can trade in the 4 wrappers to buy 2 more chocolates.Now he has 2 more wrappers that he can trade in for 1 more chocolate. Because he only has 1 wrapper left at this point and 1 lt m, he was only able to eat a total of 7 pieces of chocolate.
    /// Given n, c, and m for t trips to the store, can you determine how many chocolates Bobby eats during each trip?
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int a0 = 0; a0 < t; a0++)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int dollars = Convert.ToInt32(tokens_n[0]);
            int chocolatePrice = Convert.ToInt32(tokens_n[1]);
            int wrappersNeeded = Convert.ToInt32(tokens_n[2]);
            int leftoverWrappers = 0;

            int chocolatesPurchased = dollars / chocolatePrice;
            leftoverWrappers += chocolatesPurchased;

            //After the initial purchase, keep looping to redeem wrappers for more chocolate until no more wrappers can be redeemed
            int redeemedChocolates = 0;
            while (leftoverWrappers >= wrappersNeeded)
            {
                redeemedChocolates += leftoverWrappers / wrappersNeeded;
                leftoverWrappers = (leftoverWrappers % wrappersNeeded) + (leftoverWrappers / wrappersNeeded);
            }


            Console.WriteLine(chocolatesPurchased + redeemedChocolates);
        }
    }
}
