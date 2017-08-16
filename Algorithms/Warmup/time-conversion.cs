using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static string timeConversion(string s) {
        // Complete this function
        string suffix = s.Substring(s.Length-2);
        string[] timeBreakdown = s.Substring(0, s.Length-2).Split(':');
        if(suffix == "PM" && timeBreakdown[0] != "12")
        {
            timeBreakdown[0] = (Int32.Parse(timeBreakdown[0]) + 12).ToString(); 
        }
        else if(suffix == "AM" && timeBreakdown[0] == "12")
        {
            timeBreakdown[0] = "00";
        }
        
        return String.Join(":",timeBreakdown);
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        string result = timeConversion(s);
        Console.WriteLine(result);
    }
}
