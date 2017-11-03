using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMaze
{
    public class BreadthFirst
    {
        private char[,] maze;
        public Queue<Point> queue;
        private char visitedMarker = 'V';
        private char exitMarker = 'E';
        private char hallMarker = ' ';
        private bool MazeSearched;
        public ArrayList PointTracker;
        public Point StartPoint { get; set; }
        public int StepsCounter { get; private set; }
        public LinkedList<Point> path;

        public BreadthFirst(char[,] maze)
        {
            this.maze = maze;
            this.queue = new Queue<Point>();
            this.MazeSearched = false;
            this.PointTracker = new ArrayList();
            this.path = new LinkedList<Point>();
        }

        public bool BreathFirstSearch(int row, int column, int parentRow, int parentColumn)
        {
            this.MazeSearched = true;

            bool foundExit = false;

            do
            {
                if (this.maze[row, column] == this.exitMarker)
                {
                    this.PointTracker.Add(new Point(row, column, parentRow, parentColumn));

                    foundExit = true;
                }
                else if (this.maze[row, column] != this.visitedMarker)
                {
                    this.maze[row, column] = visitedMarker;

                    this.PointTracker.Add(new Point(row, column, parentRow, parentColumn));
                }

                if (this.maze[row + 1, column] == this.hallMarker ||
                    this.maze[row + 1, column] == this.exitMarker)
                {
                    this.queue.Enqueue(new Point(row + 1, column, row, column));
                }

                if (this.maze[row, column + 1] == this.hallMarker ||
                    this.maze[row, column + 1] == this.exitMarker)
                {
                    this.queue.Enqueue(new Point(row, column + 1, row, column));
                }

                if (this.maze[row, column - 1] == this.hallMarker ||
                    this.maze[row, column - 1] == this.exitMarker)
                {
                    this.queue.Enqueue(new Point(row, column - 1, row, column));
                }

                if (this.maze[row - 1, column] == this.hallMarker ||
                    this.maze[row - 1, column] == this.exitMarker)
                {
                    this.queue.Enqueue(new Point(row - 1, column, row, column));
                }

                if (!this.queue.IsEmpty())
                { 
                    Point oldHead = this.queue.Dequeue();

                    row = oldHead.Row;
                    column = oldHead.Column;
                    parentRow = oldHead.ParentRow;
                    parentColumn = oldHead.ParentColumn;
                }

            } while (!foundExit || this.queue.IsEmpty());

            return foundExit;
        }

        public void CheckSearch()
        {
            if (!this.MazeSearched)
            {
                throw new Exception("IllegalStateException");
            }
        }

        public string NoExit()
        {
            CheckSearch();

            return "There is no exit out of the maze.";
        }

        public string ExitFound()
        {
            return "Path to follow from Start " + this.StartPoint + " to Exit " + this.queue.Front();
        }

        public string PathToFollow()
        {
            CheckSearch();

            Point pathPoint = this.queue.Front();

            this.StepsCounter = 0;

            string exitPath = "";

            do
            {
                foreach (Point point in PointTracker)
                {
                    if (point.Row == pathPoint.Row && point.Column == pathPoint.Column)
                    {
                        exitPath = exitPath.Insert(0, pathPoint + "\n");

                        path.AddFirst(pathPoint);

                        pathPoint = new Point(point.ParentRow, point.ParentColumn);

                        this.StepsCounter++;
                    }
                }
            } while (!(pathPoint.Row == StartPoint.Row && pathPoint.Column == StartPoint.Column));

            exitPath = exitPath.Insert(0, StartPoint + "\n");

            path.AddFirst(StartPoint);

            this.StepsCounter++;

            return exitPath;
        }

        public string DumpMaze()
        {
            return "";
        }
    }
}
