                          ######################SCAPEGOAT TREE#######################
*******INTRODUCTION:******* 
scapegoat tree is an implementation of self balancing tree . This structure is based on a common wisdom that when something goes wrong the first thing people tend to do is to blame someone known as scapegoat. Here we blame a node that is responsible for unbalance of the tree and then the scapegoat node fix that problem by rebuilding it self.

**********THEOREM :**********
An a weight balanced node is therefore:

                  D < log base(1/a) * n
where,
D = depth of the tree.
a = any value between 0.5-1.
n = no of nodes.
where a is "alpha"

**********FUNCTIONS:*********
=)INSERT:
To insert value X in an scapegoat tree .Create a node u and insert X using BST iterative insert algorithem.if Depth is greater than log base(1/a) *n then we need to make tree balanced an for that we  need to find scapegoat. to find scapegoat walk up from u until we reach a node W with size(w)>a *size (w.parent).this node is scapegoat
Now Rebuild the scapegoat tree rooted at w.parent.
=)DELETE:
To remove X from a scapegoat tree run the standard deletion algorithm for scapegoat trees. than decrement n. if n < q/2(where q is the estimate of n) then rebuild the tree and  set q = n;
=)REBUILD:
An this , we simply convert the subtree to the most possible balanced BST. we first store inorder traversal of BST in an array. then we build a new BST from array by recursively dividing it into two halves.
 
***********WHY WE USE IT:********
Because, it is first BST to achieve its complexity without storing extra information at every node like AVL.This saves large amount of space.

*********HOW TO USE IT:**********
Its a menudriven program we have 6 option in this. if we press 1 than we have insert option for this we have to tell the number of element first. than the values of them. In the 2nd option we have the delete function we should put the value we want to delete in the scapegoat tree.
than the 3rd option is to search any element of the tree than the 4th option is pre-order traversal , the 5th option is post-order traversal and the last 6th option is in-order traversal.Avoid using spaces. You can insert integer and float numbers.Avoid inserting character values.

***********PRESENTED BY:**********

      FALAK NAZ    17B-020-SE(A)

      HASSAN MOIN    17B-030-SE(A)




 



