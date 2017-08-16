using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int sockMerchant(int n, int[] ar) {
        // Complete this function
        int[] seen = new int[101];
        int pairs = 0;
        for(int i = 0; i < ar.Length; i++)
        {
            if(seen[ar[i]] > 0)
            {
                pairs++;
                seen[ar[i]] = 0;
            }
            else
            {
                seen[ar[i]]++;
            }
        }
        return pairs;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] ar_temp = Console.ReadLine().Split(' ');
        int[] ar = Array.ConvertAll(ar_temp,Int32.Parse);
        int result = sockMerchant(n, ar);
        Console.WriteLine(result);
    }
}
