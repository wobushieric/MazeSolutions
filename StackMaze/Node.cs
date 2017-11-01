using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMaze
{
    public class Node<T>
    {
        public T Element { get; }
        public Node<T> Previous { get; }

        public Node() { }

        public Node(T element)
        {
            this.Element = element;
        }

        public Node(T element, Node<T> previous)
        {
            this.Element = element;
            this.Previous = previous;
        }
    }
}
