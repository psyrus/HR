class Node:
    def __init__(self, info):
        self.info = info  
        self.left = None  
        self.right = None 
        self.level = None 

    def __str__(self):
        return str(self.info) 

def preOrder(root):
    if root == None:
        return
    print (root.info, end=" ")
    preOrder(root.left)
    preOrder(root.right)
    
class BinarySearchTree:
    def __init__(self): 
        self.root = None

#Node is defined as
#self.left (the left child of the node)
#self.right (the right child of the node)
#self.info (the value of the node)

    def insert(self, val):
        if not self.root:
            self.root = Node(val)
        else:
            # Walk the tree to find the right position
            spot_found = False
            node = self.root
            while(not spot_found):
                if val < node.info:
                    if not node.left:
                        node.left = Node(val)
                        spot_found = True
                    else:
                        node = node.left
                else:
                    if not node.right:
                        node.right = Node(val)
                        spot_found = True
                    else:
                        node = node.right

tree = BinarySearchTree()
t = int(input())

arr = list(map(int, input().split()))

for i in range(t):
    tree.insert(arr[i])

preOrder(tree.root)
