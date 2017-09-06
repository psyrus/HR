using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/library-fine
    /// Your local library needs your help! Given the expected and actual return dates for a library book, create a program that calculates the fine (if any). The fee structure is as follows:
    /// 1) If the book is returned on or before the expected return date, no fine will be charged(i.e.: fine = 0).
    /// 2) If the book is returned after the expected return day but still within the same calendar month and year as the expected return date, fine = 15 hackos x the number of days late.
    /// 3) If the book is returned after the expected return month but still within the same calendar year as the expected return date, the fine = 500 hackos x the number of days late.
    /// 4) If the book is returned after the calendar year in which it was expected, there is a fixed fine of 10,000 hackos.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string[] tokens_d1 = Console.ReadLine().Split(' ');
        int d1 = Convert.ToInt32(tokens_d1[0]);
        int m1 = Convert.ToInt32(tokens_d1[1]);
        int y1 = Convert.ToInt32(tokens_d1[2]);
        string[] tokens_d2 = Console.ReadLine().Split(' ');
        int d2 = Convert.ToInt32(tokens_d2[0]);
        int m2 = Convert.ToInt32(tokens_d2[1]);
        int y2 = Convert.ToInt32(tokens_d2[2]);

        DateTime expectedDate = new DateTime(y2, m2, d2);
        DateTime returnedDate = new DateTime(y1, m1, d1);

        Console.WriteLine(GetFine(expectedDate, returnedDate));
    }

    private static int GetFine(DateTime expectedDate, DateTime returnedDate)
    {
        TimeSpan lateTimeSpan = returnedDate - expectedDate;

        if (lateTimeSpan.TotalDays <= 0)
        {
            return 0;
        }
        else if(new DateTime(expectedDate.Year,expectedDate.Month, 1) == new DateTime(returnedDate.Year, returnedDate.Month, 1))
        {
            return lateTimeSpan.Days * 15;
        }
        else if(expectedDate.Year == returnedDate.Year)
        {
            return (returnedDate.Month - expectedDate.Month) * 500;
        }
        else
        {
            return 10000;
        }
    }
}
