using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {

        private readonly DoublyLinkedList<T> storage = [];

        public T Dequeue()
        {
            if (storage.Length == 0) throw new InvalidOperationException();

            return storage.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            storage.AddAt(storage.Length, item);
        }

        public T Pop()
        {
            if (storage.Length == 0) throw new InvalidOperationException();

            return storage.RemoveAt(storage.Length - 1);
        }

        public void Push(T item)
        {
            storage.AddAt(storage.Length, item);
        }
    }
}
