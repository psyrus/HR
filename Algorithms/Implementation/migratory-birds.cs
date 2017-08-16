using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int migratoryBirds(int n, int[] ar) {
        // Complete this function
        int typesOfBirds = 5;
        int[] birdsCount = new int[typesOfBirds+1];
        
        for(int i = 0; i < ar.Length; i++)
        {
            birdsCount[ar[i]]++;
        }
        
        
        int highestType = 0;
        for(int i = 0; i < birdsCount.Length; i++)
        {
            //Console.WriteLine(String.Format("{0}:{1} | Current Highest: {2}", i, birdsCount[i], highestType));
            if(birdsCount[i] > birdsCount[highestType])
            {
                highestType = i;
            }
        }
        
        return highestType;
        
        
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] ar_temp = Console.ReadLine().Split(' ');
        int[] ar = Array.ConvertAll(ar_temp,Int32.Parse);
        int result = migratoryBirds(n, ar);
        Console.WriteLine(result);
    }
}
