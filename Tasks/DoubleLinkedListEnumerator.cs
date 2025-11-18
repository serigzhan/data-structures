using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public class DoubleLinkedListEnumerator<T> : IEnumerator<T>
    {

        public Node<T> Head { get; }

        public Node<T> CurrentNode { get; set; }

        public T Current => CurrentNode.Data;

        object IEnumerator.Current => Current;

        public DoubleLinkedListEnumerator (Node<T> head)
        {

            Node<T> DammyHead = new(default)
            {
                Next = head
            };

            Head = DammyHead;
            CurrentNode = DammyHead;

        }

        public void Dispose() { }

        public bool MoveNext()
        {

            CurrentNode = CurrentNode.Next;

            return CurrentNode != null;

        }

        public void Reset()
        {

            CurrentNode = Head;

        }
    }
}
