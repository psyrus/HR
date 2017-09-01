using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/angry-professor
    /// A Discrete Mathematics professor has a class of N students. Frustrated with their lack of discipline, he decides to cancel class if fewer than K students are present when class starts.
    /// Given the arrival time of each student, determine if the class is canceled.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            Console.WriteLine(isClassCancelled(n, k, a));
        }
    }

    static string isClassCancelled(int numStudents, int minAttending, int[] attendingList)
    {
        int onTimeStudentsCount = 0;
        foreach (var arrivalTime in attendingList)
        {
            if (arrivalTime < 1)
            {
                onTimeStudentsCount++;
            }

            if (onTimeStudentsCount >= minAttending)
            {
                return "NO";
            }
        }

        return "YES";
    }
}
