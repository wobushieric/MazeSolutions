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
    public class StackTests
    {
        [Test()]
        public void PushTestHead()
        {
            Point firstPoint = new Point(1, 1);

            Node<Point> firstNode = new Node<Point>(firstPoint);

            Stack<Node<Point>> stack = new Stack<Node<Point>>();

            stack.Push(firstNode);

            Assert.AreEqual(1, stack.GetSize());
            Assert.AreEqual(firstNode, stack.Top());
        }

        [Test()]
        public void PushTestAfterHead()
        {
            Point firstPoint = new Point(1, 1);
            Point secondPoint = new Point(1, 2);

            Node<Point> firstNode = new Node<Point>(firstPoint);
            Node<Point> secondNode = new Node<Point>(secondPoint);

            Stack<Node<Point>> stack = new Stack<Node<Point>>();

            stack.Push(firstNode);
            stack.Push(secondNode);

            Assert.AreEqual(2, stack.GetSize());
            Assert.AreEqual(secondNode, stack.Top());
        }

        [Test()]
        public void TopTestWithException()
        {
            Stack<Node<Point>> stack = new Stack<Node<Point>>();

            try
            {
                stack.Top();
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("No such element", e.Message);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test()]
        public void TopTestNormal()
        {
            this.PushTestHead();
        }

        [Test()]
        public void PopTestWithException()
        {
            Stack<Node<Point>> stack = new Stack<Node<Point>>();

            try
            {
                Node<Point> oldHead = stack.Pop();
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("No such element", e.Message);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test()]
        public void PopTestNormal()
        {
            Point firstPoint = new Point(1, 1);

            Node<Point> firstNode = new Node<Point>(firstPoint);

            Stack<Node<Point>> stack = new Stack<Node<Point>>();

            stack.Push(firstNode);

            Node<Point> oldHead = stack.Pop();

            Assert.AreEqual(0, stack.GetSize());
            Assert.AreEqual(firstNode, oldHead);
        }

        [Test()]
        public void GetSizeTest()
        {
            Stack<Node<Point>> stack = new Stack<Node<Point>>();

            Assert.AreEqual(0, stack.GetSize());

            this.PushTestHead();
            this.PushTestAfterHead();
        }

        [Test()]
        public void IsEmpltyTestWithEmptyStack()
        {
            Stack<Node<Point>> stack = new Stack<Node<Point>>();

            Assert.AreEqual(true, stack.IsEmplty());
        }

        [Test()]
        public void IsEmpltyTestWithNotEmptyStack()
        {
            Point firstPoint = new Point(1, 1);

            Node<Point> firstNode = new Node<Point>(firstPoint);

            Stack<Node<Point>> stack = new Stack<Node<Point>>();

            stack.Push(firstNode);

            Assert.AreEqual(false, stack.IsEmplty());
        }
    }
}