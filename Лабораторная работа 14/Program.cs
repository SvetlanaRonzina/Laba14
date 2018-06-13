using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsole;

namespace Лабораторная_работа_14
{
    class Program
    {
        private static MyCollection collection;
        static void Main()
        {
            Console.Clear();
            Menu menu = new Menu()
                .Add("Создать коллекцию", CreateCollection)
                .Add("Просмотреть коллекцию", DisplayCollection)
                .Add("Добавить элемент", AddElement)
                .Add("Удалить элемент", DeleteElement)
                .Add("Отсортировать элементы по имени", SortCollection)
                .Add("Очистить коллекцию", ClearCollection)
                .Add("Перейти ко второй задаче", GoToPart2);
            menu.Display();
        }

        private static void CreateCollection()
        {
            Console.Clear();
            Console.Write("Введите количество элементов в коллекции: ");
            int size = Input.ReadInt(min: 1);
            collection = new MyCollection(size);
            Main();
        }

        private static void DisplayCollection()
        {
            Console.Clear();
            Console.WriteLine("Количество элементов в коллекции: {0}", collection.Length);
            foreach (Transport transport in collection)
                transport.Show();

            Console.ReadLine();
            Main();
        }

        private static void AddElement()
        {
            Console.Clear();
            Console.WriteLine("Выберите тип транспорта, который хотите создать:");
            Console.WriteLine("1. Автомобиль");
            Console.WriteLine("2. Поезд");
            Console.WriteLine("3. Экспресс");
            int input = int.Parse(Console.ReadLine());

            Console.Write("Введите название транспорта: ");
            string name = Console.ReadLine();

            Console.Write("Введите количество транспорта: ");
            int count = int.Parse(Console.ReadLine());

            Console.Write("Введите среднюю скорость: ");
            double averageSpeed = double.Parse(Console.ReadLine());

            int wagonCount;

            switch (input)
            {
                //Создание автомобиля
                case 1:
                    Console.WriteLine("Выберите тип двигателя:");
                    Console.WriteLine("1. Бензиновый");
                    Console.WriteLine("2. Дизельный");
                    int engineType = int.Parse(Console.ReadLine());

                    Console.Write("Введите мощность двигателя: ");
                    int power = int.Parse(Console.ReadLine());

                    Console.Write("Введите название компании-владельца: ");
                    string company = Console.ReadLine();

                    Car newCar = new Car(name, averageSpeed, count, engineType, power, company);
                    collection.Add(newCar);

                    break;

                //Создание поезда
                case 2:
                    Console.Write("Введите количество вагонов: ");
                    wagonCount = int.Parse(Console.ReadLine());

                    Train newTrain = new Train(name, averageSpeed, count, wagonCount);
                    collection.Add(newTrain);

                    break;

                //Создание экспресса
                case 3:
                    Console.Write("Введите количество вагонов: ");
                    wagonCount = int.Parse(Console.ReadLine());

                    Console.Write("Введите максимальное количество пассажиров: ");
                    int passengers = int.Parse(Console.ReadLine());

                    Express newExpress = new Express(name, averageSpeed, count, wagonCount, passengers);

                    collection.Add(newExpress);

                    break;
            }
            Main();
        }

        private static void DeleteElement()
        {
            Console.Clear();
            Console.WriteLine("Выберите как нужно удалять:");
            Console.WriteLine("1. По индексу");
            Console.WriteLine("2. По имени транспорта");
            int input = Input.ReadInt(1, 2);
            switch (input)
            {
                case 1:
                    Console.Write("Введите индекс элемента: ");
                    int index = Input.ReadInt(0, collection.Length);
                    collection.RemoveAt(index);
                    break;
                case 2:
                    Console.Write("Введите имя транспорта, который хотите удалить: ");
                    string nameToDelete = Console.ReadLine();

                    Car elementToDelete = new Car { Name = nameToDelete };

                    collection.Remove(elementToDelete);

                    break;
            }
            Main();
        }

        private static void SortCollection()
        {
            Console.Clear();
            collection.Sort(new SortByName());
            Console.WriteLine("Коллекция отсортирована!");
            Console.ReadLine();
            Main();
        }

        private static void ClearCollection()
        {
            Console.Clear();
            collection.Clear();
            Console.WriteLine("Коллекция очищена!");
            Console.ReadLine();
            Main();
        }


        private static void GoToPart2()
        {
            Part2.MainMenu();
        }
    }
}
