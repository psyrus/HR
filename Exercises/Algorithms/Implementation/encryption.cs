using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/encryption
    /// An English text needs to be encrypted using the following encryption scheme. 
    /// First, the spaces are removed from the text. Let L be the length of this text.
    /// Then, characters are written into a grid, whose rows and columns have the following constraints:
    /// FLOOR(SQRT(L)) lte row lte column lte FLOOR(SQRT(L)), where FLOOR(x) is floor function and CEIL(x) is ceil function
    /// For example, the sentence "if man was meant to stay on the ground god would have given us roots" after removing spaces is 54 characters long, so it is written in the form of a grid with 7 rows and 8 columns.
    /// ifmanwas
    /// meanttos
    /// tayonthe
    /// groundgo
    /// dwouldha
    /// vegivenu
    /// sroots
    /// Ensure that rows x columns >= L
    /// If multiple grids satisfy the above conditions, choose the one with the minimum area, i.e. rows x columns.
    /// The encoded message is obtained by displaying the characters in a column, inserting a space, and then displaying the next column and inserting a space, and so on.For example, the encoded message for the above rectangle is:
    /// imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau
    /// You will be given a message in English with no spaces between the words.The maximum message length can be characters.Print the encoded message.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string s = Console.ReadLine();
        int length = s.Length;

        int rows = (int)Math.Floor(Math.Sqrt(length));
        int columns = (int)Math.Ceiling(Math.Sqrt(length));

        Console.WriteLine(rows);
        Console.WriteLine(columns);
        int coveredCharacters = 0;
        int currentIndex = 0;
        while (coveredCharacters < length)
        {
            Console.Write(s[currentIndex]);
            int newIndex = (currentIndex + columns);

            if (newIndex >= length)
            {
                newIndex = newIndex % length + 1;
                Console.Write(" ");
            }
            currentIndex = newIndex;
            coveredCharacters++;
        }

        //int curColumn = 0;

        //string[] words = new string[columns];
        //foreach (var character in s)
        //{
        //    words[curColumn] += character;

        //    curColumn++;
        //    if (curColumn >= columns)
        //    {
        //        curColumn = 0;
        //    }

        //}

        //Console.WriteLine(String.Join(" ", words));
    }
}
