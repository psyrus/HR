using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static string solve(int year){
        // Complete this function

        int[] months = new int[] {31,28,31,30,31,30,31,31,30,31,30,31}; 
        if(isLeapYear(year))
        {
            months[1] = 29;
        }
        
        //The switchover year is a special case where they skipped 13 days
        if(year == 1918)
        {
            months[1] -= 13;
        }
        
        int monthsPassed = 0;
        int daysPassed = 0;
        while(daysPassed + months[monthsPassed] < 256)
        {
            daysPassed += months[monthsPassed];
            monthsPassed++;
        }
        
        int days = 256 - daysPassed;
        
        return String.Format("{0:D2}.{1:D2}.{2}", days, monthsPassed+1, year);
    }
    
    static bool isLeapYear(int year)
    {
        //Julian Calendar
        if(year < 1919 && year % 4 == 0)
        {
            return true;
        }
        //Gregorian Calendar
        if(year % 400 == 0 || year % 4 == 0 && year % 100 > 0)
        {
            return true;
        }
        return false;
    }

    static void Main(String[] args) {
        int year = Convert.ToInt32(Console.ReadLine());
        string result = solve(year);
        Console.WriteLine(result);
    }
}
