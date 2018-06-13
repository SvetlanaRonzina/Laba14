using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_14
{
    public class Car : Transport, ICloneable
    {
        protected string engineType;
        protected int power;
        protected string company;

        public Car()
        {

            engineType = string.Empty;
            power = 0;
            company = string.Empty;
        }

        public Car(string name, double averageSpeed, int count, int engineType, int power, string company)
        {
            this.name = name;
            this.averageSpeed = averageSpeed;
            this.count = count;
            this.engineType = engineType == 1 ? "Бензиновый" : "Дизельный";
            this.power = power;
            this.company = company;
        }

        public override void Show()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Название транспорта: {0}\nСредняя скорость: {1}\nКоличество: {2}", name, averageSpeed,
                count);
            Console.WriteLine(
                "Тип транспорта: автомобиль\nНазвание машины: {0}\nТип двигателя: {1}\nМощность двигателя: {2}\nОрганизация: {3}",
                name, engineType, power, company);
            Console.WriteLine("---------------------------------------------");
        }

        public static int CarCountInPark(IEnumerable arr, string carName, string companyName)
        {
            int count = 0;
            switch (arr)
            {
                case Hashtable _:
                    foreach (DictionaryEntry element in arr)
                        if (element.Value is Car car && car.name == carName && car.company == companyName)
                            count++;

                    break;

                case Queue<ITransport> normalArr:
                    for (int i = 0; i < normalArr.Count; i++)
                    {
                        Transport obj = (Transport)normalArr.Dequeue();
                        if (obj is Car car && car.name == carName && car.company == companyName)
                            count++;
                        normalArr.Enqueue(obj);
                    }

                    break;

            }

            return count;
        }

        public static double AveragePower(IEnumerable arr, string carName)
        {
            double power = 0;
            int count = 0;
            switch (arr)
            {
                case Hashtable _:
                    foreach (DictionaryEntry element in arr)
                    {
                        Car car = element.Value as Car;
                        if (car != null)
                            if (carName == car.name)
                            {
                                power += car.power;
                                count++;
                            }
                    }

                    break;
                case Queue<ITransport> normalArr:
                    for (int i = 0; i < normalArr.Count; i++)
                    {
                        if (normalArr.Dequeue() is Car car)
                        {
                            if (carName == car.name)
                            {
                                power += car.power;
                                count++;
                            }
                            normalArr.Enqueue(car);
                        }
                    }

                    break;
            }

            return power / count;
        }

        public override object Clone()
        {
            return new Car("(Клон)" + name, averageSpeed, count, 1, power, company);
        }

        public override ITransport ShallowCopy()
        {
            return (Car)MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Название: {Name}, Количество: {Count}, Средняя скорость: {AverageSpeed}, Двигатель: {engineType}, Мощность (л.с): {power}, Компания: {company}";
        }
    }
}
