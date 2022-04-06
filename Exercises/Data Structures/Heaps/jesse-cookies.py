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
class MinHeap:
    def __init__(self):
        self.content = []

    def get_level_contents(self, level):
        start = int(math.pow(2, level) - 1)
        end = int(math.pow(2, level + 1) - 1)

        return self.content[start:end]

    def heapify_node(self, index):
        # Left child of i-th node is at (2*i + 1)th index.
        left_child_index = 2 * index + 1
        left_valid = left_child_index < len(self.content)
        # Right child of i-th node is at (2*i + 2)th index.
        right_child_index = 2 * index + 2
        right_valid = right_child_index < len(self.content)
        # Parent of i-th node is at (i-1)/2 index.
        parent = (index - 1) / 2

        left_greater = (
            left_valid and (
                not right_valid or self.content[left_child_index] < self.content[right_child_index]
            ) and (
                self.content[left_child_index] < self.content[index]
            )
        )

        right_greater = (
            right_valid and (
                not left_valid or self.content[right_child_index] < self.content[left_child_index]
            ) and (
                self.content[right_child_index] < self.content[index]
            )
        )
        tmp = self.content[index]
        if left_greater:
            # print(f"Swapping index {index} ({self.content[index]}) and {left_child_index} ({self.content[left_child_index]})")
            self.content[index] = self.content[left_child_index]
            self.content[left_child_index] = tmp
            self.heapify_node(left_child_index)
        elif right_greater:
            # print(f"Swapping index {index} ({self.content[index]}) and {right_child_index} ({self.content[right_child_index]})")
            self.content[index] = self.content[right_child_index]
            self.content[right_child_index] = tmp
            self.heapify_node(right_child_index)

    def heapify(self):
        # https://www.geeksforgeeks.org/building-heap-from-array/?ref=leftbar-rightbar
        n = len(self.content)
        start_index = int((n/2) - 1)
        for i in range(start_index, -1, -1):
            self.heapify_node(i)

    def insert_node(self, node_data):
        self.content.insert(0, node_data)
        self.heapify_node(0)

    def delete_node(self, node_data):
        # Find the index of the item to be deleted
        target_index = self.content.index(node_data)
        # Swap the last item in the array with the index in question, and remove the last item
        if target_index == len(self.content) - 1:
            self.content.pop(-1)
            return

        tmp = self.content[target_index]
        self.content[target_index] = self.content[-1]
        self.content[-1] = tmp
        self.content.pop(-1)

        # Then heapify from the original index
        self.heapify_node(target_index)

def all_compliant(sorted_array_to_check, min_sweetness_value):
    return sorted_array_to_check[0] >= min_sweetness_value

def cookies(k, original_sweetness):
    myHeap = MinHeap()
    steps = 0
    for item in original_sweetness:
        if item >= k:
            continue
        myHeap.insert_node(item)

    while(len(myHeap.content) > 0 or steps < len(original_sweetness)):
        steps += 1
        if len(myHeap.content) == 1:
            break
        first = myHeap.get_level_contents(0)[0]
        second = myHeap.get_level_contents(1)[0]
        myHeap.delete_node(first)
        myHeap.delete_node(second)
        new = first + (2 * second)
        if new < k:
            myHeap.insert_node(new)

    return steps
    original_sweetness.sort()
    steps = 0
    lower_val_index = 0
    if original_sweetness[-1] * original_sweetness[-1] < k:
        return -1
    # new_cookie = least_sweet + 2 * next_least_sweet
    while not original_sweetness[lower_val_index] >= k and lower_val_index < len(original_sweetness) - 1:

        val1 = original_sweetness[lower_val_index]
        val2 = original_sweetness[lower_val_index + 1]

        original_sweetness[lower_val_index] = -1

        new_val = val1 + (2 * val2)
        original_sweetness[lower_val_index + 1] = new_val
        original_sweetness.sort()
        lower_val_index += 1
        steps += 1

    return steps

if __name__ == '__main__':

    k = 7
    # list = [1, 2, 3, 9, 10, 12]
    file_path = r"C:\Users\Trevor\Downloads\jesse-input18.txt"
    file = open(file_path, "r").readlines()
    k = int (file[0].replace('\n', '').split(' ')[1])
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
