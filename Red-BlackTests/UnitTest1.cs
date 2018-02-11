using Microsoft.VisualStudio.TestTools.UnitTesting;
using RBTree;

namespace Red_BlackTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //public void RedBlackTreeConstructorTest()
        //{
        //    Tree<int> testTree = new Tree<int>();
        //    Assert.AreEqual(null, testTree.Head, "Should be null");
        //}

        public void AddTest()
        {
            Tree<int> testTree = new Tree<int>();
            testTree.Add(5);
            Assert.AreEqual(5, testTree.Head.Value);

            testTree.Add(6);
            Assert.AreEqual(6, testTree.Head.Right.Value);

            testTree.Add(7);
            Assert.AreEqual(7, testTree.Head.Right.Right.Value);
            Assert.AreEqual(6, testTree.Head.Right.Right.Parent.Value);
            Assert.AreEqual(5, testTree.Head.Right.Right.Grandparent.Value);
            //Assert.AreEqual(testTree.Head, testTree.Head.Right.Parent);
        }
    }
}
