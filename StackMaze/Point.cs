using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMaze
{
    public class Point
    {
        public int Row { get; }
        public int Column { get; }
        public int ParentRow { get; set; }
        public int ParentColumn { get; set; }

        public Point(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public Point(int row, int column, int parentRow, int parentColumn)
        {
            this.Row = row;
            this.Column = column;
            this.ParentRow = parentRow;
            this.ParentColumn = parentColumn;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.Row, this.Column);
        }
    }
}
