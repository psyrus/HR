#!/bin/python3

import math
import os
import random
import re
import sys



#
# Complete the 'mostActive' function below.
#
# The function is expected to return a STRING_ARRAY.
# The function accepts STRING_ARRAY customers as parameter.
#

def mostActive(customers):
    # Write your code here
    trades_count = {}
    margin_value = math.floor(len(customers) * 0.05)
    for c in customers:
        if not c in trades_count.keys():
            trades_count[c] = 0
        trades_count[c] += 1

    big_spenders = [i for i in trades_count.keys() if trades_count[i] >= margin_value]
    return big_spenders.sort()
if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    customers_count = int(input().strip())

    customers = []

    for _ in range(customers_count):
        customers_item = input()
        customers.append(customers_item)

    result = mostActive(customers)

    fptr.write('\n'.join(result))
    fptr.write('\n')

    fptr.close()
