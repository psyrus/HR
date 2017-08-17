using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/designer-pdf-viewer
    /// Consider a word consisting of lowercase English alphabetic letters, where each letter is 1mm wide. Given the height of each letter in millimeters (mm), find the total area that will be highlighted by blue rectangle in  when the given word is selected in our new PDF viewer.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string[] h_temp = Console.ReadLine().Split(' ');
        int[] h = Array.ConvertAll(h_temp, Int32.Parse);
        string word = Console.ReadLine();

        int alphabetOffset = (int)'a';
        int maxHeight = 0;
        foreach (int item in word)
        {
            int arrayPos = item - alphabetOffset;
            if (h[arrayPos] > maxHeight)
            {
                maxHeight = h[arrayPos];
            }
        }

        Console.WriteLine(maxHeight * word.Length);
    }
}
