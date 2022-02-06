# https://www.hackerrank.com/challenges/maximum-element/problemgit

#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'getMax' function below.
#
# The function is expected to return an INTEGER_ARRAY.
# The function accepts STRING_ARRAY operations as parameter.
#


class MyStack:
    def __init__(self):
        self.content = []
        self.max = 0

    def push(self, value):
        self.content.append(value)
        if value > self.max:
            self.max = value

    def removeTop(self):
        val = self.content.pop()
        if val == self.max:
            self.max = self.getMax()

    def getMax(self):
        return max(self.content) if self.content else 0

    def perform_operation(self, operation_string):
        ops = list(map(lambda n: int(n), operation_string.split(" ")))
        if ops[0] == 1:
            self.push(ops[1])
        if ops[0] == 2:
            self.removeTop()
        if ops[0] == 3:
            return self.max


def getMax(operations):
    results = []
    stack = MyStack()
    for op in operations:
        thisResult = stack.perform_operation(op)
        if thisResult:
            results.append(thisResult)
    return results


if __name__ == '__main__':

    operations = [
        "1 97",
        "2",
        "1 20",
        "2",
        "1 26",
        "1 20",
        "2",
        "3",
        "1 91",
        "3"
    ]

    res = getMax(operations)
    print(res)
    exit()
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input().strip())

    ops = []

    for _ in range(n):
        ops_item = input()
        ops.append(ops_item)

    res = getMax(ops)

    fptr.write('\n'.join(map(str, res)))
    fptr.write('\n')

    fptr.close()
