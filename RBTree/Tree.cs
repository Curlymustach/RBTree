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
            if (compare == 0)
            {
                Console.WriteLine("Please choose a different value");
            }
            if (compare < 0)
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

        public void Delete(T value)
        {
            Head = Delete(Head, value);
            Head.Color = false;
        }

        public Node<T> Delete(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if(node.Left != null)
                {
                    if (!isRed(node.Left) && !isRed(node.Left.Left))
                    {
                        node = moveRedLeft(node);
                    }
                    node.Left = Delete(node.Left, value);
                }                
            }
            else
            {
                if (isRed(node.Left))
                {
                    node = RotateRight(node);
                }
                if (value.CompareTo(node.Value) == 0 && node.Right == null) //delete leaf
                {
                    return null;
                }
                if (!isRed(node.Right) && !isRed(node.Right.Left)) //if child is 2-node
                {
                    node = moveRedRight(node);
                }
                if (value.CompareTo(node.Value) == 0)
                {
                    Node<T> min = GetMinimum(node.Right);
                    node.Value = min.Value;
                    node.Right = DeleteMin(node.Right);
                }
                else
                {
                    node.Right = Delete(node.Right, value);
                }
                
            }
            return FixUp(node);
        }

        public Node<T> moveRedRight(Node<T> node)
        {
            FlipColor(node);
            if (isRed(node.Left.Left))
            {
                node = RotateRight(node);
                FlipColor(node);
            }
            return node;
        }

        public Node<T> moveRedLeft(Node<T> node)
        {
            FlipColor(node);
            if (isRed(node.Right.Left) && isRed(node.Right))
            {
                node.Right = RotateRight(node.Right);
                node = RotateLeft(node);
                FlipColor(node);
            }
            return node;
        }

        public Node<T> FixUp(Node<T> node)
        {
            if (isRed(node.Right))
            {
                node = RotateLeft(node);
            }
            if (isRed(node.Left) && isRed(node.Left.Left))
            {
                node = RotateRight(node);
            }
            if (isRed(node.Left) && isRed(node.Right))
            {
                FlipColor(node);
            }
            if (node.Left != null && isRed(node.Left.Right) && !isRed(node.Left.Left))
            {
                node = RotateLeft(node.Left);
                if (isRed(node.Left) && node.Left.Left != null)
                {
                    node = RotateRight(node.Left);
                }

            }
            return node;
        }

        public Node<T> GetMinimum(Node<T> node)
        {
            Node<T> temp = node;
            while (temp.Left != null)
            {
                temp = temp.Left;
            }
            return temp;
        }

        public Node<T> DeleteMin(Node<T> node)
        {
            if(node.Left == null)
            {
                return null;
            }
            if(!isRed(node.Left) && !isRed(node.Left.Left))
            {
                node = moveRedLeft(node);
            }
            node.Left = DeleteMin(node.Left);
            return FixUp(node);
        }
    }
}
