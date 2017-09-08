using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/non-divisible-subset
    /// Given a set, S, of n distinct integers, print the size of a maximal subset, S', of S where the sum of any 2 numbers in S' is not evenly divisible by k.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int[] firstLine = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int numItems = firstLine[0];
        int k = firstLine[1];

        int[] numberSet = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        
        int longestSetLength = 0;
        //Test each set
        for (int i = 0; i < numItems; i++)
        {
            int baseLineCheck = numberSet[i];
            int[] validNumbers = new int[numItems];
            validNumbers[0] = baseLineCheck;
            int index = 1;
            for (int j = 0; j < numItems; j++)
            {
                int currentTest = numberSet[j];
                if (currentTest != baseLineCheck && (currentTest + baseLineCheck) % k != 0)
                {
                    bool isValid = true;
                    for (int x = 0; x < validNumbers.Length; x++)
                    {
                        if ((currentTest + validNumbers[x]) % k == 0)
                        {
                            isValid = false;
                        }
                    }
                    if (isValid)
                    {
                        validNumbers[index] = currentTest;
                        index++;
                    }
                }
            }
            //Console.WriteLine(baseLineCheck + ": " + String.Join(" ", validNumbers));
            if (index > longestSetLength)
            {
                longestSetLength = index;
            }
        }
        Console.WriteLine(longestSetLength);
    }
}