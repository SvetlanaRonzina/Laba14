using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    class Node<T>
    {
        private T _data;
        private Node<T> _next;

        public T Data
        {
            get => _data;
            set => _data = value;
        }

        public Node<T> Next
        {
            get => _next;
            set => _next = value;
        }

        public Node()
        {
            Data = default(T);
            Next = null;
        }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
