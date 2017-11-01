using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMaze
{
    public class Stack<T> : ICloneable
    {
        private Node<T> Head { get; set; }
        public int Size { get; set; }

        public Stack() { }

        public void Push(T element)
        {
            this.Head = new Node<T>(element, this.Head);

            this.Size++;
        }

        public T Top()
        {
            if (this.Size <= 0)
            {
                throw new NullReferenceException("No such element");
            }

            return this.Head.Element;
        }

        public T Pop()
        {
            if (this.Size <= 0)
            {
                throw new NullReferenceException("No such element");
            }

            Node<T> current = this.Head;

            this.Head = this.Head.Previous;

            this.Size--;

            return current.Element;
        }

        public int GetSize()
        {
            return this.Size;
        }

        public bool IsEmplty()
        {
            if (this.Size < 0)
            {
                throw new IndexOutOfRangeException("Negative index found");
            }
            return Size == 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
