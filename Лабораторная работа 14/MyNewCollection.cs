using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    class MyNewCollection 
    {
        private static Random rand = new Random();
        public MyCollection collection;

        public MyNewCollection(string name, int size)
        {
            Name = name;
            collection = new MyCollection(size);
        }
        public string Name { get; set; }

        public bool Remove(int index)
        {
            if (index > collection.Count || index < 0)
                return false;
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Deleted element", collection[index]));
            collection.RemoveAt(index);
            return true;
        }

        public void AddDefault()
        {
            Transport newElement = new Car(Transport.RandomString(8), rand.Next(100, 250),
                rand.Next(1, 15), rand.Next(1, 3),
                rand.Next(100, 200), Transport.RandomString(8));
            Add(newElement);
        }
        public void Add(Transport newElement)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Added element", newElement));
            collection.Add(newElement);
        }

        public object this[int index]
        {
            get { return collection[index]; }
            set
            {
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, $"Reference changed, index: {index}", value));
                collection[index] = (Transport)value;
            }
        }

        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionCountChanged?.Invoke(source, args);
        }

        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionReferenceChanged?.Invoke(source, args);
        }
    }

    class CollectionHandlerEventArgs : System.EventArgs
    {
        public string Name { get; set; }
        public string Change { get; set; }
        public object Obj { get; set; }

        public CollectionHandlerEventArgs(string name, string change, object obj)
        {
            Name = name;
            Change = change;
            Obj = obj;
        }

        public override string ToString()
        {
            return String.Format("Name = {0}, Change = {1}", Name, Change);
        }
    }
}
