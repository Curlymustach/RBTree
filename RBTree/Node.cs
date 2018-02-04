using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTree
{
    public enum Color
    {
        RED,
        BLACK,
        DOUBLEBLACK
    };

    public class Node<T> where T : IComparable<T>
    {
        //Color myColor = Color.RED;

        public T Value;
        public Node<T> Left;
        public Node<T> Right;
        public Node<T> Parent;
        public Node<T> Uncle;
        public Node<T> Grandparent;
        public Color Color;

        public Node(T Value, Node<T> Left, Node<T> Right, Node<T> Parent, Color Color)
        {
            this.Value = Value;
            this.Left = Left;
            this.Right = Right;
            this.Parent = Parent;
            this.Color = Color;
        }

        public Node(T Value, Node<T> Left, Node<T> Right)
        {
            this.Value = Value;
            this.Left = Left;
            this.Right = Right;
        }

        public Node(T Value, Color Color)
        {
            this.Value = Value;
            this.Color = Color;
        }

        public bool isRightChild()
        {
            if (Parent == null) return false;
            if (Value.CompareTo(Parent.Value) > 0)
            {
                return true;
            }
            return false;
        }

        public bool isLeftChild()
        {
            return !isRightChild();
        }

    }
}
