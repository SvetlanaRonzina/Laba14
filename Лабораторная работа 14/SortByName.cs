using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    public class SortByName : IComparer<Transport>
    {
        //int IComparer.Compare(object ob1, object ob2)
        //{
        //    Transport tr1 = (Transport) ob1;
        //    Transport tr2 = (Transport) ob2;
        //    return String.Compare(tr1.Name, tr2.Name);
        //}

        public int Compare(Transport x, Transport y)
        {
            return String.Compare(x.Name, y.Name);
        }
    }
}
