using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTree
{
    public class Tree<T> where T : IComparable<T>
    {
        public bool R = true;
        public bool B = false;
        public Node<T> Head;

        public Tree()
        {
            Head = null;
        }

        public void FlipColor(Node<T> node)
        {
            if(!node.isRed() && node.Right.Color == R && node.Left.Color == R)
            {
                node.Color = R;
                node.Left.Color = B;
                node.Right.Color = B;
            }
        }

        public void Insert(T value)
        {
            Head = Insert(Head, value);
            Head.Color = B;
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
                node = Insert(node.Left, value);
            }
            else
            {
                node = Insert(node.Right, value);
            }

        }
    }
}
