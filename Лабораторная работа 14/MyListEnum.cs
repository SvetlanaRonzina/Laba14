using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    class MyListEnum<T> : IEnumerator
    {
        public Node<T> current;
        private Node<T> root;

        public MyListEnum(Node<T> current)
        {
            this.current = current;
            root = current;
        }
        public object Current
        {
            get => current.Data;
        }
        public bool MoveNext()
        {
            current = current.Next;
            return current != null;
        }

        public void Reset()
        {
            current = root;
        }
    }
}
