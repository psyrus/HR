using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int divisibleSumPairs(int n, int k, int[] ar) {
        // Complete this function
        int maxVal = 100;

        int pairs = 0;
        for(int i = 0; i < ar.Length; i++)
        {
            for(int j = 1; j < ar.Length - i; j++)
            {
                if((ar[i]+ar[i+j]) % k == 0)
                {
                    pairs++;
                }
            }
        }
        return pairs;
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] ar_temp = Console.ReadLine().Split(' ');
        int[] ar = Array.ConvertAll(ar_temp,Int32.Parse);
        int result = divisibleSumPairs(n, k, ar);
        Console.WriteLine(result);
    }
}
