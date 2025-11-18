using System.Collections.Generic;

namespace Tasks
{
    public class Node<T>(T data)
    {

        public T Data { get; set; } = data;

        public Node<T> Prev { get; set; } = null;

        public Node<T> Next { get; set; } = null;

        public bool IsEqual(T other)
        {

            return EqualityComparer<T>.Default.Equals(Data, other);

        }

    }
}
