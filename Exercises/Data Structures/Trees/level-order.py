from os import sep


class Node:
    def __init__(self, info): 
        self.info = info  
        self.left = None  
        self.right = None 
        self.level = None 

    def __str__(self):
        return str(self.info) 

class BinarySearchTree:
    def __init__(self): 
        self.root = None

    def create(self, val):  
        if self.root == None:
            self.root = Node(val)
        else:
            current = self.root
         
            while True:
                if val < current.info:
                    if current.left:
                        current = current.left
                    else:
                        current.left = Node(val)
                        break
                elif val > current.info:
                    if current.right:
                        current = current.right
                    else:
                        current.right = Node(val)
                        break
                else:
                    break

"""
Node is defined as
self.left (the left child of the node)
self.right (the right child of the node)
self.info (the value of the node)
"""
def levelOrder(root):
    level_output_dict = getLevels(root, 1)
    for level in sorted(level_output_dict.keys()):
        print(" ".join(map(str, level_output_dict[level])), end=" ")

def getLevels(node, level):
    output = {}

    output[level] = [node.info]

    leftNodeDict = getLevels(node.left, level + 1) if node.left else {}
    rightNodeDict = getLevels(node.right, level + 1) if node.right else {}

    output.update(leftNodeDict)
    for k in rightNodeDict.keys():
        if k not in output:
            output[k] = []
        output[k] += rightNodeDict[k]

    return output

# 37 23 108 14 31 4 17 2 6 1 3 5 9 7 12 8 10 13 11 15 22 16 18 20 19 21 25 34 24 27 26 29 28 30 32 35 33 36 59 111 55 86 50 56 46 54 40 48 38 41 39 42 44 43 45 47 49 52 51 53 57 58 64 94 62 65 60 63 61 79 78 81 66 68 67 77 74 69 75 72 70 73 71 76 80 82 83 84 85 90 105 88 91 87 89 93 92 97 107 95 104 96 98 103 100 99 101 102 106 109 115 110 114 116 112 113
# 37 23 108 14 31 59 111 4 17 25 34 55 86 109 115 2 6 15 22 24 27 32 35 50 56 64 94 110 114 116 1 3 5 9 16 18 26 29 33 36 46 54 57 62 65 90 105 112 7 12 20 28 30 40 48 52 58 60 63 79 88 91 97 107 113 8 10 13 19 21 38 41 47 49 51 53 61 78 81 87 89 93 95 104 106 11 39 42 66 80 82 92 96 98 44 68 83 103 43 45 67 77 84 100 74 85 99 101 69 75 102 72 76 70 73 71
tree = BinarySearchTree()
# t = int(input())

# arr = list(map(int, input().split()))

t = 116
arr = [37, 23, 108, 14, 31, 4, 17, 2, 6, 1, 3, 5, 9, 7, 12, 8, 10, 13, 11, 15, 22, 16, 18, 20, 19, 21, 25, 34, 24, 27, 26, 29, 28, 30, 32, 35, 33, 36, 59, 111, 55, 86, 50, 56, 46, 54, 40, 48, 38, 41, 39, 42, 44, 43, 45, 47, 49, 52, 51, 53, 57, 58, 64, 94, 62, 65, 60, 63, 61, 79, 78, 81, 66, 68, 67, 77, 74, 69, 75, 72, 70, 73, 71, 76, 80, 82, 83, 84, 85, 90, 105, 88, 91, 87, 89, 93, 92, 97, 107, 95, 104, 96, 98, 103, 100, 99, 101, 102, 106, 109, 115, 110, 114, 116, 112, 113]
t = 6
arr = [1, 2, 5, 3, 6, 4]

for i in range(t):
    tree.create(arr[i])

levelOrder(tree.root)