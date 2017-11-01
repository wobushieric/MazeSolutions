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
    public class PointTests
    {
        [Test()]
        public void ToStringTest()
        {
            int row = 3;
            int column = 5;

            Point point = new Point(row, column);

            Assert.AreEqual("[3, 5]", point.ToString());
        }
    }
}