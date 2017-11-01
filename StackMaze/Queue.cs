using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMaze
{
    public class Queue<T>
    {
        public class Node<TA> : ICloneable
        {
            public Node<TA> Next { get; set; }

            public TA Element { get; set; }

            public Node() { }

            public Node(TA element)
            {
                this.Element = element;
            }

            public Node(TA element, Node<TA> next)
            {
                this.Next = next;

                this.Element = element;
            }

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        private Node<T> Head { get; set; }

        private Node<T> Tail { get; set; }

        private int Size { get; set; }

        public void Enqueue(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (this.Size == 0)
            {
                this.Head = newNode;
            }
            else
            {
                this.Tail.Next = newNode;
            }

            this.Tail = newNode;

            this.Size++;
        }

        public T Front()
        {
            if (this.Size <= 0)
            {
                throw new NullReferenceException("No such element");
            }

            return this.Head.Element;
        }

        public T Dequeue()
        {
            if (this.Size <= 0)
            {
                throw new NullReferenceException("No such element");
            }
            
            Node<T> headCopy = (Node<T>)this.Head.Clone();

            T headElementCopy = headCopy.Element;

            if (this.Size == 1)
            {
                this.Tail = this.Head = null;
            }
            else if(this.Size > 1)
            {
                this.Head = this.Head.Next;
            }

            this.Size--;

            return headElementCopy;
        }

        public int GetSize()
        {
            return this.Size;
        }

        public bool IsEmpty()
        {
            if (this.Size > 0)
            {
                return false;
            }

            return true;
        }
    }
}
