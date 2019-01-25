using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDS
{
    /* C# program To implement Scapegoat tree */
    class Program
    {
        static void Main(string[] args)
        {
           
            ScapeGoat s = new ScapeGoat();
            int n;
            char c;
           
            /* A menu driven program you can build a Scapegoat tree through it.
             * All the function in scapegoat class is called here. */
            do
            {
                Console.WriteLine("FALAK NAZ 17B-020-SE");
                Console.WriteLine("HASSAN MOIN 17B-030-SE");
                Console.WriteLine();
                Console.WriteLine("\t\t\tSCAPEGOAT TREE OPERATIONS\t\t\t");
                Console.WriteLine();
                Console.WriteLine("Press 1 for Insering values in Scapegoat Tree");
                Console.WriteLine("Press 2 for Deleting values in Scapegoat Tree");
                Console.WriteLine("Press 3 for Checking that if value exist in Scapegoat Tree");
                Console.WriteLine("Press 4 for Preorder traversal of Scapegoat Tree");
                Console.WriteLine("Press 5 for Postorder traversal of Scapegoat Tree");
                Console.WriteLine("Press 6 for Inorder traversal of Scapegoat Tree");
                n = Convert.ToInt16(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        {
                            int f;
                            double x;
                            Console.WriteLine("How many elements you want to insert?");
                            f = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter elements now");
                            for (int i = 0; i < f; i++)
                            {
                                x = Convert.ToDouble(Console.ReadLine());
                                s.add(x);
                            }
                            break;
                        }
                    case 2:
                        {
                            double z;
                            Console.WriteLine("Enter the element you want to delete");
                            z = Convert.ToDouble(Console.ReadLine());
                            s.Delete(z);
                            break;
                        }
                    case 3:
                        {
                            double y;
                            Console.WriteLine("Enter the element you want to check if exist");
                            y = Convert.ToDouble(Console.ReadLine());
                            s.Search(y);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Preorder Traversal");
                            s.preorder();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Postorder Traversal");
                            s.postorder();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Inorder Traversal");
                            s.inorder();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter valid choice");
                            break;
                        }



                }
                Console.WriteLine("Do you want to continue y or n");
                
                c = Convert.ToChar(Console.ReadLine());
                Console.Clear();

            }
            while (c == 'y' || c=='Y');
           

        }
    }
    /*Provides nodes for Scapegoat tree*/
    class Snode
    {
        public Snode right, left;
        public Snode parent;
        public double value;

        /*Constructor to initialize entered value by user*/
        public Snode(double e)
        {
            value=e;
        }
    }

    /*Class to build Scapegoat tree*/
    class ScapeGoat
    {
        /* Declaring root of the tree*/
        private Snode root;
        /* 'n' is counter variable contains total number of nodes in tree. 'q' is upperbound of 'n'*/
        private int q, n;

        /*Constructor to intialize root 'q' and 'n'*/
        public ScapeGoat()
        {
            root = null;
            n = 0;
            q = 0;
        }

        /*Function to count the size of current node recursively*/
        private int size(Snode u)
        {
            if (u == null)
            {
                return 0;
            }
            else
            {
                int l = 1;
                l = l + size(u.left);
                l = l + size(u.right);
                return l;
            }
        }

        /* Function to give the value of "logbase3/2(n)" */
        private double logBase32(int q)
        {
            double x = Math.Log(q, 3.0 / 2.0);
            return x;
        }

        /*Function to rebuild a tree rooted at Scapegoat node*/
        private void rebuild(Snode u)
        {
            int ns = size(u);
            Snode p = u.parent;
            Snode[] a = new Snode[ns];
            packintoarray(u, a, 0);
            if(p==null)
            {
                root = BuildBalanced(a, 0, ns);
                root.parent = null;
            }
            else if(p.right==u)
            {
                p.right = BuildBalanced(a, 0, ns);
                p.right.parent = p;
            }
            else
            {
                p.left = BuildBalanced(a, 0, ns);
                p.left.parent = p;
            }

        }

        /*Convert bst to array*/
        private int packintoarray(Snode u,Snode[] a,int i)
        {
            if(u==null)
            {
                return i;
            }
            i = packintoarray(u.left, a, i);
            a[i++] = u;
            return packintoarray(u.right, a, i);
        }

        /* Function to build balanced tree from array*/
        private Snode BuildBalanced(Snode [] a,int i,int ns)
        {
            if (ns == 0)
                return null;
            int m = ns / 2;
            a[i + m].left = BuildBalanced(a, i, m);
            if (a[i + m].left != null)
                a[i + m].left.parent = a[i + m];
            a[i + m].right = BuildBalanced(a, i + m + 1, ns - m - 1);
            if (a[i + m].right != null)
                a[i + m].right.parent = a[i + m];
            return a[i + m];
        }
        /* Function to add values.
           This function also provides the depth of the tree.*/
        private int AddDepth(Snode u)
        {
            Snode w = root;
            if(w==null)
            {
                root = u;
                n++;
                q++;
                return 0;
            }
            bool done = false;
            int d = 0;
            do
            {
                if (u.value < w.value)
                {
                    if (w.left == null)
                    {
                        w.left = u;
                        u.parent = w;
                        done = true;
                    }
                    else
                    {
                        w = w.left;
                    }
                }
                else if (u.value > w.value)
                {
                    if (w.right == null)
                    {
                        w.right = u;
                        u.parent = w;
                        done = true;
                    }
                    else
                    {
                        w = w.right;
                    }
                }
                else
                    return -1;
                d++;
            }
            while (!done);
            n++;
            q++;
            return d;
        }

        /*This function recieves value from user and add it into the tree then 
         compare the depth of the tree with logbase3/2(n) if depth exceeded the
         log value then scapegoat node is found and rebuild the tree rooted at 
         scapegoat node*/
        public void add(double x)
        {
            Snode u = new Snode(x);
            int d = AddDepth(u);
            Console.WriteLine("Inserted {0}",x);
            Console.WriteLine("n={0}\tq= {1}\td={2}",n,q,d );
            double z = logBase32(q);
            Console.WriteLine("LogBase 2/3(q) ={0}",z);
            Console.WriteLine();
            Console.WriteLine("____________");

            if(d>logBase32(q))
            {
                Console.WriteLine("Depth exceeded");
                Console.WriteLine("Finding ScapeGoat Node");
                Console.WriteLine("Rebuliding tree rooted at ScapeGoat Node");
                Snode w = u.parent;
                while (3 * size(w) <= 2 * size(w.parent))
                    w = w.parent;
                rebuild(w.parent);
            }

        }
        /* Find minimum node from the tree*/
        public Snode Minimum(Snode node)
        {
            if (node == null)
                return null;
            if (node.left == null)
                return node;
            else
                return Minimum(node.left);
        }
        /*Find maximum node from the tree*/
        public Snode Maximum(Snode node)
        {
            if (node == null)
                return null;
            if (node.right == null)
                return node;
            else
                return Maximum(node.right);
        }
        /* Provides Successor*/
        public Snode Successor(Snode node)
        {
            if (node == null)
                return null;
            return Minimum(node.right);
        }
        /* Provides Predecessor*/
        public Snode Predecessor(Snode node)
        {
            if (node == null)
                return null;
            return Maximum(node.left);
        }

        /*Uses BST rule to delete any node from the Scapegoat tree*/
        private Snode Delete(Snode node,double e)
        {
            if (node == null)
                return null;
            if(node.value==e)
            {
                if (node.left == null && node.right == null)
                    return null;
                if (node.left != null && node.right == null)
                    return node.left;
                if (node.right != null && node.left == null)
                    return node.right;
                if(node.right!=null)
                {
                    Snode succ = Successor(node);
                    node.value = succ.value;
                    node.right = Delete(node.right, succ.value);
                }
                else
                {
                    Snode pred = Predecessor(node);
                    node.value = pred.value;
                    node.left = Delete(node.left, pred.value);
                }
                return node;
            }
            if (e < node.value)
                node.left = Delete(node.left, e);
            else
                node.right = Delete(node.right, e);

            return node;
        }
        /*This function call the delete function and then check if
         tree is balanced or not. If tree is not balanced then it
         rebuild the whole tree from root*/
        public void Delete(double e)
        {
            root = Delete(root, e);
            if(root!=null)
            {
                n--;
                Console.WriteLine("Value of n after deletion :: " +n);
                if(2*n < q)
                {
                    rebuild(root);
                    q = n;
                }
            }
        }

        /*This function search the element int the tree*/

        public void Search(double e)
        {
            double s = Search(root, e);
            if(s==e)
                Console.WriteLine("Tree  contains the searched element");
            else
                Console.WriteLine("Tree doesnot contains the searched element");
        }
        private double Search(Snode node,double e)
        {
            if (node == null)
                return -1;
            if (node.value == e)
                return node.value;
            if (e < node.value)
                return Search(node.left, e);
            else
                return Search(node.right, e);
        }
        /*Function to print pre order traversal of Scapegoat*/
        public void preorder()
        {
            preorder(root);
        }
        private void preorder(Snode node)
        {
            if(node!=null)
            {
                Console.WriteLine(node.value + " ");
                preorder(node.left);
                preorder(node.right);
            }
           
        }
        /*Function to print post order traversal*/
        public void postorder()
        {
            postorder(root);
        }
        private void postorder(Snode node)
        {
            if(node!=null)
            {
                postorder(node.left);
                postorder(node.right);
                Console.WriteLine(node.value + " ");
            }
            
        }
        /*Function to print inorder traversal*/
        public void inorder()
        {
            inorder(root);
        }
        private void inorder(Snode node)
        {
            if(node!=null)
            {
                inorder(node.left);
                Console.WriteLine(node.value +" ");
                inorder(node.right);
            }
        }

        
    }
}
