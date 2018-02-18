using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Add(5);
            tree.Add(6);
            tree.Add(4);
            tree.Add(2);
            tree.Add(3);

        }
    }
}
