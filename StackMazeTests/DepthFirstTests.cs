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
    public class DepthFirstTests
    {
        [Test()]
        public void DepthFirstSeachTestNoExit()
        {
            char[,] NoExitMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'W', 'W'}
            };

            DepthFirst depthFirst = new DepthFirst(NoExitMaze);

            depthFirst.StartPoint = new Point(1, 1);

            Assert.AreEqual(false, depthFirst.DepthFirstSeach(1, 1));
        }

        [Test()]
        public void DepthFirstSeachTestExitFound()
        {
            char[,] ExitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            DepthFirst depthFirst = new DepthFirst(ExitableMaze);

            Assert.AreEqual(true, depthFirst.DepthFirstSeach(1, 1));
        }

        [Test()]
        public void DepthFirstSeachTestStartFromExit()
        {
            char[,] ExitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            DepthFirst depthFirst = new DepthFirst(ExitableMaze);

            Assert.AreEqual(true, depthFirst.DepthFirstSeach(3, 1));
        }

        [Test()]
        public void NoExitTest()
        {
            char[,] NoExitMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'W', 'W'}
            };

            DepthFirst depthFirst = new DepthFirst(NoExitMaze);

            depthFirst.DepthFirstSeach(1, 1);

            string expectedSt = "There is no exit out of the maze.";

            Assert.AreEqual(expectedSt, depthFirst.NoExit());
        }

        [Test()]
        public void ExitFoundTest()
        {
            char[,] ExitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            DepthFirst depthFirst = new DepthFirst(ExitableMaze);

            depthFirst.StartPoint = new Point(1, 1);

            depthFirst.DepthFirstSeach(1, 1);

            string expectedSt = "Path to follow from Start[1, 1] to Exit[3, 1] - 3 steps\n";

            Assert.AreEqual(expectedSt, depthFirst.ExitFound());
        }

        [Test()]
        public void PathToFollowTest()
        {
            char[,] ExitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            DepthFirst depthFirst = new DepthFirst(ExitableMaze);

            depthFirst.StartPoint = new Point(1, 1);

            depthFirst.DepthFirstSeach(1, 1);

            Stack<Point> pathStack = depthFirst.PathToFollow();
            Stack<Point> depthStack = depthFirst.stack;

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(pathStack.Pop(), depthStack.Pop());
            }
        }

        [Test()]
        public void DumpMazeTest()
        {
            char[,] ExitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            DepthFirst depthFirst = new DepthFirst(ExitableMaze);

            depthFirst.StartPoint = new Point(1, 1);

            depthFirst.DepthFirstSeach(1, 1);

            string expectedSt = "WWW\nW.W\nW.W\nW.W\nWWW\n";

            Assert.AreEqual(expectedSt, depthFirst.DumpMaze());
        }

        [Test()]
        public void CheckSearchTestException()
        {
            char[,] ExitableMaze = {
                {'W', 'W', 'W'},
                {'W', ' ', 'W'},
                {'W', ' ', 'W'},
                {'W', 'E', 'W'},
                {'W', 'W', 'W'}
            };

            DepthFirst depthFirst = new DepthFirst(ExitableMaze);

            depthFirst.StartPoint = new Point(1, 1);

            try
            {
                depthFirst.CheckSearch();
            }
            catch (Exception e)
            {
                Assert.AreEqual("IllegalStateException", e.Message);
            }
        }
    }
}