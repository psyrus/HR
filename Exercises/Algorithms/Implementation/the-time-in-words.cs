using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// Given the time in numerals we may convert it into words.
    /// Anything after 31 is "minutes to X"
    /// Before 30 is "minutes past X"
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int h = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());

        Dictionary<int, string> timeConversion = new Dictionary<int, string>();
        timeConversion.Add(0, "o' clock");
        timeConversion.Add(1, "one");
        timeConversion.Add(2, "two");
        timeConversion.Add(3, "three");
        timeConversion.Add(4, "four");
        timeConversion.Add(5, "five");
        timeConversion.Add(6, "six");
        timeConversion.Add(7, "seven");
        timeConversion.Add(8, "eight");
        timeConversion.Add(9, "nine");
        timeConversion.Add(10, "ten");
        timeConversion.Add(11, "eleven");
        timeConversion.Add(12, "twelve");
        timeConversion.Add(13, "thirteen");
        timeConversion.Add(14, "fourteen");
        timeConversion.Add(15, "quarter");
        timeConversion.Add(16, "sixteen");
        timeConversion.Add(17, "seventeen");
        timeConversion.Add(18, "eighteen");
        timeConversion.Add(19, "nineteen");
        timeConversion.Add(20, "twenty");
        timeConversion.Add(21, "twenty one");
        timeConversion.Add(22, "twenty two");
        timeConversion.Add(23, "twenty three");
        timeConversion.Add(24, "twenty four");
        timeConversion.Add(25, "twenty five");
        timeConversion.Add(26, "twenty six");
        timeConversion.Add(27, "twenty seven");
        timeConversion.Add(28, "twenty eight");
        timeConversion.Add(29, "twenty nine");
        timeConversion.Add(30, "half");


        if (m == 0)
        {
            Console.WriteLine($"{timeConversion[h]} {timeConversion[m]}");
        }
        else if (m <= 30)
        {
            string addIn = "";
            if (m == 1)
            {
                addIn = " minute";
            }
            else if (m % 15 != 0)
            {
                addIn = " minutes";
            }

            Console.WriteLine($"{timeConversion[m]}{addIn} past {timeConversion[h]}");
        }
        else
        {
            m = 60 - m;
            h = h + 1;
            string addIn = "";
            if (m == 1)
            {
                addIn = " minute";
            }
            else if (m % 15 != 0)
            {
                addIn = " minutes";
            }

            Console.WriteLine($"{timeConversion[m]}{addIn} to {timeConversion[h]}");
        }
        string finalTime = $"";
    }
}
