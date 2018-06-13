using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    public class Train : Transport
    {
        protected int wagonCount;

        public Train()
        {
            wagonCount = 0;
        }

        public Train(string name, double averageSpeed, int count, int wagonCount)
        {
            this.name = name;
            this.averageSpeed = averageSpeed;
            this.count = count;
            this.wagonCount = wagonCount;
        }

        public override void Show()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Название транспорта: {0}\nСредняя скорость: {1}\nКоличество: {2}", name, averageSpeed, count);
            Console.WriteLine("Тип транспорта: поезд\nКоличество вагонов: {0}", wagonCount);
        }

        public override object Clone()
        {
            return new Train("(Клон)" + name, averageSpeed, count, wagonCount);
        }

        public override ITransport ShallowCopy()
        {
            return (ITransport)MemberwiseClone();
        }

        public override string ToString()
        {
            return
                $"Название: {name}, Средняя скорость: {averageSpeed}, Количество: {count}, Количество вагонов: {wagonCount}";
            //return Name;
        }

    }
}
