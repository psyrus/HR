using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        long max = 0;
        long min = 0;
        long total = 0;
        for(int i = 0; i < arr.Length; i++)
        {
            total += arr[i];
        }
        
        min = total;
        max = total - arr[0];
        for(int i = 0; i < arr.Length; i++)
        {
            long thisTotal = total - arr[i];
            if(thisTotal > max)
            {
                max = thisTotal;
            }
            else if(thisTotal < min)
            {
                min = thisTotal;
            }
        }
        Console.WriteLine(String.Format("{0} {1}", min, max));
    }
}
