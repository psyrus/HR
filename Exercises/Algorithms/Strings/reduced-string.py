#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the superReducedString function below.
def superReducedString(s):
    changesMade = False
    outputString = ""
    i = 0
    while i < len(s):
        print(i)
        if i == len(s) - 1 or s[i] != s[i+1]:
            outputString += s[i]
        elif s[i] == s[i+1]:
            # skip this one and the next as well
            i += 1
            changesMade = True
        i += 1
            
    if changesMade:
        return superReducedString(outputString)
    else:
        return outputString or "Empty String"

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    s = input()

    result = superReducedString(s)

    fptr.write(result + '\n')

    fptr.close()
0
