using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/lisa-workbook
    /// Lisa just got a new math workbook. A workbook contains exercise problems, grouped into chapters.
    /// There are n chapters in Lisa's workbook, numbered from 1 to n.
    /// The i-th chapter has ti problems, numbered from 1 to ti.
    /// Each page can hold up to k problems. There are no empty pages or unnecessary spaces, so only the last page of a chapter may contain fewer than k problems.
    /// Each new chapter starts on a new page, so a page will never contain problems from more than one chapter.
    /// The page number indexing starts at 1.
    /// Lisa believes a problem to be special if its index (within a chapter) is the same as the page number where it's located. Given the details for Lisa's workbook, can you count its number of special problems?
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string[] firstLine = Console.ReadLine().Split(' ');
        string[] secondLine = Console.ReadLine().Split(' ');

        int numChapters = int.Parse(firstLine[0]);
        int problemsPerChapterPage = int.Parse(firstLine[1]);

        int specialProblemsCount = 0;
        int totalPagesPassed = 1;
        foreach (var item in secondLine)
        {
            int problems = int.Parse(item);
            Chapter thisChapter = new Chapter(problemsPerChapterPage, problems);
            specialProblemsCount += thisChapter.GetTotalSpecial(totalPagesPassed);
            totalPagesPassed += thisChapter.totalPages;
        }

        Console.WriteLine(specialProblemsCount);
    }

    class Chapter
    {
        int problemsPerPage;
        int totalProblems;
        public int totalPages;
        int overflowProblems;
        int chapterNum;
        public Chapter(int problemsPerPage, int totalProblems)
        {
            this.problemsPerPage = problemsPerPage;
            this.totalProblems = totalProblems;

            overflowProblems = totalProblems % problemsPerPage;
            totalPages = totalProblems / problemsPerPage;
            if (overflowProblems > 0)
            {
                totalPages += 1;
            }
        }

        internal int GetTotalSpecial(int chapterStartPage)
        {
            int totalSpecial = 0;
            if (chapterStartPage > totalProblems)
            {
                return totalSpecial;
            }

            for (int pageOffset = 0; pageOffset < totalPages; pageOffset++)
            {
                int currentPage = chapterStartPage + pageOffset;
                int minProbIndex = pageOffset * problemsPerPage + 1;
                int maxProbIndex = (pageOffset + 1) * problemsPerPage;

                if (currentPage >= minProbIndex && currentPage <= maxProbIndex)
                {
                    totalSpecial++;
                }
            }
            return totalSpecial;
        }
    }
}