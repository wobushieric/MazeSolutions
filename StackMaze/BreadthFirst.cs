using System;
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

        public BreadthFirst(char[,] maze)
        {
            this.maze = maze;
            this.queue = new Queue<Point>();
            this.MazeSearched = false;
        }

        public bool BreathFirstSearch(int row, int column)
        {
            this.MazeSearched = true;
            
            if (this.maze[row, column] == this.exitMarker)
            {
                return true;
            }
            else if (this.maze[row, column] != this.visitedMarker)
            {
                this.maze[row, column] = visitedMarker;
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

                return this.BreathFirstSearch(oldHead.Row, oldHead.Column);
            }

            return false;
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
            return this.queue.Front().ToString();
        }
    }
}
