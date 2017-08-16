using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int solve(int n, int p){
        // Complete this function
        int fromLeft = (p - p % 2) / 2;
        int fromRight = (n - (p - p % 2)) / 2;
        
        return fromLeft < fromRight ? fromLeft : fromRight;
        //=(max(A:A) - (A7-mod(A7,2)))/2
        
        //(leftside - leftside % 2) (rightside - rightside % 2)
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int p = Convert.ToInt32(Console.ReadLine());
        int result = solve(n, p);
        Console.WriteLine(result);
    }
}
