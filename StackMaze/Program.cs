using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StackMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"MyMaze.maze");

            string[] mazeSize = lines[0].Split(' ');
            string[] startPoint = lines[1].Split(' ');

            char[,] newMaze = new char[Int32.Parse(mazeSize[0]), Int32.Parse(mazeSize[1])];
            char[] mazeLine;

            for (int i = 2; i < lines.Length; i++)
            {
                mazeLine = lines[i].ToCharArray();

                for (int j = 0; j < mazeLine.Length; j++)
                {
                    newMaze[i - 2, j] = mazeLine[j];
                }
            }

            /*DepthFirst depthFirst = new DepthFirst(newMaze);

            depthFirst.StartPoint = new Point(Int32.Parse(startPoint[0]), Int32.Parse(startPoint[1]));

            if (depthFirst.DepthFirstSeach(depthFirst.StartPoint.Row, depthFirst.StartPoint.Column))
            {
                Console.WriteLine(depthFirst.ExitFound());

                Stack<Point> stack = depthFirst.PathToFollow();

                string steps = "";

                while (!stack.IsEmplty())
                {
                    steps = steps.Insert(0, stack.Pop().ToString() + "\n");
                }

                Console.WriteLine(steps);

                Console.WriteLine(depthFirst.DumpMaze());
            }
            else
            {
                Console.Write(depthFirst.NoExit());
            }

            Console.ReadLine();*/

            BreadthFirst breadthFirst = new BreadthFirst(newMaze);

            if (breadthFirst.BreathFirstSearch(1, 1))
            {
                Console.WriteLine(breadthFirst.ExitFound());
            }
            else
            {
                Console.WriteLine("No Exit");
            }

            Console.ReadLine();
        }
    }
}
