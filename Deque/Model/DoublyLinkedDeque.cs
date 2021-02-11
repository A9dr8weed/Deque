using System;
using System.Collections;
using System.Collections.Generic;

namespace Deque.Model
{
    /// <summary>
    /// Doubly Linked Deque.
    /// </summary>
    /// <typeparam name="T"> The type of data stored in the Deque. </typeparam>
    public class DoublyLinkedDeque<T> : IEnumerable<T>
    {
        /// <summary>
        /// The first item in the list.
        /// </summary>
        private Item<T> Head;

        /// <summary>
        /// The last item in the list.
        /// </summary>
        private Item<T> Tail;

        /// <summary>
        /// Amount of elements.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Create an empty list.
        /// </summary>
        public DoublyLinkedDeque() => Clear();

        /// <summary>
        /// Insert at the end of the queue.
        /// </summary>
        /// <param name="data"> Added data. </param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public void PushBack(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Item<T> item = new Item<T>(data);

            if (Head == null)
            {
                Head = item;
            }
            else
            {
                Tail.Next = item;
                item.Previous = Tail;
            }
            Tail = item;
            Count++;
        }

        /// <summary>
        /// Insert at the beginning of the queue.
        /// </summary>
        /// <param name="data"> Added data. </param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public void PushFront(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Item<T> item = new Item<T>(data);
            Item<T> current = Head;

            item.Next = current;
            Head = item;

            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                current.Previous = item;
            }
            Count++;
        }

        /// <summary>
        /// Remove from the end of the queue.
        /// </summary>
        /// <returns> Removable item. </returns>
        /// <exception cref="NullReferenceException"></exception>
        public T PopBack()
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Deque is empty");
            }

            T output = Tail.Data;

            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            Count--;

            return output;
        }

        /// <summary>
        /// Delete from the beginning of the queue.
        /// </summary>
        /// <returns> Removable item. </returns>
        /// <exception cref="NullReferenceException"></exception>
        public T PopFront()
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Deque is empty");
            }

            T output = Head.Data;

            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            Count--;

            return output;
        }

        /// <summary>
        /// Read the last item from the deque without deleting it.
        /// </summary>
        /// <returns> Data item. </returns>
        /// <exception cref="NullReferenceException"></exception>
        public T PeekBack()
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Deque is empty");
            }

            return Tail.Data;
        }

        /// <summary>
        /// Read first item from the deque without deleting it.
        /// </summary>
        /// <returns> Data item. </returns>
        /// <exception cref="NullReferenceException"></exception>
        public T PeekFront()
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Deque is empty");
            }

            return Head.Data;
        }

        /// <summary>
        /// Check for element.
        /// </summary>
        /// <param name="data"> Data to be checked </param>
        /// <returns> String with message </returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public string Contains(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Item<T> current = Head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return $"Elements {data} is in the list.";
                }
                current = current.Next;
            }

            return $"Elements {data} is not in the list.";
        }

        /// <summary>
        /// Clear list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Return an enumerator that iterates through all the elements in a queue.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate over the collection. </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Return an enumerator that iterates through the queue.
        /// </summary>
        /// <returns> The IEnumerator used to traverse the collection. </returns>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
    }
}