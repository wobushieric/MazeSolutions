using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMaze
{
    public class DepthFirst
    {
        private char[,] maze;
        private char visitedMarker = 'V';
        private char exitMarker = 'E';
        private char hallMarker = ' ';
        public Stack<Point> stack { get; set; }
        public Point StartPoint { get; set; }
        private bool MazeSearched;

        public DepthFirst(char[,] maze)
        {
            this.maze = maze;
            this.stack = new Stack<Point>();
            this.MazeSearched = false;
        }

        public bool DepthFirstSeach(int row, int column)
        {
            this.MazeSearched = true;

            if (this.maze[row, column] == this.exitMarker)
            {
                this.stack.Push(new Point(row, column));

                return true;
            }
            else if(this.maze[row, column] != this.visitedMarker)
            {
                this.stack.Push(new Point(row, column));

                this.maze[row, column] = visitedMarker;
            }

            if (this.maze[row + 1, column] == this.hallMarker ||
                this.maze[row + 1, column] == this.exitMarker)
            {
                row++;
                return this.DepthFirstSeach(row, column);

            }else if (this.maze[row, column + 1] == this.hallMarker ||
                      this.maze[row, column + 1] == this.exitMarker)
            {
                column++;
                return this.DepthFirstSeach(row, column);
            }
            else if (this.maze[row, column - 1] == this.hallMarker ||
                      this.maze[row, column - 1] == this.exitMarker)
            {
                column--;
                return this.DepthFirstSeach(row, column);
            }
            else if (this.maze[row - 1, column] == this.hallMarker ||
                     this.maze[row - 1, column] == this.exitMarker)
            {
                row--;
                return this.DepthFirstSeach(row, column);
            }

            this.stack.Pop();

            if (!this.stack.IsEmplty())
            {
                return DepthFirstSeach(stack.Top().Row, stack.Top().Column);
            }
            
            return false;
        }

        public string NoExit()
        {
            CheckSearch();

            return "There is no exit out of the maze.";
        }

        public void CheckSearch()
        {
            if (!this.MazeSearched)
            {
                throw new Exception("IllegalStateException");
            }
        }

        public string ExitFound()
        {
            CheckSearch();

            Stack<Point> stepsStack = PathToFollow();

            string st = string.Format("Path to follow from Start[{0}, {1}] to Exit[{2}, {3}] - {4} steps", 
                                       this.StartPoint.Row,
                                       this.StartPoint.Column,
                                       stepsStack.Top().Row,
                                       stepsStack.Top().Column,
                                       stepsStack.GetSize());

            return st + "\n";
        }

        public Stack<Point> PathToFollow()
        {
            CheckSearch();

            return (Stack<Point>)stack.Clone();
        }

        public string DumpMaze()
        {
            CheckSearch();

            string mazeString = "";

            while (!this.stack.IsEmplty())
            {
                this.maze[stack.Top().Row, stack.Top().Column] = '.';

                stack.Pop();
            }

            int rowLength = this.maze.GetLength(0);
            int colLength = this.maze.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    mazeString += maze[i, j];
                }
                mazeString += "\n";
            }

            return mazeString;
        }
    }
}
