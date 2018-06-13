using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    public interface ITransport : ICloneable, IComparable
    {
        void Show();

        ITransport ShallowCopy();
    }
}
