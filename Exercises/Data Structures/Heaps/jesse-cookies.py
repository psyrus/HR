#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'cookies' function below.
#
# The function is expected to return an INTEGER.
# The function accepts following parameters:
#  1. INTEGER k
#  2. INTEGER_ARRAY A
#

def all_compliant(sorted_array_to_check, min_sweetness_value):
    return sorted_array_to_check[0] >= min_sweetness_value

def cookies(k, original_sweetness):
    requirement_met = False
    steps = 0
    original_sweetness.sort()
    if original_sweetness[-1] * original_sweetness[-1] < k:
        return -1
    # new_cookie = least_sweet + 2 * next_least_sweet
    while True:
        if all_compliant(original_sweetness, k):
            break
        elif len(original_sweetness) == 1:
            print(f"Steps so far before failing: {steps}...")
            steps = -1
            break
        
        val1 = original_sweetness.pop(0)
        val2 = original_sweetness.pop(0)
        new_val = val1 + (2 * val2)
        original_sweetness.append(new_val)
        steps += 1

    return steps

if __name__ == '__main__':

    k = 7
    # list = [1, 2, 3, 9, 10, 12]
    file_path = r"C:\Users\Trevor\Downloads\input11.txt"
    file = open(file_path, "r").readlines()
    k = int (file[0].split(' ')[1])
    list = [int(i) for i in file[1].split(' ')]
    result = cookies(k, list)
    print(result)
    exit()
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    first_multiple_input = input().rstrip().split()

    n = int(first_multiple_input[0])

    k = int(first_multiple_input[1])

    A = list(map(int, input().rstrip().split()))

    result = cookies(k, A)

    fptr.write(str(result) + '\n')

    fptr.close()
