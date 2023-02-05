using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AĞAÇ_yapısı_final2
{       
    public partial class Form1 : Form
    {
        class Node
        {
            public int data;
            public Node left;
            public Node right;
            public static string numbers;
            public void diplay()
            {
                numbers += data+ "/r/n";
            }
        }
        class TreeNode
        {
            private Node root;
            public TreeNode()
            {
                root = null;
            }
            public Node getRoot()
            {
                return root;
            }
        }
            public Form1()
        {
            InitializeComponent();
        }
        public void Insert(int number)
        {
            Node root = null;
            Node newNode = new Node();
            newNode.data = number;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (number < current.data)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            return;
                        }
                    }
                }
            }
        }
        
        private void preOrder(Node localRoot,int number)
        {
            if (localRoot != null)
            {
                localRoot.diplay();
                preOrder(localRoot.left,number);
                preOrder(localRoot.right,number);
            }
        }
        private void inOrder(Node localRoot,int number)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.left,number);
                localRoot.diplay();
                inOrder(localRoot.right,number);
            }
        }
        private void postOrder(Node localRoot,int number)
        {
            if (localRoot != null)
            {
                postOrder(localRoot.left,number);
                postOrder(localRoot.right,number);
                localRoot.diplay();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(textBox1.Text);
            Node newNode = new Node();
            Insert(number);
            textBox4.Text += number+ "\r\n";
            label1.Text = number + " düğüme eklendi";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Node newNode = new Node();
            TreeNode newNode1 = new TreeNode();
            int number = Convert.ToInt32(textBox4.Text);
            Node.numbers = "";
            inOrder(newNode1.getRoot(),number);
            textBox6.Text = Node.numbers;
            Node.numbers = "";
            preOrder(newNode1.getRoot(),number);
            textBox5.Text = Node.numbers;
            Node.numbers = "";
            postOrder(newNode1.getRoot(),number);
            textBox7.Text = Node.numbers;
        }
    }
}
