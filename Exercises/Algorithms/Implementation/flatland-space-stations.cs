using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/flatland-space-stations
    /// Flatland is a country with n cities, m of which have space stations. Each city, ci, is numbered with a distinct index from 0 to n-1, and each city ci is connected to city ci+1 by a bidirectional road that is 1km in length.
    /// For each city, determine its distance to the nearest space station and print the maximum of these distances.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');

        //Add space stations to hashtable so that lookups are O(1)
        HashSet<int> spaceStations = new HashSet<int>();
        foreach (var item in c_temp)
        {
            spaceStations.Add(int.Parse(item));
        }

        //Loop through array left to right to determine base distances
        int distanceCounter = -1;
        int[] distances = new int[n];
        bool spaceStationSeen = false;
        for (int i = 0; i < n; i++)
        {
            if (spaceStations.Contains(i))
            {
                distanceCounter = 0;
                spaceStationSeen = true;
            }

            distances[i] = distanceCounter;
            distanceCounter++;
        }


        //Loop again backwards to make sure each has its shortest distance
        distanceCounter = -1;
        spaceStationSeen = false;
        for (int i = 1; i <= n; i++)
        {
            int backIndex = n - i;
            if (spaceStations.Contains(backIndex))
            {
                distanceCounter = 0;
                spaceStationSeen = true;
            }

            if (!spaceStationSeen)
            {
                continue;
            }

            if (distances[backIndex] == -1 || distances[backIndex] > distanceCounter)
            {
                distances[backIndex] = distanceCounter;
            }
            distanceCounter++;            
        }

        //Sort the array and print out the highest value.
        // Would prefer to keep track of the highest value in the code to avoid another loop over the array, but it became spaghetti.
        Array.Sort(distances);
        Console.WriteLine(distances[distances.Length -1]);
    }
}
