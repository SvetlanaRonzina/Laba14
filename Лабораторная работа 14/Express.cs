using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    public class Express : Train
    {
        private int passengers;

        public Express()
        {
            passengers = 0;
        }

        public Express(string name, double averageSpeed, int count, int wagonCount, int passengers) : base(name, averageSpeed, count, wagonCount)
        {
            this.passengers = passengers;
        }

        public Train BaseTrain
        {
            get { return new Train(name, averageSpeed, count, wagonCount); }
        }

        public override void Show()
        {
            Console.WriteLine("---------------------------------------------");
            base.Show();
            Console.WriteLine("Тип поезда: экспресс\nКоличество пассажиров: {0}", passengers);
            Console.WriteLine("---------------------------------------------");
        }

        public static int PassengersCount(IEnumerable arr, out int wagons)
        {
            int passengers = 0;
            wagons = 0;
            switch (arr)
            {
                case Hashtable _:
                    foreach (DictionaryEntry element in arr)
                    {
                        if (element.Value is Express express)
                        {
                            passengers += express.passengers;
                            wagons += express.wagonCount;
                        }
                    }
                    break;
                case Queue<ITransport> normalArr:
                    for (int i = 0; i < normalArr.Count; i++)
                    {
                        Transport obj = (Transport)normalArr.Dequeue();
                        if (obj is Express express)
                        {
                            passengers += express.passengers;
                            wagons += express.wagonCount;
                        }
                        normalArr.Enqueue(obj);
                    }

                    break;
            }
            

            return passengers;
        }

        public Express ShallowCopy()
        {
            return (Express)MemberwiseClone();
        }

        public override object Clone()
        {
            return new Express("(Клон)" + name, averageSpeed, count, wagonCount, passengers);
        }

        public override string ToString()
        {
            return
                $"Название: {name}, Средняя скорость: {averageSpeed}, Количество: {count}, Количество вагонов: {wagonCount}, Количество пассажиров: {passengers}";

        }
    }
}
