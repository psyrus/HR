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
def findVowelsInSubstring(s, k, startPos):
    print("evaluating string: %s" % s[startPos:startPos+k])
    count = 0
    for i in range(startPos, startPos + k):
        if i > len(s) - 1:
            break
        if s[i] in VOWELS:
            count += 1
    return count

def findSubstring(s, k):
    vowel_counts = {}
    for i in range(0, len(s)):
        char = s[i]
        if char in VOWELS:
            vowel_counts[i] = findVowelsInSubstring(s, k, i)

    max_val = -1
    return_index = None
    print(vowel_counts)
    for index,vowelCount in vowel_counts.items():
        if vowelCount > max_val:
            max_val = vowelCount
            return_index = index

    return s[return_index:return_index+k]

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    s = input()

    k = int(input().strip())

    result = findSubstring(s, k)

    fptr.write(result + '\n')

    fptr.close()
