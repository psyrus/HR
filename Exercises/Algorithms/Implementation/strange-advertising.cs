using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/strange-advertising/problem
    /// Given an integer, , find and print the total number of people who liked HackerLand Enterprise's advertisement during the first  days. It is guaranteed that no two people have any friends in common and, after a person shares the advertisement with a friend, the friend always sees it the next day.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int advertisingIterations = int.Parse(Console.ReadLine());

        int initialTargets = 5;

        int currentlyAdvertisedPeople = initialTargets;
        int totalLiked = 0;
        for (int i = 0; i < advertisingIterations; i++)
        {
            int newLiked = (int)Math.Floor((double)currentlyAdvertisedPeople / 2);
            totalLiked += newLiked;
            currentlyAdvertisedPeople = newLiked * 3;
        }

        Console.WriteLine(totalLiked);
    }
}