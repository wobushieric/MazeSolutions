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
    public class BreadthFirstTests
    {
        [Test()]
        public void CheckSearchTestWithException()
        {
            char[,] exitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            BreadthFirst breadthFirst = new BreadthFirst(exitableMaze);

            try
            {
                breadthFirst.CheckSearch();
            }
            catch (Exception e)
            {
                Assert.AreEqual("IllegalStateException", e.Message);
            }
        }

        [Test()]
        public void NoExitTest()
        {
            char[,] noExitMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'W', 'W'}
            };

            BreadthFirst breadthFirst = new BreadthFirst(noExitMaze);

            Assert.AreEqual(false, breadthFirst.BreathFirstSearch(1, 1, 1, 1));
        }

        [Test()]
        public void ExitFoundTest()
        {
            char[,] exitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            BreadthFirst breadthFirst = new BreadthFirst(exitableMaze);

            breadthFirst.StartPoint = new Point(1, 1, 1, 1);

            Assert.AreEqual(true, breadthFirst.BreathFirstSearch(1, 1, 1, 1));

            string expectedSt = "Path to follow from Start [1, 1] to Exit [3, 1]";

            Assert.AreEqual(expectedSt, breadthFirst.ExitFound());
        }

        [Test()]
        public void PathToFollowTest()
        {
            char[,] exitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            BreadthFirst breadthFirst = new BreadthFirst(exitableMaze);

            breadthFirst.StartPoint = new Point(1, 1, 1, 1);

            breadthFirst.BreathFirstSearch(1, 1, 1, 1);

            string expect = "[1, 1]\n[2, 1]\n[3, 1]\n";

            Assert.AreEqual(expect, breadthFirst.PathToFollow());
        }

        [Test()]
        public void DumpMazeTest()
        {
            char[,] exitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            BreadthFirst breadthFirst = new BreadthFirst(exitableMaze);

            breadthFirst.StartPoint = new Point(1, 1, 1, 1);

            breadthFirst.BreathFirstSearch(1, 1, 1, 1);

            string expect = "WWW\nW.W\nW.W\nW.W\nWWW\n";

            breadthFirst.PathToFollow();

            Assert.AreEqual(expect, breadthFirst.DumpMaze());
        }

        [Test()]
        public void BreathFirstSearchTestNoExit()
        {
            char[,] noExitMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'W', 'W'}
            };

            BreadthFirst breadthFirst = new BreadthFirst(noExitMaze);

            Assert.AreEqual(false, breadthFirst.BreathFirstSearch(1, 1, 1, 1));
        }

        [Test()]
        public void BreathFirstSearchTestExitable()
        {
            char[,] exitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            BreadthFirst breadthFirst = new BreadthFirst(exitableMaze);

            Assert.AreEqual(true, breadthFirst.BreathFirstSearch(1, 1, 1, 1));
        }
    }
}