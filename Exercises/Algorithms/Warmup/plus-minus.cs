using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        int totalPositive = 0;
        int totalNegative = 0;
        int totalZero = 0;
        int totalNumbers = arr.Length;
        for(int i= 0; i<totalNumbers; i++)
        {
          if(arr[i] > 0)
          {
            totalPositive++;
          }
          else if(arr[i] < 0)
          {
            totalNegative++;
          }
          else
          {
            totalZero++;
          }
        }
      System.Console.WriteLine((double)totalPositive / (double)totalNumbers);
      System.Console.WriteLine((double)totalNegative / (double)totalNumbers);
      System.Console.WriteLine((double)totalZero / (double)totalNumbers);
    }
}
