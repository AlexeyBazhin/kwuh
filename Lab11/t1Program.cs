using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10;

namespace Task1
{
    class t1Program
    {
        public static ArrayList list = new ArrayList();
        static void Main(string[] args)
        {
            list.Add(new Person("Иван", 18));            
            list.Add(new Employee("Петр", 58, "Официант", 30));
            list.Add(new Worker("Антон", 25, "Копатель", "12 - Б"));
            list.Add(new Engineer("Валера", 54, "Инженер", "12 - Б", "Инженер-проектировщик", 3));
            list.Add(new Employee("Дмитрий_1", 35, "Почтальон", 11));
            list.Add(new Worker("Антон_3", 35, "Сантехник", "12 - Б"));
            list.Add(new Employee("Дмитрий_2", 35, "Почтальон", 12));
            list.Add(new Engineer("Валера_2", 31, "Инженер", "15 - Г", "Заместитель", 5));
            list.Add(new Worker("Антон_2", 35, "Копатель", "11d"));
            list.Add(new Employee("Дмитрий_3", 35, "Почтальон", 17));
            list.Add(new Engineer("Валера_3", 23, "Инженер", "12 - Б", "Младший инженер", 1));
            list.Add(new Person("Я", 22));
            list.Add(new Employee("Дмитрий_4", 35, "Почтальон", 1));
            list.Add(new Employee("Дмитрий_5", 35, "Почтальон", 23));
            
            int menuItem;
            PrintMenu();
            do
            {
                Console.WriteLine();
                if (list.Count != 0)
                    menuItem = intInput("пункт меню", 0, 9);
                else
                {
                    Console.WriteLine("Коллекция пустая! Добавьте элементы.");
                    menuItem = intInput("пункт меню", 0, 1);
                }
                switch (menuItem)
                {
                    case 1://добавить элемент
                        {
                            Console.Clear();
                            Console.WriteLine("Добавить элемент\n");
                            list.Add(ChooseElem());
                            Console.WriteLine("Элемент успешно добавлен, нажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            PrintMenu();
                            break;
                        }
                    case 2://удалить элемент
                        {
                            int delIndex = intInput("номер удаляемого элемента", 1, list.Count);
                            list.RemoveAt(--delIndex);
                            PrintMenu();
                            break;
                        }
                    case 3://Запрос: Имена служащих со стажем не менее заданного
                        {
                            Console.WriteLine("\nПоиск имен служащих, имеющих стаж не менее заданного");
                            int userExp = intInput("стаж", 0, 86);
                            foreach(var element in list)
                            {
                                Employee obj = element as Employee;
                                if (obj != null && obj.experience >= userExp)
                                    Console.WriteLine(obj.name);
                            }
                            break;
                        }
                    case 4://Запрос: Количество инженеров
                        {
                            Console.WriteLine("\nПодсчет кол-ва инженеров:");
                            int engsCount = 0;
                            foreach (var element in list)
                                if (element is Engineer)
                                    ++engsCount;
                            Console.WriteLine(engsCount);
                            break;
                        }
                    case 5://Запрос: Количество работающих в заданном цехе
                        {
                            Console.WriteLine("\nПодсчет кол-ва работающих в цехе:");
                            int facFloorCount = 0;
                            Console.Write("Введите номер цеха:");
                            string factoryFloor = Console.ReadLine();
                            foreach (var element in list)
                            {
                                Worker obj = element as Worker;
                                if (obj != null && obj.factoryFloor == factoryFloor)
                                    ++facFloorCount;
                            }
                            Console.WriteLine(facFloorCount);
                            break;
                        }
                    case 6://клонирование коллекции
                        {                            
                            ArrayList listClone = (ArrayList)list.Clone();
                            Console.WriteLine("\nСклонированная коллекция:\n");
                            PrintCollection(listClone);
                            Console.WriteLine("\nУдалим первый объект из клона:\n");
                            listClone.RemoveAt(0);
                            PrintCollection(listClone);
                            Console.WriteLine("\nИзначальная коллекция:\n");
                            PrintCollection(list);
                            Console.WriteLine("\nПроведено полное клонирование.\n");
                            break;
                        }
                    case 7://сортировка по имени через IComparable
                        {
                            list.Sort();
                            PrintMenu();
                            break;
                        }
                    case 8://сортировка по возрасту через IComparer
                        {
                            list.Sort(new SortByAge());
                            PrintMenu();
                            break;
                        }
                    case 9://найти элемент
                        {
                            int searchIndex = list.IndexOf(ChooseElem());
                            if (searchIndex != -1)
                                Console.WriteLine("\nНайденный элемент стоит под номером:{0}", ++searchIndex);
                            break;
                        }
                }
            } while (menuItem != 0);
        }
        static void PrintCollection(ArrayList list)
        {
            int count = 0;
            foreach (Person obj in list)
            {
                Console.Write($"{++count}) ");
                obj.RightShow();
            }
        }
        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Задание 1. Коллекция ArrayList\n");
            Console.WriteLine("Текущая коллекция:");
            PrintCollection(list);
            Console.WriteLine("Меню:");
            Console.WriteLine("\n1) Добавить элемент");
            Console.WriteLine("2) Удалить элемент");
            Console.WriteLine("3) Запрос: Имена служащих со стажем не менее заданного");
            Console.WriteLine("4) Запрос: Количество инженеров");
            Console.WriteLine("5) Запрос: Количество работающих в заданном цехе");
            Console.WriteLine("6) Клонировать коллекцию");
            Console.WriteLine("7) Отсортировать по имени");
            Console.WriteLine("8) Отсортировать по возрасту");
            Console.WriteLine("9) Найти элемент");
            Console.WriteLine("0) Выход из программы");
        }
        static Person ChooseElem()
        {
            Console.WriteLine("1) Персона");
            Console.WriteLine("2) Служащий(насл. Персона)");
            Console.WriteLine("3) Рабочий(насл. Персона)");
            Console.WriteLine("4) Инженер(насл. Рабочий)");

            int menuItem;
            menuItem = intInput("класс (пункты 1-4)", 1, 4);

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            int age = intInput("возраст", 14, 100);
            Person elem = new Person(name, age);
            string prof;
            int exp;
            string factoryFloor;
            string type;
            int grade;
            switch (menuItem)
            {
                case 2:
                    Console.Write("Введите профессию: ");
                    prof = Console.ReadLine();
                    exp = intInput("стаж работы", 0, age - 14);
                    elem = new Employee(name, age, prof, exp);
                    break;
                case 3:
                    Console.Write("Введите профессию: ");
                    prof = Console.ReadLine();
                    Console.Write("Введите номер цеха: ");
                    factoryFloor = Console.ReadLine();
                    elem = new Worker(name, age, prof, factoryFloor);
                    break;
                case 4:
                    Console.Write("Введите профессию: ");
                    prof = Console.ReadLine();
                    Console.Write("Введите номер цеха: ");
                    factoryFloor = Console.ReadLine();
                    Console.Write("Введите тип инженера: ");
                    type = Console.ReadLine();
                    grade = intInput("разряд инженера (от 1 до 5)", 1, 5);
                    elem = new Engineer(name, age, prof, factoryFloor, type, grade);
                    break;
            }
            return elem;
        }
        static int intInput(string info, int leftBorder, int rightBorder)
        {
            Console.Write($"Введите {info}: ");
            int n;

            while (!Int32.TryParse(Console.ReadLine(), out n) ||
                  n < leftBorder || n > rightBorder)
            {
                Console.WriteLine($"Ошибка! Введите целое число в диапазоне от {leftBorder} до {rightBorder}.");
                Console.Write($"Введите {info}: ");
            }
            return n;
        }
    }
}
