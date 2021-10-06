using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomListLib
{
    public class CustomList<T> : IList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int size;

        public delegate void ListEventHandler(object obj,ListEventArgs<T> args);
        
        public event ListEventHandler ElementAdded;
        public event ListEventHandler ElementRemoved;
        public event ListEventHandler ListCleared;

        /// <summary>
        /// This property sets or gets number on index in CustomList
        /// </summary>
        /// <param name="index">index of item</param>
        /// <exception cref="IndexOutOfRangeException">Throws when item less then 0 and bigger then size of CustomList</exception>
        public T this[int index]
        {
            get
            {
                Node<T> current = head;

                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current.Data;
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                Node<T> current = head;

                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                current.Data = value;
                ElementAdded?.Invoke(this, new ListEventArgs<T>(value,"Element Added"));
            }
        }

        /// <summary>
        /// This property returns size of CustomList
        /// </summary>
        /// <returns>
        /// size of CustomList
        /// </returns>
        public int Count { get { return size; } }

        public bool IsReadOnly => false;

        /// <summary>
        /// This constructor create new CustomList from params
        /// </summary>
        /// <param name="values">array of objects</param>
        public CustomList(params T[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in values)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// This constructor create new CustomList from IEnumerable
        /// </summary>
        /// <param name="values">IEnumerable of objects</param>
        public CustomList(IEnumerable<T> values)
        {
            foreach (var item in values)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// This property adds object to CustomList
        /// </summary>
        /// <param name="item">Object that should be added in the CustomList</param>
        /// <exception cref="ArgumentNullException">Throws when you try to add null</exception>
        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            Node<T> node = new Node<T>(item);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;
            size++;
            ElementAdded?.Invoke(this, new ListEventArgs<T>(item, "Element Added"));
        }


        /// <summary>
        /// This property clears CustomList
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
            ListCleared?.Invoke(this, new ListEventArgs<T>("ListCleared"));
        }


        /// <summary>
        /// This property checks if item contains in CustomList
        /// </summary>
        /// <param name="item">Object which must be finded in CustomList</param>
        /// <exception cref="ArgumentNullException">Throws when you try to add null</exception>
        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Copies CustomList to one-dimensional array, starting from specified index
        /// </summary>
        /// <param name="array">array which we are filling from CustomList</param>
        /// <param name="arrayIndex">starting index of array for copying</param>
        /// <exception cref="ArgumentNullException">Throws when you try to copy in null</exception>
        /// <exception cref="ArgumentException">Throws when you try to copy in null</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = head;
            int notifyIndex = arrayIndex;
            if (array == null)
                throw new ArgumentNullException();

            if (arrayIndex < 0 || arrayIndex + size > array.Length)
                throw new ArgumentException();



            while (current != null)
            {
                array[arrayIndex] = current.Data;
                current = current.Next;
                arrayIndex++;
            }
        }

        /// <summary>
        /// Returns enumerator that iterate throught CustomList
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Checks index of item in CustomList
        /// </summary>
        /// <param name="item">object which we must find in CustomList</param>
        /// <returns>Index of item if it consists or -1 if it doesn't</returns>
        /// <exception cref="ArgumentNullException">Throws when you try to find null</exception>
        public int IndexOf(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            Node<T> current = head;
            int index = 0;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }
            return -1;
        }

        /// <summary>
        /// Adds object to specified index of CustomList
        /// </summary>
        /// <param name="index">index where we must insert object</param>
        /// <param name="item">object which we must insert</param>
        /// <exception cref="ArgumentNullException">Throws when you try insert null</exception>
        /// <exception cref="IndexOutOfRangeException">Throws when item less then 0 and bigger then size</exception>
        public void Insert(int index, T item)
        {
            Node<T> newNode = new Node<T>(item);
            Node<T> current = head;
            Node<T> previous = null;

            if (index < 0 || index > size)
                throw new IndexOutOfRangeException();

            if (item == null)
                throw new ArgumentNullException();


            for (int currentIndex = 0; currentIndex <= index; currentIndex++)
            {
                if (currentIndex == index)
                {
                    if (previous != null)
                    {
                        previous.Next = newNode;
                        newNode.Next = current;
                        size++;
                    }
                    else
                    {
                        newNode.Next = current;
                        head = newNode;
                    }
                    ElementAdded?.Invoke(this, new ListEventArgs<T>(item, "ElementAdded"));
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }


        /// <summary>
        /// This property removes object from CustomList
        /// </summary>
        /// <param name="item">Object which should be removed from the CustomList</param>
        /// <exception cref="ArgumentNullException">Throws when you try remove null</exception>
        /// <returns>Index true if item removed or false if it doesn't</returns>
        public bool Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            Node<T> previous = null;
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        if (head.Next != null)
                        {
                            head = head.Next;
                        }
                        else
                        {
                            head = null;
                            tail = null;
                        }
                    }
                    size--;
                    ElementRemoved?.Invoke(this, new ListEventArgs<T>(item, "Element Removed"));
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// This property removes object at index from CustomList
        /// </summary>
        /// <param name="index">Index of object which should be removed from the CustomList</param>
        /// <exception cref="IndexOutOfRangeException">Throws when item less then 0 and bigger then size</exception>
        public void RemoveAt(int index)
        {
            Node<T> current = head;
            Node<T> previous = null;

            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            for (int currentIndex = 0; currentIndex <= index; currentIndex++)
            {
                if (currentIndex == index)
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        if (head.Next != null)
                        {
                            head = head.Next;
                        }
                        else
                        {
                            head = null;
                            tail = null;
                        }
                    }
                    size--;
                    ElementRemoved?.Invoke(this, new ListEventArgs<T>(current.Data, "Element Removed"));
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
