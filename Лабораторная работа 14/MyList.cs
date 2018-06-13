using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    class MyList<T> : IEnumerable, ICloneable
    {
        private Node<T> root;
        private int _count;
        private int _capacity;

        public MyList()
        {
            Capacity = 0;
            Count = 0;
            root = null;
        }

        public MyList(int capacity)
        {
            Capacity = capacity;
            Count = 0;
            root = null;
        }

        public MyList(MyList<T> c)
        {
            Capacity = c.Capacity;
            Count = c.Count;
            Node<T> firstElement = (Node<T>) c[0];
            root = new Node<T>(firstElement.Data);
            Node<T> pointer = root;
            bool skipFirst = true;
            foreach (Node<T> node in c)
            {
                if (skipFirst)
                {
                    skipFirst = false;
                    continue;
                }

                Node<T> newElement = new Node<T>(node.Data);
                pointer.Next = newElement;
                pointer = newElement;
            }
        }

        public int Capacity
        {
            get => _capacity;
            set => _capacity = value;
        }

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                if (Count > Capacity)
                    Capacity++;
            }
        }

        //Item
        public object this[int index]
        {
            get
            {
                //if (index > Count - 1)
                //    throw new ArgumentOutOfRangeException();
                if (index < 0)
                    throw new ArgumentOutOfRangeException();
                int counter = 0;
                foreach (Node<T> element in this)
                {
                    if (counter != index)
                        counter++;
                    else
                        return element;
                }

                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException();
                int counter = 0;
                foreach (Node<T> element in this)
                {
                    if (counter != index)
                        counter++;
                    else
                        element.Data = (T) value;
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public void Add(T value)
        {
            if (Count == 0)
            {
                Count++;
                root = new Node<T>(value);
                return;
            }

            Node<T> element = root;
            while (element.Next != null)
                element = element.Next;

            Node<T> newElement = new Node<T>(value);

            element.Next = newElement;
            Count++;
        }

        //Работает только с отсортированной коллекцией
        public int BinarySearch(T value, IComparer comparer)
        {
            T[] arr = new T[this.Count];
            int i = 0;
            foreach (Node<T> element in this)
                arr[i++] = element.Data;

            return Array.BinarySearch(arr, comparer);
        }

        public void Sort(IComparer comparer)
        {
            T[] arrToSort = new T[this.Count];
            int i = 0;
            foreach (Node<T> element in this)
                arrToSort[i++] = element.Data;

            Array.Sort(arrToSort, comparer);

            Node<T> sortedRoot = new Node<T>(arrToSort[0]);
            Node<T> sortedElement = sortedRoot;
            foreach (T element in arrToSort)
            {
                sortedElement.Next = new Node<T>(element);
                sortedElement = sortedElement.Next;
            }

            root = sortedRoot;
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public object Clone()
        {
            MyList<T> clonedList = new MyList<T>(Capacity);
            clonedList.Count = Count;
            clonedList.root = root;
            return clonedList;
        }

        public void Insert(int index, T value)
        {
            Node<T> newElement = new Node<T>(value);
            if (Count == 0 && index == 0)
            {
                root = newElement;
                Count++;
            }
            else if (index == 0)
            {
                newElement.Next = root;
                root = newElement;
                Count++;
            }
            else if (index < Count && index > 0)
            {
                int indexCounter = 1;
                Node<T> pointer = root;
                while (indexCounter - 1 != index)
                {
                    indexCounter++;
                    pointer = pointer.Next;
                }

                newElement.Next = pointer.Next;
                pointer.Next = newElement;
                Count++;
            }
            else if (index == Count)
                this.Add(value);
            else if (index > Count || index < 0)
                throw new ArgumentOutOfRangeException();
        }

        public int IndexOf(T value)
        {
            int index = 0;
            foreach (Node<T> element in this)
            {
                if (element.Data.Equals(value))
                    return index;
                index++;
            }

            return -1;
        }

        public int LastIndexOf(T value)
        {
            int index = -1, indexCounter = 0;
            foreach (Node<T> element in this)
            {
                if (element.Data.Equals(value))
                    index = indexCounter;
                indexCounter++;
            }

            return index;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count - 1)
                throw new ArgumentOutOfRangeException();
            if (index == 0)
            {
                root = root.Next;
                Count--;
            }
            else if (index < Count && index > 0)
            {
                int indexCounter = 1;
                foreach (Node<T> element in this)
                {
                    if (indexCounter - 1 == index)
                    {
                        if (index == Count - 1)
                        {
                            element.Next = null;
                            break;
                        }

                        element.Next = element.Next.Next;
                    }

                    indexCounter++;
                }
            }
            else if (index == 0 && Count == 1)
                root = null;

            Count--;
        }

        public void Remove(T value)
        {
            if (root.Data.Equals(value) && Count == 1)
                root = null;
            else
            {
                foreach (Node<T> element in this)
                {
                    if (element.Next.Data.Equals(value))
                    {
                        element.Next = element.Next.Next ?? null;
                        //if (element.Next.Next != null)
                        //    element.Next = element.Next.Next;
                        //else
                        //    element.Next = null;
                    }
                }
            }
        }

        public void Reverse()
        {
            Node<T>[] arr = new Node<T>[this.Count];
            int i = 0;
            foreach (Node<T> element in this)
                arr[i++] = element;
            Node<T> reversedRoot = new Node<T>(arr[arr.Length - 1].Data);
            Node<T> reversedElement = reversedRoot;
            for (int j = arr.Length - 2; j < -1; j--)
            {
                reversedElement.Next = arr[j];
                reversedElement = reversedElement.Next;
            }

            reversedElement.Next = null;
            root = reversedRoot;
        }


        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return (IEnumerator)GetEnumerator();
        //}
        //public MyListEnum<T> GetEnumerator()
        //{
        //    return new MyListEnum<T>(root);
        //}

        public IEnumerator GetEnumerator()
        {
            Node<T> node = root;
            while (node != null)
            {
                yield return node.Data;
                node = node.Next;
            }


        }
    }
}
