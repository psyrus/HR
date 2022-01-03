#!/bin/python3

import math
import os
import random
import re
import sys



#
# Complete the 'numCells' function below.
#
# The function is expected to return an INTEGER.
# The function accepts 2D_INTEGER_ARRAY grid as parameter.
#

def isDominantCell(grid, xPos, yPos):
    thisValue = grid[xPos][yPos]
    neighbors = getNeighborValues(grid, xPos, yPos)

    for val in neighbors:
        if val >= thisValue:
            return False
    
    return True

def getNeighborValues(grid, xPos, yPos):
    neighborValueList = []
    
    # for xOffset in range(-1, 1):
    #     checkX = xPos + xOffset
    #     if checkX >= 0 or checkX < len(grid):
    #         for yOffset in range(-1, 1):
    #             checkY = yPos + yOffset
    #             if checkY >= 0 and checkY < len(grid[xOffset]) and (xPos != checkX and checkY != yPos):
    #                 neighborValueList.append(grid[checkX][checkY])

    if xPos - 1 >= 0:
        neighborValueList.append(grid[xPos - 1][yPos])
        if yPos - 1 >= 0:
            neighborValueList.append(grid[xPos - 1][yPos - 1])
        if yPos + 1 < len(grid[xPos]):
            neighborValueList.append(grid[xPos - 1][yPos + 1])

    if yPos - 1 >= 0:
        neighborValueList.append(grid[xPos][yPos - 1])
    if yPos + 1 < len(grid[xPos]):
        neighborValueList.append(grid[xPos][yPos + 1])

    if xPos + 1 < len(grid):
        neighborValueList.append(grid[xPos + 1][yPos])
        if yPos - 1 >= 0:
            neighborValueList.append(grid[xPos + 1][yPos - 1])
        if yPos + 1 < len(grid[xPos]):
            neighborValueList.append(grid[xPos + 1][yPos + 1])

        

    return neighborValueList

def numCells(grid):
    # Write your code here
    totalDominant = 0
    for i in range(0, len(grid)):
        for j in range(0, len(grid[i])):
            if(isDominantCell(grid, i, j)):
                totalDominant += 1
    return totalDominant

if __name__ == '__main__':
    #fptr = open(os.environ['OUTPUT_PATH'], 'w')

    # grid_rows = int(input().strip())
    # grid_columns = int(input().strip())

    grid = []
    grid_rows = 4
    grid_columns = 3
    grid = [
        [9, 1, 1],
        [1, 1, 9],
        [9, 1, 1],
        [1, 1, 9]
    ]



    # for _ in range(grid_rows):
    #     grid.append(list(map(int, input().rstrip().split())))

    result = numCells(grid)
    print(result)
    #fptr.write(str(result) + '\n')

    #fptr.close()
