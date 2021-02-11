using System;
using System.Collections.Generic;
using System.Linq;

namespace Deque.Model
{
    /// <summary>
    /// Deque.
    /// </summary>
    /// <typeparam name="T"> The type of data stored in the Deque. </typeparam>
    public class EasyDeque<T>
    {
        /// <summary>
        /// The collection of stored data.
        /// </summary>
        private readonly List<T> items = new List<T>();

        /// <summary>
        /// Last element in deque.
        /// </summary>
        private T Tail => items.Last();

        /// <summary>
        /// First element in deque.
        /// </summary>
        private T Head => items.First();

        /// <summary>
        /// Amount of elements.
        /// </summary>
        public int Count => items.Count;

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

            items.Add(data);
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

            items.Insert(0, data);
        }

        /// <summary>
        /// Remove from the end of the queue.
        /// </summary>
        /// <returns> Removable item. </returns>
        public T PopBack()
        {
            T item = Tail;
            items.Remove(item);

            return item;
        }

        /// <summary>
        /// Delete from the beginning of the queue.
        /// </summary>
        /// <returns> Removable item. </returns>
        public T PopFront()
        {
            T item = Head;
            items.Remove(item);

            return item;
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

            return Tail;
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

            return Head;
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

            foreach (T item in items)
            {
                if (item.Equals(data))
                {
                    return $"Element {data} is in the list.";
                }
            }

            return $"Element {data} is not in the list.";
        }
    }
}