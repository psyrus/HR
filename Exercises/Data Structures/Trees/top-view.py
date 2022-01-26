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
def topView(root):
    out = trav(root, 0, 0)
    val = {}
    for i in out:
        setVal = { "height": i['y'], "value": i['v'] }
        if i['x'] not in val:
            val[i['x']] = setVal
        else:
            if setVal['height'] < val[i['x']]['height']:
                val[i['x']] = setVal
    
    for k in sorted(val.keys()):
        print(val[k]['value'], end=" ")

def trav(node, depth, xVal):
    leftContent = trav(node.left, depth + 1, xVal - 1) if node.left else []
    rightContent = trav(node.right, depth + 1, xVal + 1) if node.right else []
    return leftContent + [ {"y": depth, "x": xVal, "v": node.info} ] + rightContent


tree = BinarySearchTree()
# t = int(input())

# arr = list(map(int, input().split()))
t = 6
arr = [1, 2, 5, 3, 6, 4]

for i in range(t):
    tree.create(arr[i])

topView(tree.root)