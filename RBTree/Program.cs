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

            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(3);

            tree.Delete(6);
            

        }
    }
}
