using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsole;

namespace Лабораторная_работа_14
{
    class Part2
    {
        private static Random rand = new Random();
        public static MyNewCollection collection1, collection2;
        public static Journal journal1, journal2;
        private static bool isCreated = false;

        public static void MainMenu()
        {
            Console.Clear();
            Menu menu = new Menu()
                .Add("Создать две коллекции", CreateCollections)
                .Add("Вывести коллекцию", PrintCollection)
                .Add("Добавить элемент в коллекцию", AddElement)
                .Add("Удалить элемент из коллекции", DeleteElement)
                .Add("Присвоить новое значение", ChangeReference)
                .Add("Вывести Journal", PrintJournal)
                .Add("Выйти из программы", ExitProgram);
            menu.Display();
        }

        public static void CreateCollections()
        {
            Console.Clear();
            int size1 = Input.ReadInt("Введите размер первой коллекции: ", 10, 100000);
            string name1 = Input.ReadString("Введите имя первой коллекции: ");
            int size2 = Input.ReadInt("Введите размер второй коллекции: ", 10, 100000);
            string name2 = Input.ReadString("Введите имя второй коллекции: ");
            collection1 = new MyNewCollection(name1, size1);
            collection2 = new MyNewCollection(name2, size2);
            journal1 = new Journal();
            journal2 = new Journal();
            collection1.CollectionCountChanged += new MyNewCollection.CollectionHandler(journal1.CollectionCountChanged);
            collection1.CollectionReferenceChanged += new MyNewCollection.CollectionHandler(journal1.CollectionReferenceChanged);

            collection1.CollectionReferenceChanged += new MyNewCollection.CollectionHandler(journal2.CollectionReferenceChanged);
            collection2.CollectionReferenceChanged += new MyNewCollection.CollectionHandler(journal2.CollectionReferenceChanged);

            isCreated = true;
            MainMenu();

        }

        public static void AddElement()
        {
            Console.Clear();
            if (isCreated)
            {
                int num = Input.ReadInt("В какую коллекцию добавить элемент?: ", 1, 2);
                MyNewCollection collection;
                collection = num == 1 ? collection1 : collection2;

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
            }
            MainMenu();
        }

        public static void DeleteElement()
        {
            Console.Clear();
            if (isCreated)
            {
                int num = Input.ReadInt("Из какой коллекции удалить элемент?: ", 1, 2);
                MyNewCollection collection;
                if (num == 1)
                    collection = collection1;
                else
                    collection = collection2;

                Console.Write("Введите индекс элемента: ");
                int index = Input.ReadInt(0, collection.collection.Length);
                collection.Remove(index);
            }

            MainMenu();
        }

        public static void ChangeReference()
        {
            Console.Clear();
            if (isCreated)
            {
                Transport newElement = new Car("Новый элемент!", rand.Next(100, 250),
                    rand.Next(1, 15), rand.Next(1, 3),
                    rand.Next(100, 200), Transport.RandomString(8));
                collection1[0] = newElement;
                collection2[1] = newElement;
                Console.WriteLine("Элементу collection[0] первой коллекции присвоено новое значение.");
                Console.WriteLine("Элементу collection[1] второй коллекции присвоено новое значение.");
                Console.ReadLine();
            }
            MainMenu();
        }

        public static void PrintJournal()
        {
            Console.Clear();
            if (isCreated)
            {
                int num = Input.ReadInt("Введите номер журнала, который хотите посмотреть: ", 1, 2);
                Journal journal;
                if (num == 1)
                    journal = journal1;
                else
                    journal = journal2;
                if (journal.journal.Count != 0)
                {
                    foreach (JournalEntry entry in journal)
                        Console.WriteLine(entry.ToString());
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Журнал пуст!");
                    Console.ReadLine();
                }
            }
            MainMenu();
        }

        public static void PrintCollection()
        {
            if (isCreated)
            {
                int num = Input.ReadInt("Какую коллекцию хотите просмотреть?: ", 1, 2);
                MyNewCollection collection;
                if (num == 1)
                    collection = collection1;
                else
                    collection = collection2;

                Console.Clear();
                Console.WriteLine("Количество элементов в коллекции: {0}", collection.collection.Length);
                foreach (Transport transport in collection.collection)
                    transport.Show();

                Console.ReadLine();
            }
            MainMenu();
        }
        private static void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}
