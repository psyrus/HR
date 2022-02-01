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


# Enter your code here. Read input from STDIN. Print output to STDOUT
'''
class Node:
      def __init__(self,info): 
          self.info = info  
          self.left = None  
          self.right = None 
           

       // this is a node of the tree , which contains info as data, left , right
'''


def lca(root, v1, v2):
    # check if v1 or v2 are to the left
    ## If both left -> new LCA candidate is node.left
    # check if v1 or v2 are to the right
    ## If both right -> new LCA candidate is node.right

    # If one is smaller than right, and one is larger than right, this is our lowest common ancestor (this is where they diverge)
    node = root
    lca_found = False
    while not lca_found:
        both_left = v1 < node.info and v2 < node.info
        both_right = v1 > node.info and v2 > node.info

        if both_left:
            node = node.left
            continue
        elif both_right:
            node = node.right
            continue
        else:
            lca_found = True

    return node
       



tree = BinarySearchTree()
t = int(input())

arr = list(map(int, input().split()))

for i in range(t):
    tree.create(arr[i])

v = list(map(int, input().split()))

ans = lca(tree.root, v[0], v[1])
print(ans.info)
