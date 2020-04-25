using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10;

namespace Task3
{
    public class TestCollections
    {
        public LinkedList<Person> listPeople = new LinkedList<Person>();
        public LinkedList<string> listString = new LinkedList<string>();
        public SortedDictionary<Person, Employee> dictPeople = new SortedDictionary<Person, Employee>();
        public SortedDictionary<string, Employee> dictString = new SortedDictionary<string, Employee>();

        string[] arrName = {"Иван_", "Дмитрий_", "Алексей_", "Герман_"};
        string[] arrProf = { "Официант", "Бармен", "Повар", "Продавец", "Менеджер", "Директор", "Охранник", "Уборщик", "Музыкант", "Официант_1", "Официант_2", "Повар_1", "Повар_2", "Повар_3", "Охранник_1", "Охранник_2" };

        //коллекция listString соответствует dictString, аналогично listPeople соответствует dictPeople
        //но они не соответствуют между собой, т.к. sorted коллекции для ключей Person и string сортируются по разным алгоритмам
        //поэтому объекты для поиска разные
        public Employee strFirst;
        public Employee strMiddle;
        public Employee strLast;

        public Employee objFirst;
        public Employee objMiddle;
        public Employee objLast;

        static int elemCount = 0;//хранит кол-во элементов, записанных в каждую коллекцию данного класса, необходима для добавления\удаления элементов

        public TestCollections(int n)
        {
            elemCount = n;
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                string name;
                int age;

                do
                {
                    name = arrName[rnd.Next(4)] + rnd.Next(100).ToString();
                    age = rnd.Next(14, 114);
                } while (dictPeople.ContainsKey(new Person(name, age)));

                string prof = arrProf[rnd.Next(16)];
                int exp = rnd.Next(age - 14);

                Employee employee = new Employee(name, age, prof, exp); 
                string str = employee.BasePerson.ToString();      
                
                dictPeople.Add(employee.BasePerson, employee);
                dictString.Add(str, employee);                
            }
            
            listFilling(n);//заполнение списков
            //Console.ReadKey();
        }



        public void listFilling(int n)
        {
            //мы заполняем списки после словарей
            //т.к. заполненные до этого коллекции(словари) сортируются автоматически, а значения связных списков должны совпадать со значениями словарей,
            //здесь же мы определяем элементы, необходимые для поиска в коллекциях (first, middle, last)
            int count = 0;
            foreach (var elem in dictPeople)
            {
                count++;

                Employee employee = (Employee)elem.Value.Clone();
                listPeople.AddLast(employee.BasePerson);

                if (count == 1)
                    objFirst = (Employee)elem.Value.Clone();
                if (count == (n / 2))
                    objMiddle = (Employee)elem.Value.Clone();
                if (count == n - 1)
                    objLast = (Employee)elem.Value.Clone();
            }
            count = 0;
            foreach (var elem in dictString)
            {
                count++;

                string str = elem.Key;
                listString.AddLast(str);

                if (count == 1)
                    strFirst = (Employee)elem.Value.Clone();
                if (count == (n / 2))
                    strMiddle = (Employee)elem.Value.Clone();
                if (count == n - 1)
                    strLast = (Employee)elem.Value.Clone();
            }
        }
        public void Add(Employee employee)
        {
            if (!listPeople.Contains(employee.BasePerson))
            {
                string str = employee.BasePerson.ToString();
                dictPeople.Add(employee.BasePerson, employee);
                dictString.Add(str, employee);
                listFilling(++elemCount);//общее кол-во элементов в коллекциях увеличилось
            }
            else
                Console.WriteLine("Элемент с данным ключом уже есть в коллекции!");
        }

        public void Delete(Employee employee)
        {
            if (listPeople.Contains(employee.BasePerson))
            {
                dictPeople.Remove(employee.BasePerson);
                listPeople.Remove(employee.BasePerson);
                dictString.Remove(employee.BasePerson.ToString());
                listString.Remove(employee.BasePerson.ToString());
                --elemCount;
            }
            Console.WriteLine("Элемента с данным ключом нет коллекции!");
        }

    }
}
