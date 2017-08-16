using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int[] getRecord(int[] s){
        // Complete this function
        int highestScore = s[0];
        int lowestScore = s[0];
        
        int highestBrokenCount = 0;
        int lowestBrokenCount = 0;
        
        for(int i = 1; i < s.Length; i++)
        {
            int thisScore = s[i];
            if(thisScore > highestScore)
            {
                highestScore = thisScore;
                highestBrokenCount++;
            }
            else if(thisScore < lowestScore)
            {
                lowestScore = thisScore;
                lowestBrokenCount++;
            }
        }
        return new int [] { highestBrokenCount, lowestBrokenCount};
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] s_temp = Console.ReadLine().Split(' ');
        int[] s = Array.ConvertAll(s_temp,Int32.Parse);
        int[] result = getRecord(s);
        Console.WriteLine(String.Join(" ", result));
    }
}
