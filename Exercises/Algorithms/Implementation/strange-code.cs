using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/strange-code/problem
    /// Bob has a strange counter. At the first second, t = 1, it displays the number 3. 
    /// At each subsequent second, the number displayed by the counter decrements by 1.
    /// The counter counts down in cycles.
    /// In the second after the counter counts down to 1, the number becomes 2x the initial number for that countdown cycle and 
    /// then continues counting down from the new initial number in a new cycle.
    /// Given a time, t, find and print the value displayed by the counter at time t.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        int counterInitialValue = 3;

        //Formula is 3 * 2 ^ iterations
        // ((t - 1) / 3 + 1) * 3 - ((t - 1) % 3) = v
    }
}
