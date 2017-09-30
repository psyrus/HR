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

            //Initialize the two container types for ball tracking
            Container[] containers = new Container[n];
            BallType[] ballTypes = new BallType[n];

            //Instantitate two dictionaries that will be used to check the numbers of balls against container sizes
            Dictionary<ulong, int> ballCounts = new Dictionary<ulong, int>();
            Dictionary<ulong, int> ContainerBallCounts = new Dictionary<ulong, int>();

            for (int inputRow = 0; inputRow < n; inputRow++)
            {
                string[] containerContents_temp = Console.ReadLine().Split(' ');
                int[] containerContents = Array.ConvertAll(containerContents_temp, Int32.Parse);

                //Add the row of data to the container tracker
                containers[inputRow] = new Container(inputRow, containerContents);
                ContainerBallCounts[containers[inputRow].totalBalls] = ContainerBallCounts.ContainsKey(containers[inputRow].totalBalls) ? ContainerBallCounts[containers[inputRow].totalBalls] + 1 : 1;

                //For each ball in the data row, add it to or create the ball type tracker
                for (int j = 0; j < n; j++)
                {
                    if (ballTypes[j] == null)
                    {
                        ballTypes[j] = new BallType(j, n);
                    }

                    ballTypes[j].AddContainerTracking(inputRow, containers[inputRow].GetBallCount(j));
                }
            }

            //Check if the number of balls of each type have a corresponding container with the same number of balls.
            bool isPossible = true;
            foreach (var balltype in ballTypes)
            {
                if (!isPossible)
                {
                    break;
                }
                if (ContainerBallCounts.ContainsKey(balltype.totalBalls) && ContainerBallCounts[balltype.totalBalls] > 0)
                {
                    ContainerBallCounts[balltype.totalBalls]--;
                }
                else
                {
                    isPossible = false;
                }
            }

            //Final check to display the correct text
            if (isPossible)
            {
                Console.WriteLine("Possible");
            }
            else
            {
                Console.WriteLine("Impossible");
            }
            
        }

    }

    /// <summary>
    /// Tracks the balls contained in a container
    /// </summary>
    public class Container
    {
        int index;
        int[] contents;
        public ulong totalBalls = 0;
        public Container(int inputRow, int[] containerContents)
        {
            index = inputRow;
            contents = containerContents;
            foreach (var item in contents)
            {
                totalBalls += (uint)item;
            }
        }

        internal int GetBallCount(int ballType)
        {
            return contents[ballType];
        }

        public override string ToString()
        {
            string rt = $"Container of index [{index}] contains the following balls: (total of {totalBalls} balls)";
            for (int i = 0; i < contents.Length; i++)
            {
                rt += $"\n\tBallType[{i}]: {contents[i]}";
            }
            return rt;
        }
    }

    /// <summary>
    /// Tracks which containers contain this ball type
    /// </summary>
    public class BallType
    {
        int index;
        int[] containerHolding;
        public ulong totalBalls = 0;
        public BallType(int ballTypeIndex, int numTypes)
        {
            index = ballTypeIndex;
            containerHolding = new int[numTypes];
        }

        internal void AddContainerTracking(int containerIndex, int numBalls)
        {
            containerHolding[containerIndex] += numBalls;
            totalBalls += (uint)numBalls;
        }

        public override string ToString()
        {
            string rt = $"BallType [{index}] is contained in the following containers: (Total of {totalBalls} balls)";
            for (int i = 0; i < containerHolding.Length; i++)
            {
                rt += $"\n\tContainer[{i}]: {containerHolding[i]}";
            }
            return rt;
        }
    }

}
