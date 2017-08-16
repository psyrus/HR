using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int[] solve(int[] grades){
        // Complete this function
        for(int i=0; i<grades.Length; i++)
        {
            int thisGrade = grades[i];
            if(thisGrade < 38)
            {
                continue;
            }
            else if(thisGrade % 5 > 2)
            {
                thisGrade = thisGrade + 5 - (thisGrade % 5);
                grades[i] = thisGrade;
            }
        }
        return grades;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] grades = new int[n];
        for(int grades_i = 0; grades_i < n; grades_i++){
           grades[grades_i] = Convert.ToInt32(Console.ReadLine());   
        }
        int[] result = solve(grades);
        Console.WriteLine(String.Join("\n", result));
        

    }
}
