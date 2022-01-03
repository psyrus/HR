#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'dynamicArray' function below.
#
# The function is expected to return an INTEGER_ARRAY.
# The function accepts following parameters:
#  1. INTEGER n
#  2. 2D_INTEGER_ARRAY queries
#

def getModVal(xVal, lastAnswer, seqCount):
  return (xVal ^ lastAnswer) % seqCount

def dynamicArray(n, queries):
  lastAnswer = 0
  outputArray = []
  sequences = [[] for i in range(0, n)]
  print("There are %s sequences" % len(sequences))
  for q in queries:
    query_type = q[0]
    mod_val = getModVal(q[1], lastAnswer, n)
    # handle query type 1
    if query_type == 1:
      print("Query type 1!")
      sequences[mod_val].append(q[2])
    # handle query type 2
    else:
      print("Query type 2!")
      lastAnswer = sequences[mod_val][q[2] % len(sequences[mod_val])]
      print("sequences[%s][%s mod %s]" % (mod_val, q[2], len(sequences[mod_val])))
      print("New value of newAnswer is: %s" % lastAnswer)
      outputArray.append(lastAnswer)
  print(sequences)
  return outputArray


if __name__ == '__main__':
  with open('data.txt', 'r') as file:
    data = file.readlines()
    first_multiple_input = data[0].rstrip().split(' ')

    # fptr = open(os.environ['OUTPUT_PATH'], 'w')

    # first_multiple_input = input().rstrip().split()

    n = int(first_multiple_input[0])

    q = int(first_multiple_input[1])

    queries = []

    for i in range(0, q):
        queries.append(list(map(int, data[i+1].rstrip().split())))

    result = dynamicArray(n, queries)

    print('\n'.join(map(str, result)))
    # fptr.write('\n'.join(map(str, result)))
    # fptr.write('\n')
    input()
    # fptr.close()
    