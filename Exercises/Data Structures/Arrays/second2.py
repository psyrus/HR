#!/bin/python3

import math
import os
import random
import re
import sys



#
# Complete the 'findSubstring' function below.
#
# The function is expected to return a STRING.
# The function accepts following parameters:
#  1. STRING s
#  2. INTEGER k
#
VOWELS = ['a', 'e', 'i', 'o', 'u']

def findSubstring(s, k):
   # loop through each char and find the distance between current vowel and last found one
   # loop through distances array, add value from next jump until > k

    jumps = {}
    lastVowelPos = None
    for i in range(0, len(s)):
        if s[i] in VOWELS:
            jumps[i] = 0 if lastVowelPos == None else i - lastVowelPos
    
    keysList = sorted(jumps.keys())
    highestContent = 0
    startIndex = None
    for i in range(len(keysList)):
        j = 1
        totalJumps = 0
        while totalJumps <= k:
            totalJumps = jumps[i+j]
            j += 1
        if j > highestContent:
            startIndex = i
            highestContent = j
    
    return "Not found!" if startIndex == None else s[startIndex:startIndex+k]


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    s = input()

    k = int(input().strip())

    result = findSubstring(s, k)

    fptr.write(result + '\n')

    fptr.close()
