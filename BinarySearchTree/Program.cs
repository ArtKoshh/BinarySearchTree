using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(30);
            Node n1 = new Node(15);
            Node n2 = new Node(45);
            Node n3 = new Node(6);
            Node n4 = new Node(41);
            Node n5 = new Node(54);

            root.left = n1;
            root.right = n2;
            n1.right = n3;
            n2.left = n4;
            n2.right = n5;

            Node nodeToFind = BinarySearchTree.Search(root, 41);
            Console.WriteLine(nodeToFind.value);

            Node newRoot = BinarySearchTree.Insert(root, 85);
            Console.WriteLine(newRoot.right.right.right.value);


            Console.WriteLine("In order");
            BinarySearchTree.InOrderTraversal(newRoot);
            Console.WriteLine("Pre Order");
            BinarySearchTree.PreOrderTraversal(newRoot);
            Console.WriteLine("Post Order");
            BinarySearchTree.PostOrderTraversal(newRoot);
        }
    }

    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.value = value;
        }
    }
    class BinarySearchTree
    {

        public static void InOrderTraversal(Node root)
        {
            if(root.left != null)
            {
                InOrderTraversal(root.left);    
            }
           
            Console.WriteLine(root.value);

            if (root.right != null)
            {
                InOrderTraversal(root.right);
            }
        }

        public static void PostOrderTraversal(Node root)
        {
            if (root.left != null)
            {
                PostOrderTraversal(root.left);
            }

            if (root.right != null)
            {
                PostOrderTraversal(root.right);
            }
            Console.WriteLine(root.value);
        }

        public static void PreOrderTraversal(Node root)
        {
            Console.WriteLine(root.value);

            if (root.left != null)
            {
                PreOrderTraversal(root.left);
            }

            if (root.right != null)
            {
                PreOrderTraversal(root.right);
            }

        }

        public static Node Search(Node root, int value)
        {
            if(root == null)
            {
                Node newNode = new Node(-1);
                return newNode;
            }

            if (root.value == value)
            {
                return root;
            }
            else if (value < root.value)
            {// go to left child
                root = Search(root.left, value);
            }
            else if (value > root.value)
            {// go to right child
                root = Search(root.right, value);
            }
            return root;


        }

        public static Node Insert(Node root,int value)
        {
            if(root.value == value)
            {
                return root;
            }
            else if(value < root.value)
            {
                if (root.left != null)
                {
                    root.left = Insert(root.left, value);
                }
                else
                {
                    //Insert new Node
                    Node newNode = new Node(value);
                    root.left = newNode;
                }
            }
            if (root.value == value)
            {
                return root;
            }
            else if (value > root.value)
            {
                if (root.right != null)
                {
                    root.right = Insert(root.right, value);
                }
                else
                {
                    //Insert new Node
                    Node newNode = new Node(value);
                    root.right = newNode;
                }
            }

            return root;
        }
    }
}
