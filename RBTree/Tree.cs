using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTree
{
    public class Tree<T> where T : IComparable<T>
    {
        //public bool R = true;
        //public bool B = false;
        // red is true, false is black
        public Node<T> Head;

        public Tree()
        {
            Head = null;
        }

        public bool isRed(Node<T> node)
        {
            if (node == null)
            {
                return false;
            }
            return node.Color;
        }

        public void FlipColor(Node<T> node) 
        {
            node.Color = !node.Color;
            node.Left.Color = !node.Left.Color;
            node.Right.Color = !node.Right.Color;
        }

        public void Insert(T value)
        {
            Head = Insert(Head, value);
            Head.Color = false;
        }

        //The new parent of the rotation will inherit the color of it's original parent then the original parent will become red

        public Node<T> RotateLeft(Node<T> node)
        {
            Node<T> r = node.Right;
            node.Right = r.Left;
            r.Left = node;
            r.Color = node.Color;
            node.Color = true;
            return r;
        }

        public Node<T> RotateRight(Node<T> node)
        {
            Node<T> l = node.Left;
            node.Left = l.Right;
            l.Right = node;
            l.Color = node.Color;
            node.Color = true;
            return l;
        }

        private Node<T> Insert(Node<T> node, T value)
        {
            if (node == null)
            {
                return new Node<T>(value);
            }

            if (isRed(node.Left) && isRed(node.Right)) 
            {
                FlipColor(node);
            }

            int compare = value.CompareTo(node.Value);
            if(compare == 0)
            {
                Console.WriteLine("Please choose a different value");
            }
            if(compare < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }

            if (isRed(node.Right) && !isRed(node.Left)) //rotate left, flip color
            {
                node = RotateLeft(node);
            }
            if (isRed(node.Left) && isRed(node.Left.Left))
            {
                node = RotateRight(node);
            }      

            return node;
        }

        public Node<T> moveRedRight(Node<T> node)
        {
            FlipColor(node);
            if(isRed(node.Left.Left))
            {
                RotateRight(node);
                FlipColor(node);
            }
            return node;
        }

        public Node<T> moveRedLeft(Node<T> node)
        {
            FlipColor(node);
            if(isRed(node.Right.Left))
            {
                node.Right = RotateLeft(node.Right);
                node = RotateLeft(node);
                FlipColor(node);
            }
            return node;
        }

        public Node<T> FixUp(Node<T> node)
        {
            if(isRed(node.Right))
            {
                RotateLeft(node);
            }
            if(isRed(node.Left) && isRed(node.Left.Left))
            {
                RotateRight(node);
            }
            if(isRed(node.Left) && isRed(node.Right))
            {
                FlipColor(node);
            }
            if(isRed(node.Left.Right))
            {
                RotateLeft(node.Left);
                RotateRight(node.Left);
            }
            return node;
        }

        public void Delete(T value)
        {
            Head = Delete(Head, value);
            Head.Color = false;
        }

        public Node<T> Delete(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if(!isRed(node.Left) && !isRed(node.Left.Left))
                {
                    moveRedLeft(node);
                }
                node.Left = Delete(node.Left, value);
            }
            else
            {
                node.Right = Delete(node.Right, value);
                if(isRed(node.Left))
                {
                    RotateRight(node);
                }
                if(value.CompareTo(node.Value) == 0)
                {
                    if(!isRed(node.Left) && !isRed(node.Right))
                    {
                        return null;
                    }
                    else
                    {
                        if(!isRed(node.Right) && !isRed(node.Right.Left))
                        {
                            moveRedRight(node);
                        }
                        //if right child is 2-node -> moveredright
                        //find right sub-tree min value, replace the value to delete w/ min value
                        // recursively delete for that min value
                    }
                }

            }
            return FixUp(node);
        }
    }
}
