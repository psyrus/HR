#!/bin/python3

import math

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

class MaxHeap:
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

        tmp = self.content[index]
        if left_valid and self.content[left_child_index] > self.content[right_child_index] and self.content[left_child_index] > self.content[index]:
            #print(f"Swapping index {index} ({self.content[index]}) and {left_child_index} ({self.content[left_child_index]})")
            self.content[index] = self.content[left_child_index]
            self.content[left_child_index] = tmp
            self.heapify_node(left_child_index)
        if right_valid and self.content[right_child_index] > self.content[left_child_index] and self.content[right_child_index] > self.content[index]:
            #print(f"Swapping index {index} ({self.content[index]}) and {right_child_index} ({self.content[right_child_index]})")
            self.content[index] = self.content[right_child_index]
            self.content[right_child_index] = tmp
            self.heapify_node(right_child_index)

    def heapify(self):
        # https://www.geeksforgeeks.org/building-heap-from-array/?ref=leftbar-rightbar
        n = len(self.content)
        start_index = int((n/2) - 1) 
        nodes_before_start = self.content[0:start_index + 1]
        for i in range(start_index, -1, -1):
            self.heapify_node(i)

    def insert_node(self, node_data):
        self.content.append(node_data)
        self.heapify_node(len(self.content) - 1)
    
    def delete_node(self, node_data):
        # Find the index of the item to be deleted
        target_index = self.content.index(node_data)
        # Swap the last item in the array with the index in question, and remove the last item
        tmp = self.content[target_index]
        self.content[target_index] = self.content[-1]
        self.content[-1] = tmp

        self.content.pop(-1)
        # Then heapify from the original index
        self.heapify_node(target_index)

if __name__ == '__main__':
    n = int(input().strip())

    my_heap = MinHeap()

    for i in range(0, n):
        line_input = input().strip()
        command_breakdown = [int (i) for i in line_input.split(" ")]
        if command_breakdown[0] == 1:
            my_heap.insert_node(command_breakdown[1])
        elif command_breakdown[0] == 2:
            my_heap.delete_node(command_breakdown[1])
        elif command_breakdown[0] == 3:
            print(my_heap.content[0])
        else:
            print("Didn't hit any of those...")
