using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Лабораторная_работа_14
{
    public abstract class Transport : ITransport, ICloneable
    {
        private static Random random = new Random();
        protected string name;
        protected double averageSpeed;
        protected int count;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public double AverageSpeed => averageSpeed;
        public int Count => count;

        public abstract void Show();
        public abstract object Clone();
        public abstract ITransport ShallowCopy();
        public int CompareTo(object obj)
        {
            Transport cur = (Transport)obj;
            if (cur.count > this.count)
                return 1;
            if (cur.count < this.count)
                return -1;
            return 0;
        }
        //public static Transport[] CreateRandomData(int size)
        //{
        //    Random rand = new Random();
        //    StreamReader trainNamesStream = new StreamReader("trainNames.txt", Encoding.GetEncoding(1251));
        //    StreamReader carNamesStream = new StreamReader("carNames.txt", Encoding.GetEncoding(1251));
        //    StreamReader companyNamesStream = new StreamReader("companyNames.txt", Encoding.GetEncoding(1251));

        //    string[] trainNames = trainNamesStream.ReadToEnd().Split(' ');
        //    trainNames[trainNames.Length - 1] = trainNames[trainNames.Length - 1].Replace('\r', '\0');
        //    trainNames[trainNames.Length - 1] = trainNames[trainNames.Length - 1].Replace('\n', '\0');

        //    string[] carNames = carNamesStream.ReadToEnd().Split(' ');
        //    carNames[carNames.Length - 1] = carNames[carNames.Length - 1].Replace('\r', '\0');
        //    carNames[carNames.Length - 1] = carNames[carNames.Length - 1].Replace('\n', '\0');

        //    string[] companyNames = companyNamesStream.ReadToEnd().Split(' ');
        //    companyNames[companyNames.Length - 1] = companyNames[companyNames.Length - 1].Replace('\r', '\0');
        //    companyNames[companyNames.Length - 1] = companyNames[companyNames.Length - 1].Replace('\n', '\0');


        //    Transport[] arr = new Transport[size];
        //    for (int i = 0; i < size; i++)
        //        while (true)
        //            try
        //            {
        //                if (i % 3 == 0)
        //                    arr[i] = new Car(carNames[rand.Next(0, carNames.Length)], rand.Next(100, 250),
        //                        rand.Next(1, 15), rand.Next(1, 3),
        //                        rand.Next(100, 200), companyNames[rand.Next(0, 24)]);
        //                else if (i % 3 == 1)
        //                    arr[i] = new Train(trainNames[rand.Next(0, trainNames.Length)], rand.Next(100, 250),
        //                        rand.Next(1, 15), rand.Next(4, 20));
        //                else
        //                    arr[i] = new Express(trainNames[rand.Next(0, trainNames.Length)], rand.Next(100, 250),
        //                        rand.Next(1, 15),
        //                        rand.Next(4, 20), rand.Next(300, 600));

        //                break;
        //            }
        //            //Если такой элемент уже есть
        //            catch (ArgumentException)
        //            {
        //            }

        //    return arr;
        //}
        public override int GetHashCode()
        {
            int hash = 0;
            foreach(char letter in name)
                hash += (int)letter;

            //return hash + count;
            return hash;
        }
        public Transport(string name, int count)
        {
            this.name = name;
            this.count = count;
        }
        public Transport()
        {
            name = string.Empty;
            count = 0;
        }

        public override bool Equals(object obj)
        {
            Transport eq = (Transport) obj;
            return this.Name == eq.Name;
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public override string ToString()
        {
            return $"Название: {Name}, Количество: {Count}, Средняя скорость: {AverageSpeed}";
        }
    }
}
