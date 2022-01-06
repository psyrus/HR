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
# https://www.nayuki.io/page/next-lexicographical-permutation-algorithm


def biggerIsGreater(w):
    # Start from the right side of the string, checking each char to see if there is something LOWER than it in value that can be swapped out to make the overall total rise (the least)
    indexSwapCandidates = []
    wordArray = list(w)
    largestSwapTargetIndex = 0
    for i, e in reversed(list(enumerate(w))):
        charVal = ord(e)

        for j in range(i, -1, -1):
            # Once something can be switched, swap them
            if ord(w[j]) < charVal:
                # print(f"For string {w}, character {e} at position {i} could be swapped with character {w[j]} at position {j} because {ord(w[j])} is < {charVal}")
                indexSwapCandidates.append(
                    {
                        "sourceIndex": i,
                        "sourceValue": w[i],
                        "sourceValueInt": ord(w[i]),
                        "targetIndex": j,
                        "targetValue": w[j],
                        "targetValueInt": ord(w[j]),
                    }
                )
                if j > largestSwapTargetIndex:
                    largestSwapTargetIndex = j
        # Need to break early if we have exceeded the meaningful number of items to check
        if i < largestSwapTargetIndex:
            # print(f"Reached iteration (i) of {i} but the possibleSwapIndex includes {largestSwapTargetIndex} so exiting loop early")
            break
    if not indexSwapCandidates:
        return "no answer"

    # Do the swap with the best candidate
    newlist = sorted(indexSwapCandidates,
                     key=lambda d: d["targetIndex"], reverse=True)
    swapItem = newlist[0]
    temp = wordArray[swapItem["sourceIndex"]]
    wordArray[swapItem["sourceIndex"]] = wordArray[swapItem["targetIndex"]]
    wordArray[swapItem["targetIndex"]] = temp

    # Then sort the items AFTER the left most swapped index fromm small to large
    sortedSubArray = wordArray[swapItem["targetIndex"] + 1:]
    sortedSubArray.sort()
    return "".join(wordArray[: swapItem["targetIndex"] + 1] + sortedSubArray)


if __name__ == "__main__":
    # fptr = open(os.environ['OUTPUT_PATH'], 'w')

    # T = int(input().strip())

    # for T_itr in range(T):
    #     w = input()

    #     result = biggerIsGreater(w)

    #     fptr.write(result + '\n')

    # fptr.close().

    cases = [
        "bb"
    ]

    expectedOutput = [
        "no answer"
    ]

    for i, c in enumerate(cases):
        result = biggerIsGreater(c)
        if expectedOutput[i] != result:
            print(
                f"Case ({i}): \n\t[{c}]\n\t[{expectedOutput[i]}] ✅\n\t[{result}] ✖")
