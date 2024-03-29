#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'anagram' function below.
#
# The function is expected to return an INTEGER.
# The function accepts STRING s as parameter.
#

def anagram(s):
    if len(s) % 2 != 0:
        return -1
    
    midpoint = len(s)//2
    firstSet = list(s[midpoint:])
    secondSet = list(s[:midpoint])

    firstSetCopy = firstSet.copy()
    secondSetCopy = secondSet.copy()
    for c in secondSet:
        if c not in firstSetCopy:
            secondSetCopy.remove(c)
        else:
            firstSetCopy.remove(c)
    
    return len(firstSet) - len(secondSetCopy)

if __name__ == '__main__':
    # fptr = open(os.environ['OUTPUT_PATH'], 'w')

    # q = int(input().strip())

    # for q_itr in range(q):
    #     s = input()

    #     result = anagram(s)

    #     fptr.write(str(result) + '\n')

    # fptr.close()
    
    print(anagram("fdhlvosfpafhalll"))
