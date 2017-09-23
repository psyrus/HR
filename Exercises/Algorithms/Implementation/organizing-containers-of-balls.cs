using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/organizing-containers-of-balls
    /// David has n containers and n different types of balls, both of which are numbered from 0 to n-1. The distribution of ball types per container are described by an n x n matrix of integers, M, where each Mc,t is the number of balls of type t in container c. 
    /// 
    /// In a single operation, David can swap two balls located in different containers (i.e., one ball is moved from container ca to cb and the other ball is moved from cb to ca).
    /// David wants to perform some number of swap operations such that both of the following conditions are satisfied:
    /// - Each container contains only balls of the same type.
    /// - No two balls of the same type are located in different containers.
    /// You must perform q queries where each query is in the form of a matrix, M. For each query, print Possible on a new line if David can satisfy the conditions above for the given matrix; otherwise, print Impossible instead.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());
        
        for (int a0 = 0; a0 < q; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] containedBy = new int[n];
            Container[] containers = new Container[n];
            int[][] M = new int[n][];
            for (int M_i = 0; M_i < n; M_i++)
            {
                string[] M_temp = Console.ReadLine().Split(' ');
                M[M_i] = Array.ConvertAll(M_temp, Int32.Parse);
                containers[M_i] = new Container(n, M[M_i]);
            }
            // your code goes here
            for (int i = 0; i < containers.Length; i++)
            {
                var thisContainer = containers[i];
                Console.WriteLine($"This container [{i}]: {String.Join(" | ", thisContainer.ballsInContainer)}");
                for (int j = 0; j < thisContainer.ballsInContainer.Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    if (thisContainer.ballsInContainer[j] > 0 && containers[j].ballsInContainer[i] > 1)
                    {
                        Console.WriteLine($"It's possible to switch [{i}] from the container [{j}] to our container [{i}]");
                    }
                    else
                    {
                        Console.WriteLine($"Not possible to switch [{i}] from the container [{j}] to our container [{i}]");
                    }
                }
            }
            Console.WriteLine();
        }
    }

    class Container
    {
        public int[] ballsInContainer;

        public Container(int size, int[] ballsSet)
        {
            ballsInContainer = ballsSet;
        }


        public bool IsComplete()
        {
            bool foundNumber = false;
            foreach (var item in ballsInContainer)
            {
                if (item > 0)
                {
                    if (foundNumber)
                    {
                        return false;
                    }
                    foundNumber = true;
                }
            }
            return true;
        }

        public void SwapOut(int num)
        {
            if (ballsInContainer[num] <= 0)
            {
                throw new InvalidDataException("Trying to decrement a number that isn't in this container: " + num);
            }
            ballsInContainer[num]--;
        }

        public void SwapIn(int num)
        {
            ballsInContainer[num]++;
        }

        internal bool hasItem(int i)
        {
            return ballsInContainer[i] > 0;
        }
    }
}
