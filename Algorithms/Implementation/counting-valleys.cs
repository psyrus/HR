using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = Convert.ToInt32(Console.ReadLine());
        string steps = Console.ReadLine();
        
        int currentHeight = 0;
        int numVallies = 0;
        for(int i = 0; i < steps.Length; i++)
        {
            int heightChange = getHeightChange(steps[i]);
            //Console.WriteLine(String.Format("Current height: {0} | Changing by {1}", currentHeight, heightChange));
            if(currentHeight < 0 && heightChange + currentHeight >= 0)
            {
                numVallies++;
            }
            currentHeight += heightChange;
            
        }
        
        Console.WriteLine(numVallies);
    }
    
    static int getHeightChange(char stepString)
    {
        return stepString == 'D' ? -1 : 1;
    }
}