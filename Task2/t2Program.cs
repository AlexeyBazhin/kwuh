using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10;

namespace Task2
{
    class t2Program
    {
        public static Stack<Person> stack = new Stack<Person>();
        static void Main(string[] args)
        {
            stack.Push(new Person("Иван", 18));
            stack.Push(new Employee("Петр", 58, "Официант", 30));
            stack.Push(new Worker("Антон", 25, "Копатель", "12 - Б"));
            stack.Push(new Engineer("Валера", 54, "Инженер", "12 - Б", "Инженер-проектировщик", 3));
            stack.Push(new Employee("Дмитрий_1", 35, "Почтальон", 11));
            stack.Push(new Worker("Антон_3", 35, "Сантехник", "12 - Б"));
            stack.Push(new Employee("Дмитрий_2", 35, "Почтальон", 12));
            stack.Push(new Engineer("Валера_2", 31, "Инженер", "15 - Г", "Заместитель", 5));
            stack.Push(new Worker("Антон_2", 35, "Копатель", "11d"));
            stack.Push(new Employee("Дмитрий_3", 35, "Почтальон", 17));
            stack.Push(new Engineer("Валера_3", 23, "Инженер", "12 - Б", "Младший инженер", 1));
            stack.Push(new Person("Я", 22));
            stack.Push(new Employee("Дмитрий_4", 35, "Почтальон", 1));
            stack.Push(new Employee("Дмитрий_5", 35, "Почтальон", 23));

            int menuItem;
            printMenu();         
            do
            {
                Console.WriteLine();

                if (stack.Count != 0)
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
                            stack.Push(chooseElem());
                            Console.WriteLine("Элемент успешно добавлен, нажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            printMenu();
                            break;
                        }
                    case 2://удалить элемент
                        {
                            int delIndex = intInput("номер удаляемого элемента", 1, stack.Count);
                            elemDelete(stack, --delIndex);
                            printMenu();
                            break;
                        }
                    case 3://Запрос: Имена служащих со стажем не менее заданного
                        {
                            Console.WriteLine("\nПоиск имен служащих, имеющих стаж не менее заданного");
                            int userExp = intInput("стаж", 0, 86);
                            foreach (var element in stack)
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
                            foreach (var element in stack)
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
                            foreach (var element in stack)
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

                            Stack<Person> stackClone = Clone(stack);
                            Console.WriteLine("\nСклонированная коллекция:\n");
                            printCollection(stackClone);
                            Console.WriteLine("\nУдалим первый объект из клона:\n");
                            elemDelete(stackClone, 0);
                            printCollection(stackClone);
                            Console.WriteLine("\nИзначальная коллекция:\n");
                            printCollection(stack);
                            Console.WriteLine("\nПроведено полное клонирование.\n");
                            break;
                        }
                    case 7://сортировка по имени через IComparable
                        {
                            List<Person> list = stack.ToList<Person>();
                            stack.Clear();
                            list.Sort();
                            for (int i = list.Count - 1; i >= 0; i--)
                                stack.Push(list[i]);
                            printMenu();
                            break;
                        }
                    case 8://сортировка по возрасту через IComparer
                        {
                            //через обобщенную коллекцию как в предыдущем кейсе не получится, т.к. SortByAge - отдельный класс, который в библиотеке реализован как необобщенный, из-за чего возникает ошибка приведения типов, т.к. Sort у обобщенных коллекций требует обобщенный параметр collection.Sort(new SortByAge<T>).
                            //А через необобщенный ArrayList не выйдет, т.к. у стека нет такого метода приведения
                            Person[] arr = stack.ToArray();
                            stack.Clear();
                            Array.Sort(arr, new SortByAge());
                            for (int i = arr.Length - 1; i >= 0; i--)
                                stack.Push(arr[i]);
                            printMenu();
                            break;
                        }
                    case 9://найти элемент
                        {
                            if (stack.Contains(chooseElem()))
                                Console.WriteLine("\nЭлемент найден!");
                            else
                                Console.WriteLine("\nЭлемент не найден!");
                            break;
                        }
                }
            } while (menuItem != 0);

        }
        static void elemDelete(Stack<Person> stack, int index)
        {
            int count = 0;
            Stack<Person> stackHelp = new Stack<Person>();
            while(count < index)
            {
                count++;
                stackHelp.Push(stack.Pop());
            }
            stack.Pop();
            while (stackHelp.Count != 0)
            {
                stack.Push(stackHelp.Pop());
            }
        }
        static Stack<Person> Clone(Stack<Person> stack)
        {
            Stack<Person> stackHelp = new Stack<Person>();
            Stack<Person> stackClone = new Stack<Person>();
            while(stack.Count != 0)
            {
                stackHelp.Push(stack.Pop());
            }
            while (stackHelp.Count != 0)
            {
                if (stackHelp.Peek() is Engineer)
                {
                    Engineer eng = (Engineer)stackHelp.Peek();
                    stackClone.Push((Engineer)eng.Clone());
                }
                else
                {
                    if (stackHelp.Peek() is Worker)
                    {
                        Worker wrk = (Worker)stackHelp.Peek();
                        stackClone.Push((Worker)wrk.Clone());
                    }
                    else
                    {
                        if (stackHelp.Peek() is Employee)
                        {
                            Employee emp = (Employee)stackHelp.Peek();
                            stackClone.Push((Employee)emp.Clone());
                        }
                        else stackClone.Push((Person)stackHelp.Peek().Clone());
                    }
                }
                stack.Push(stackHelp.Pop());
            }
            return stackClone;
        }
        static void printMenu()
        {
            Console.Clear();
            Console.WriteLine("Задание 2. Коллекция Stack<T>\n");
            Console.WriteLine("Текущая коллекция:");
            printCollection(stack);
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
        static void printCollection(Stack<Person> stack)
        {
            int count = 0;
            foreach (Person obj in stack)
            {
                Console.Write($"{++count}) ");
                obj.RightShow();
            }
        }

        static Person chooseElem()
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
