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

        public void InsertRuleCheck()
        {

        }

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
                        if(temp.Right.Right == null)
                        {
                            done = true;
                            temp.Right.Right = node;
                            node.Parent = temp.Right;
                            node.Grandparent = temp;
                            node.Uncle = temp.Left;
                        }
                        else
                        {
                            temp = temp.Right;
                        }

                    }

                    if(value.CompareTo(temp.Value) < 0)
                    {
                        if (temp.Left.Left == null)
                        {
                            done = true;
                            temp.Left.Left = node;
                            node.Parent = temp.Left;
                            node.Grandparent = temp;
                            node.Uncle = temp.Right;
                        }
                        else
                        {
                            temp = temp.Left;
                        }

                    }

                } while (!done);
            }
        }
    }
}
