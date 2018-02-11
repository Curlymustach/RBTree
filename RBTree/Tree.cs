using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTree
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> Head;
        Color red = Color.RED;
        Color black = Color.BLACK;
        Color doubleBlack = Color.DOUBLEBLACK;

        public Tree()
        {
            Head = null;
        }

        public void InsertRuleCheck(Node<T> node)
        {
            Head.Color = black;
            if (node.Parent.Left != null && node.isRightChild())
            {
                node.Uncle = node.Parent.Left;
            }
            else
            {
                node.Uncle = node.Parent.Right;
            }

            Node<T> left = node.Left;
            Node<T> right = node.Right;
            Node<T> grandparent = node.Grandparent;
            Node<T> uncle = node.Uncle;

            if (node.Color == red && node.Parent.Color == red && node != Head)
            {
                if(node.Uncle.Color == red)
                {
                    node.Parent.Color = black;
                    node.Uncle.Color = black;
                    node.Grandparent.Color = red;
                    InsertRuleCheck(node.Grandparent);
                }
                if(node.Uncle.Color == black)
                {
                    if(node.isRightChild() && node.Parent.isLeftChild())
                    {
                        node.Parent = node.Grandparent;
                        node.Left = node.Parent;
                        node.Grandparent.Left = node;
                        node.Left.Parent = node;
                        InsertRuleCheck(node);
                    }
                    if (node.isLeftChild() && node.Parent.isLeftChild())
                    {

                    }
                    if (node.isLeftChild() && node.Parent.isRightChild())
                    {
                        node.Parent = node.Grandparent;
                        node.Right = node.Parent;
                        node.Grandparent.Right = node;
                        node.Right.Parent = node;
                        InsertRuleCheck(node);
                    }
                    if (node.isRightChild() && node.Parent.isRightChild())
                    {

                    }

                }
            }

        }

        //i.Left-Right Case: If x is a right child and it's parent is a left child, rotate parent left (check step ii)

        //ii.Left-Left Case: If x is a left child and it's parent is a left child, rotate grandparent right and swap colors of grandparent and parent.

        //iii.Right-Left Case: If x is a left child and it's parent is a right child, rotate parent right (check step iv)

        //iv.Right-Right Case: If x is a right child and it's parent is a right child, rotate grandparent left and swap colors of grandparent and parent.

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value, black);
            }
            else
            {
                Node<T> node = new Node<T>(value, red);
                Node<T> temp = Head;
                bool done = false;
                do
                {
                    if(value.CompareTo(temp.Value) >= 0)
                    {
                        if(temp.Right == null)
                        {
                            done = true;
                            temp.Right = node;
                            node.Parent = temp;
                        }
                        else if(temp.Right.Right == null)
                        {
                            done = true;
                            temp.Right.Right = node;
                            node.Parent = temp.Right;
                            node.Grandparent = temp;
                        }
                        else
                        {
                            temp = temp.Right;
                        }

                    }

                    if(value.CompareTo(temp.Value) < 0)
                    {
                        if (temp.Left == null)
                        {
                            done = true;
                            temp.Left = node;
                            node.Parent = temp;
                        }
                        else if (temp.Left.Left == null)
                        {
                            done = true;
                            temp.Left.Left = node;
                            node.Parent = temp.Left;
                            node.Grandparent = temp;
                        }
                        else
                        {
                            temp = temp.Right;
                        }

                    }
                } while (!done);
            }
        }
    }
}
