#!/bin/python3
# https://www.hackerrank.com/challenges/minimum-swaps-2/problem

import math
import os
import random
import re
import sys

# Complete the minimumSwaps function below.
def minimumSwaps(arr):
    sorted_arr = sorted(arr)
    numSwaps = 0
    isSorted = False
    while not isSorted:
        isSorted = True
        for idx, val in enumerate(arr):
            if val != idx + 1:
                temp = arr[val - 1]
                arr[val - 1] = val
                arr[idx] = temp
                numSwaps += 1
                isSorted = False
    return numSwaps

if __name__ == '__main__':
    # fptr = open(os.environ['OUTPUT_PATH'], 'w')

    # n = int(input())

    # arr = list(map(int, input().rstrip().split()))

    # res = minimumSwaps(arr)

    # fptr.write(str(res) + '\n')

    # fptr.close()
    input = [2, 31, 1, 38, 29, 5, 44, 6, 12, 18, 39, 9, 48, 49, 13, 11, 7, 27, 14, 33, 50, 21, 46, 23, 15, 26, 8, 47, 40, 3, 32, 22, 34, 42, 16, 41, 24, 10, 4, 28, 36, 30, 37, 35, 20, 17, 45, 43, 25, 19]
    input = [8, 45, 35, 84, 79, 12, 74, 92, 81, 82, 61, 32, 36, 1, 65, 44, 89, 40, 28, 20, 97, 90, 22, 87, 48, 26, 56, 18, 49, 71, 23, 34, 59, 54, 14, 16, 19, 76, 83, 95, 31, 30, 69, 7, 9, 60, 66, 25, 52, 5, 37, 27, 63, 80, 24, 42, 3, 50, 6, 11, 64, 10, 96, 47, 38, 57, 2, 88, 100, 4, 78, 85, 21, 29, 75, 94, 43, 77, 33, 86, 98, 68, 73, 72, 13, 91, 70, 41, 17, 15, 67, 93, 62, 39, 53, 51, 55, 58, 99, 46]
    # input = [7, 1, 3, 2, 4, 5, 6]
    # input = [4, 3, 1, 2]
    print(minimumSwaps(input))

# 7, 1, 3, 2, 4, 5, 6
# 1, 2, 3, 4, 5, 6, 7
# .  .  -  .  .  .  .

# 4 3 1 2
# 1 2 3 4
# . . . . 
# > 3

# 3 4 1 2
# 1 2 3 4
# . . . . 
# > 2

# Anywhere that the value at arr[currentVal - 1]

# 1 3 5 2 4 6 7
# 1 2 3 4 5 6 7
# - . . . . - -

# [2, 31, 1, 38, 29, 5, 44, 6, 12, 18, 39, 9, 48, 49, 13, 11, 7, 27, 14, 33, 50, 21, 46, 23, 15, 26, 8, 47, 40, 3, 32, 22, 34, 42, 16, 41, 24, 10, 4, 28, 36, 30, 37, 35, 20, 17, 45, 43, 25, 19]
# [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50]

# 7 6 3 2 4 5 1
# 1 2 3 4 5 6 7
# . . - . . . . > 6 - 1 = 5 BUT we have 1&7 as a lucky swap
# swap 1, 7 [1 6 3 2 4 5 7]
# swap 6, 2 [1 2 3 6 4 5 7]
# swap 6, 4 [1 2 3 4 6 5 7]
# swap 6, 5 [1 2 3 4 5 6 7]
