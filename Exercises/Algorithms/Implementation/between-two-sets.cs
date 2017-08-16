using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int getTotalX(int[] a, int[] b){
        // Complete this function
        //Get the largest value of set a as minVal
        int minVal = 0;
        for(int i = 0; i < a.Length; i++)
        {
            if(a[i] > minVal)
            {
                minVal = a[i];
            }
        }
        //Get the smallest value of set b as maxVal
        int maxVal = b[0];
        for(int i = 0; i < b.Length; i++)
        {
            if(b[i] < maxVal)
            {
                maxVal = b[i];
            }
        }
        
        int validItems = 0;
        //Range of x is between minVal and maxVal, so test each value between them?
        for(int i = minVal; i <= maxVal; i++)
        {
            bool thisOneValid = true;
            //Test against the first set
            for(int j = 0; j < a.Length && thisOneValid; j++)
            {
                if(i % a[j] > 0)
                {
                    thisOneValid = false;
                    continue;
                }
            }
            //Test against the second set
            
            for(int j = 0; j < b.Length && thisOneValid; j++)
            {
                if(b[j] % i > 0)
                {
                    thisOneValid = false;
                    continue;
                }
            }
            if(thisOneValid)
            {
                validItems++;
            }
            
        }
        
        
        return validItems;
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        string[] b_temp = Console.ReadLine().Split(' ');
        int[] b = Array.ConvertAll(b_temp,Int32.Parse);
        int total = getTotalX(a, b);
        Console.WriteLine(total);
    }
}
