#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'biggerIsGreater' function below.
#
# The function is expected to return a STRING.
# The function accepts STRING w as parameter.
#
def biggerIsGreater(w):
    #Just iterate from the back, if the last two are swappable, swap, otherwise continue forth
    #If you reach an index < 0, return "no answer"
    swapIndex = -1
    for i in range(len(w)-1, 0, -1):
        if ord(w[i]) > ord(w[i-1]):
            swapIndex = i
            break
    if swapIndex == -1:
        return "no answer"
    print("Swap Index was: ", swapIndex)
    return "Got to end" #substring to swap - 2, swap, swap - 1, substring from swap to end

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    T = int(input().strip())

    for T_itr in range(T):
        w = input()

        result = biggerIsGreater(w)

        fptr.write(result + '\n')

    fptr.close()
