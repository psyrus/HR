#!/bin/python3

import math
import os
import random
import re
import sys



#
# Complete the 'reverse_words_order_and_swap_cases' function below.
#
# The function is expected to return a STRING.
# The function accepts STRING sentence as parameter.
#

def reverse_words_order_and_swap_cases(sentence):
    # Need to determine where the words start and end
    # For each letter in a word, need to swap the case
    outputWords = [""]
    outputWordIndex = 0
    for c in sentence:
        if c.isspace():
            outputWordIndex += 1
            outputWords.append("")        
        elif c.islower():
            outputWords[outputWordIndex] += c.upper()
        elif c.isupper():
            outputWords[outputWordIndex] += c.lower()

    outputWords.reverse()
    return ' '.join(outputWords)

if __name__ == '__main__':
    #fptr = open(os.environ['OUTPUT_PATH'], 'w')

    sentence = input()

    result = reverse_words_order_and_swap_cases(sentence)

    print(result)
    #fptr.write(result + '\n')

    #fptr.close()
