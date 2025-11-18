using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {

        #region Properties

        public int Length { get; set; } = 0;

        private Node<T> Head { get; set; } = null;

        private Node<T> Last { get; set; } = null;

        #endregion


        /// <summary>
        /// Add a new element to the end of list
        /// </summary>
        /// <param name="e"></param>
        public void Add(T e)
        {

            var node = new Node<T>(e);

            if (Head == null)
            {

                Head = node;
                Last = node;

            }
            else
            {

                node.Prev = Last;
                Last.Next = node;
                Last = node;

            }

            Length++;

        }

        /// <summary>
        /// Insert a new element at a specific index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="e"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void AddAt(int index, T e)
        {

            if (index < 0 || index > Length) throw new IndexOutOfRangeException();

            var node = new Node<T>(e);

            if (index == 0)
            {

                if (Head == null)
                {

                    Head = node;
                    Last = node;

                }
                else
                {

                    node.Next = Head;
                    Head.Prev = node;
                    Head = node;

                }

                Length++;

                return;

            }
            else if (index == Length)
            {

                node.Prev = Last;
                Last.Next = node;
                Last = node;

                Length++;

                return;

            }

            int idx = 1;
            var temp = Head.Next;

            while (true)
            {
                if (idx == index)
                {

                    node.Prev = temp.Prev;
                    node.Next = temp;

                    temp.Prev.Next = node;
                    temp.Prev = node;

                    Length++;
                    break;

                }

                temp = temp.Next;
                idx++;
            }

        }

        /// <summary>
        /// Return the element at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T ElementAt(int index)
        {
            if (index < 0 || index >= Length) throw new IndexOutOfRangeException();

            int startIndex = 0;

            var temp = Head;

            while (true)
            {

                if (startIndex == index)
                {
                    return temp.Data;
                }

                temp = temp.Next;
                startIndex++;

            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoubleLinkedListEnumerator<T>(Head);
        }

        /// <summary>
        /// Remove the first accurrence of a value from the list
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Remove(T item)
        {

            if (Length == 0) throw new IndexOutOfRangeException();

            if (Head.IsEqual(item))
            {

                Head = Head.Next;
                Length--;

                return;

            }

            int index = 1;
            var temp = Head.Next;

            while (true)
            {

                if (temp == null) break;

                if (temp.IsEqual(item))
                {

                    var tempNext = temp.Next;
                    temp.Prev.Next = temp.Next;

                    if (tempNext == null)
                    {
                        Last = temp.Prev;
                    }
                    else
                    {
                        tempNext.Prev = temp.Prev;
                    }

                    Length--;
                    break;

                }

                index++;
                temp = temp.Next;

            }

        }

        /// <summary>
        /// Remove the element at a specific index and return it's data
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Length) throw new IndexOutOfRangeException();

            if (index == 0)
            {
                var tempHead = Head;
                Head = Head.Next;

                Length--;

                return tempHead.Data;

            }
            else if (index == Length - 1)
            {

                var tempLast = Last;
                Last = tempLast.Prev;
                Last.Next = null;

                Length--;

                return tempLast.Data;

            }

            int idx = 1;
            var temp = Head.Next;

            while (true)
            {
                if (idx == index)
                {

                    temp.Prev.Next = temp.Next;
                    temp.Next.Prev = temp.Prev;

                    return temp.Data;

                }

                temp = temp.Next;
                idx++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
