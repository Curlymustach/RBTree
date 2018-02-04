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

            Assert.AreEqual(5, testTree.Head);
            //testTree.Add(5);
            //Assert.AreEqual(5, testTree.Head.Value);

            //testTree.Add(6);
            //Assert.AreEqual(6, testTree.Head.Right);
            //Assert.AreEqual(testTree.Head, testTree.Head.Right.Parent);
        }
    }
}
