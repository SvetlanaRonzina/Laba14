using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Лабораторная_работа_14
{
    class MyCollection : List<Transport>, IEnumerable
    {
        public List<Transport> collection;
        private static Random rand = new Random();

        public MyCollection(int size)
        {
            collection = new List<Transport>(size);
            CreateRandomCollection(size);
        }

        public void CreateRandomCollection(int size)
        {
            for (int i = 0; i < size; i++)
                if (i % 3 == 0)
                    collection.Add(new Car(Transport.RandomString(8), rand.Next(100, 250),
                        rand.Next(1, 15), rand.Next(1, 3),
                        rand.Next(100, 200), Transport.RandomString(8)));
                else if (i % 3 == 1)
                    collection.Add(new Train(Transport.RandomString(8), rand.Next(100, 250),
                        rand.Next(1, 15), rand.Next(4, 20)));
                else
                    collection.Add(new Express(Transport.RandomString(8), rand.Next(100, 250),
                        rand.Next(1, 15),
                        rand.Next(4, 20), rand.Next(300, 600)));
        }

        public int Count
        {
            get { return collection.Count; }
        }

        public new virtual void Add(Transport newElement)
        {
            collection.Add(newElement);
        }

        public new void Remove(Transport element)
        {
            collection.Remove(element);
        }

        public new void RemoveAt(int index)
        {
            collection.RemoveAt(index);
        }

        public new void Sort(IComparer<Transport> comparer)
        {
            collection.Sort(comparer);
        }

        public int Length
        {
            get => collection.Count;
        }

        public void Clear()
        {
            collection.Clear();
        }

        public new IEnumerator GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
                yield return collection[i];
        }

        public new Transport this[int index]
        {
            get => collection[index];
            set => collection[index] = value;
        }

    }
}
