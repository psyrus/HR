﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/queens-attack-2
    /// A queen is standing on an n * n chessboard. The chessboard's rows are numbered from 1 to n, going from bottom to top; its columns are numbered from 1 to n, going from left to right. Each square on the board is denoted by a tuple, (r, c), describing the row, r, and column, c, where the square is located.
    /// The queen is standing at position (rq,cq) and, in a single move, she can attack any square in any of the eight directions(left, right, up, down, or the four diagonals).
    /// There are k obstacles on the chessboard preventing the queen from attacking any square that has an obstacle blocking the the queen's path to it. For example, an obstacle at location (3,5) in the diagram above would prevent the queen from attacking cells (3,5), (2,6), and (1,7):
    /// Given the queen's position and the locations of all the obstacles, find and print the number of squares the queen can attack from her position at (rq,cq).
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] tokens_rQueen = Console.ReadLine().Split(' ');
        int rQueen = Convert.ToInt32(tokens_rQueen[0]);
        int cQueen = Convert.ToInt32(tokens_rQueen[1]);


        Chessboard board = new Chessboard(n);
        board.AddPiece(new Position(rQueen, cQueen), Chessboard.Piece.Queen);


        for (int a0 = 0; a0 < k; a0++)
        {
            string[] tokens_rObstacle = Console.ReadLine().Split(' ');
            int rObstacle = Convert.ToInt32(tokens_rObstacle[0]);
            int cObstacle = Convert.ToInt32(tokens_rObstacle[1]);
            // your code goes here

            board.AddPiece(new Position(rObstacle, cObstacle), Chessboard.Piece.Obstacle);
        }

        Console.WriteLine(RunRayTraces(board));
    }

    /// <summary>
    /// Tests the 8 directions on the board from the queen's origin to see how many total valid spaces the queen can move to.
    /// </summary>
    /// <param name="board">Preinitialized chess board with a queen position.</param>
    /// <returns></returns>
    private static int RunRayTraces(Chessboard board)
    {
        int possibleAttackSquares = 0;
        //The 8 directions are (column change, row change) -> 0,1 | 0,-1 | 1,1 | 1,-1 | 1,0 | -1,1 | -1,-1 | -1,0
        //Using loops, we don't have to hardcode it.
        for (int i = 1; i >= -1; i--)
        {
            for (int j = 1; j >= -1; j--)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                possibleAttackSquares += RayTrace(board, i, j);
            }
        }
        return possibleAttackSquares;
    }

    /// <summary>
    /// Runs a single line trace originating from the queen's position, going in the direction set by colChange and rowChange until it hits an obstacle.
    /// </summary>
    /// <param name="board">Preinitialized chess board with a queen position.</param>
    /// <param name="colChange">Rate of change of column move</param>
    /// <param name="rowChange">Rate of change of row move</param>
    /// <returns></returns>
    private static int RayTrace(Chessboard board, int colChange, int rowChange)
    {
        int totalValidSquares = 0;
        Position testPos = board.queenPosition.Copy();
        testPos.Alter(colChange, rowChange);
        while (board.isValid(testPos))
        {
            totalValidSquares++;
            testPos.Alter(colChange, rowChange);
        }
        return totalValidSquares;
    }

    public class Position
    {
        int rowPos;
        int colPos;

        public Position(int col, int row)
        {
            this.rowPos = row;
            this.colPos = col;
        }

        public int ColIndex
        {
            get
            {
                return colPos - 1;

            }
        }

        public int RowIndex
        {
            get
            {
                return rowPos - 1;
            }
        }

        internal void Alter(int i, int j)
        {
            this.colPos += i;
            this.rowPos += j;
        }

        internal Position Copy()
        {
            return new Position(colPos, rowPos);
        }

        internal Tuple<int, int> ToIndexTuple()
        {
            return new Tuple<int, int>(ColIndex, RowIndex);
        }
    }

    public class Chessboard
    {
        int size;
        Dictionary<Tuple<int, int>, Piece> squares;
        public Position queenPosition;

        public enum Piece
        {
            Empty,
            Obstacle,
            Queen
        };
        public Chessboard(int n)
        {
            this.size = n;
            squares = new Dictionary<Tuple<int, int>, Piece>();

        }

        public void AddPiece(Position itemPos, Piece pieceType)
        {
            squares[itemPos.ToIndexTuple()] = pieceType;
            if (pieceType == Piece.Queen)
            {
                queenPosition = itemPos;
            }
        }

        public bool IsEmpty(Position square)
        {
            return !squares.ContainsKey(square.ToIndexTuple()) || squares[square.ToIndexTuple()] == Piece.Empty;
        }

        public bool isValid(Position attempt)
        {
            //Console.WriteLine($"\t Testing if Position[{attempt.ColIndex},{attempt.RowIndex}] is valid.");
            return attempt.ColIndex < size && attempt.ColIndex >= 0 && attempt.RowIndex < size && attempt.RowIndex >= 0 && IsEmpty(attempt);
        }
    }
}
