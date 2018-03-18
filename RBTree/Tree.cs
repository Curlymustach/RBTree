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
        public bool Color; // red is true, false is black
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
            return Color;
        }

        public void FlipColor(Node<T> node) //node is parent
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

            if(node.Left != null && node.Right != null)
            {
                FlipColor(node);
            }

            int compare = node.Value.CompareTo(value);
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
    }
}
