using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_s = Console.ReadLine().Split(' ');
        int houseLeft = Convert.ToInt32(tokens_s[0]);
        int houseRight = Convert.ToInt32(tokens_s[1]);
        string[] tokens_a = Console.ReadLine().Split(' ');
        int leftTree = Convert.ToInt32(tokens_a[0]);
        int rightTree = Convert.ToInt32(tokens_a[1]);
        string[] tokens_m = Console.ReadLine().Split(' ');
        int numApples = Convert.ToInt32(tokens_m[0]);
        int numOranges = Convert.ToInt32(tokens_m[1]);
        string[] apple_temp = Console.ReadLine().Split(' ');
        int[] apple = Array.ConvertAll(apple_temp,Int32.Parse);
        string[] orange_temp = Console.ReadLine().Split(' ');
        int[] orange = Array.ConvertAll(orange_temp,Int32.Parse);
        
        //Left tree distance to house
        int leftTreeDistance = houseLeft - leftTree;
        
        //Right Tree distance to house
        int rightTreeDistance = rightTree - houseRight;
        
        //Console.WriteLine(String.Format("Left tree dist:{0} Right Tree dist:{1}", leftTreeDistance, rightTreeDistance));
        
        int applesHit = 0;
        int orangesHit = 0;
        
        //Apples detection
        for(int i = 0; i < apple.Length; i++)
        {
            int thisApplePos = leftTree + apple[i];
            if(thisApplePos >= houseLeft && thisApplePos <= houseRight)
            {
                applesHit++;
            }
        }
        
        //Oranges detection
        for(int j = 0; j < orange.Length; j++)
        {
            int thisOrangePos = rightTree + orange[j];
            if(thisOrangePos >= houseLeft && thisOrangePos <= houseRight)
            {
                orangesHit++;
            }
        }
        
        Console.WriteLine(applesHit);
        Console.WriteLine(orangesHit);
    }
}
