using NUnit.Framework;
using StackMaze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMaze.Tests
{
    [TestFixture()]
    public class QueueTests
    {
        [Test()]
        public void FrontTestWithException()
        {
            Queue<string> queue = new Queue<string>();

            try
            {
                string a = queue.Front();
            }
            catch (Exception e)
            {
                Assert.AreEqual("No such element", e.Message);
            }
        }

        [Test()]
        public void FrontTestSizeOne()
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("a");

            Assert.AreEqual("a", queue.Front());
        }

        [Test()]
        public void FrontTestSizeGreaterThanOne()
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("a");

            queue.Enqueue("b");

            Assert.AreEqual("a", queue.Front());
        }

        [Test()]
        public void EnqueueTest()
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("a");

            Assert.AreEqual(1, queue.GetSize());

            queue.Enqueue("b");

            Assert.AreEqual(2, queue.GetSize());
        }

        [Test()]
        public void IsEmptyTestWithEmpltyQueue()
        {
            Queue<string> queue = new Queue<string>();

            Assert.AreEqual(true, queue.IsEmpty());
        }

        [Test()]
        public void IsEmptyTestWithUnempltyQueue()
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("a");

            Assert.AreEqual(false, queue.IsEmpty());
        }

        [Test()]
        public void DequeueTestWithException()
        {
            Assert.Fail();
        }
    }
}