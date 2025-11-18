using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {

        private readonly DoublyLinkedList<T> list = [];

        public T Dequeue()
        {
            if (list.Length == 0) throw new InvalidOperationException();

            return list.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            list.AddAt(list.Length, item);
        }

        public T Pop()
        {
            if (list.Length == 0) throw new InvalidOperationException();

            return list.RemoveAt(list.Length - 1);
        }

        public void Push(T item)
        {
            list.AddAt(list.Length, item);
        }
    }
}
