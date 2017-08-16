using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int birthdayCakeCandles(int n, int[] ar) {
        // Complete this function
        
        int blownCandles = 0;
        int maxSeenHeight = 0;
        for(int i = 0; i < ar.Length; i++)
        {
            if(ar[i] < maxSeenHeight)
            {
                continue;
            }
            if(ar[i] > maxSeenHeight)
            {
                maxSeenHeight = ar[i];
                blownCandles = 0;
            }
            blownCandles++;
        }
        
        return blownCandles;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] ar_temp = Console.ReadLine().Split(' ');
        int[] ar = Array.ConvertAll(ar_temp,Int32.Parse);
        int result = birthdayCakeCandles(n, ar);
        Console.WriteLine(result);
        
    }
}
