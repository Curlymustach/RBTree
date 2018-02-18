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
            if(node.Grandparent != null)
            {
                if (node.Grandparent.Left != null && node.isRightChild())
                {
                    node.Uncle = node.Grandparent.Left;
                }
                else if (node.Grandparent.Right != null && node.isLeftChild())
                {
                    node.Uncle = node.Grandparent.Right;
                }
            }           

            Node<T> left = node.Left;
            Node<T> right = node.Right;
            Node<T> grandparent = node.Grandparent;
            Node<T> uncle = node.Uncle;
            Node<T> parent = node.Parent;

            if (node.Color == red && parent.Color == red && node != Head && node.Uncle != null)
            {
                if(uncle.Color == red)
                {
                    parent.Color = black;
                    uncle.Color = black;
                    grandparent.Color = red;
                    InsertRuleCheck(grandparent);
                }
                if(uncle.Color == black)
                {
                    if(node.isRightChild() && parent.isLeftChild())
                    {
                        parent = grandparent;
                        left = parent;
                        grandparent.Left = node;
                        left.Parent = node;

                        //node.Parent = node.Grandparent;
                        //node.Left = node.Parent;
                        //node.Grandparent.Left = node;
                        //node.Left.Parent = node;

                        InsertRuleCheck(node);
                    }
                    if (node.isLeftChild() && parent.isLeftChild())
                    {
                        Color temp = parent.Color;
                        grandparent.Left = node;
                        right = parent;
                        parent.Parent = node;
                        parent.Color = node.Color;
                        node.Color = temp;
                    }
                    if (node.isLeftChild() && node.Parent.isRightChild())
                    {
                        parent = grandparent;
                        right = parent;
                        grandparent.Right = node;
                        right.Parent = node;
                        InsertRuleCheck(node);
                    }
                    if (node.isRightChild() && node.Parent.isRightChild())
                    {
                        Color temp = parent.Color;
                        grandparent.Right = node;
                        left = parent;
                        parent.Parent = node;
                        parent.Color = node.Color;
                        node.Color = temp;
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
                            InsertRuleCheck(node);
                        }
                        else if(temp.Right.Right == null)
                        {
                            done = true;
                            temp.Right.Right = node;
                            node.Parent = temp.Right;
                            node.Grandparent = temp;
                            InsertRuleCheck(node);
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
                            InsertRuleCheck(node);
                        }
                        else if (temp.Left.Left == null)
                        {
                            done = true;
                            temp.Left.Left = node;
                            node.Parent = temp.Left;
                            node.Grandparent = temp;
                            InsertRuleCheck(node);
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
