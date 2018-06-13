using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    public class SortByAvgSpeed :IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Transport tr1 = (Transport) obj1;
            Transport tr2 = (Transport) obj2;
            if (tr1.AverageSpeed > tr2.AverageSpeed)
                return 1;
            if (tr1.AverageSpeed < tr2.AverageSpeed)
                return -1;
            return 0;
        }
    }
}
