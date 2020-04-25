using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Lab10;

namespace Task3
{
    class t3Program
    {
        static void Main(string[] args)
        {
            TestCollections collection = new TestCollections(10000);
            Stopwatch stopWatch = new Stopwatch();
            
            //проверка функций
            Employee check = new Employee("Петр", 58, "Официант", 30);
            collection.Add(check);
            collection.Delete(check);

            //Поиск среди коллекций <Tkey>
            Console.WriteLine("Поиск среди коллекций <TKey>\n");
            Console.Write("Время поиска первого объекта в коллекции LinkedList<TKey>: ");
            stopWatch.Start();
            if (collection.listPeople.Contains(collection.objFirst.BasePerson))
            {
                
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }


            Console.Write("Время поиска первого объекта в коллекции SortedDictionary<TKey, TValue>: ");
            stopWatch.Restart();
            if (collection.dictPeople.ContainsKey(collection.objFirst.BasePerson) && 
                collection.dictPeople.ContainsValue(collection.objFirst))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }

            Console.Write("Время поиска среднего объекта в коллекции LinkedList<TKey>: ");
            stopWatch.Restart();
            if (collection.listPeople.Contains(collection.objMiddle.BasePerson))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }


            Console.Write("Время поиска среднего объекта в коллекции SortedDictionary<TKey, TValue>: ");
            stopWatch.Restart();
            if (collection.dictPeople.ContainsKey(collection.objMiddle.BasePerson) &&
                collection.dictPeople.ContainsValue(collection.objMiddle))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }

            Console.Write("Время поиска последнего объекта в коллекции LinkedList<TKey>: ");
            stopWatch.Restart();
            if (collection.listPeople.Contains(collection.objLast.BasePerson))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }


            Console.Write("Время поиска последнего объекта в коллекции SortedDictionary<TKey, TValue>: ");
            stopWatch.Restart();
            if (collection.dictPeople.ContainsKey(collection.objLast.BasePerson) &&
                collection.dictPeople.ContainsValue(collection.objLast))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }
            //
            //
            //
            //
            //
            //
            //Поиск среди коллекций <string>
            Console.WriteLine("\nПоиск среди коллекций <string>\n");
            Console.Write("Время поиска первого объекта в коллекции LinkedList<string>: ");
            stopWatch.Start();
            if (collection.listString.Contains(collection.strFirst.BasePerson.ToString()))
            {

                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }


            Console.Write("Время поиска первого объекта в коллекции SortedDictionary<string, TValue>: ");
            stopWatch.Restart();
            if (collection.dictString.ContainsKey(collection.strFirst.BasePerson.ToString()) &&
                collection.dictString.ContainsValue(collection.strFirst))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }

            Console.Write("Время поиска среднего объекта в коллекции LinkedList<string>: ");
            stopWatch.Restart();
            if (collection.listString.Contains(collection.strMiddle.BasePerson.ToString()))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }


            Console.Write("Время поиска среднего объекта в коллекции SortedDictionary<string, TValue>: ");
            stopWatch.Restart();
            if (collection.dictString.ContainsKey(collection.strMiddle.BasePerson.ToString()) &&
                collection.dictString.ContainsValue(collection.strMiddle))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }

            Console.Write("Время поиска последнего объекта в коллекции LinkedList<string>: ");
            stopWatch.Restart();
            if (collection.listString.Contains(collection.strLast.BasePerson.ToString()))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }


            Console.Write("Время поиска последнего объекта в коллекции SortedDictionary<string, TValue>: ");
            stopWatch.Restart();
            if (collection.dictString.ContainsKey(collection.strLast.BasePerson.ToString()) &&
                collection.dictString.ContainsValue(collection.strLast))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }
            //
            //
            //
            //
            //
            //
            //Поиск несуществующего
            Console.WriteLine("\nПоиск несуществующего элемента\n");
            Employee nonexistent = new Employee("fdgdfzsg", 22, "dfgsdf", 3);

            Console.Write("Время поиска несуществующего объекта в коллекции LinkedList<TKey>: ");
            stopWatch.Start();
            if (collection.listPeople.Contains(nonexistent.BasePerson))
            {

                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }


            Console.Write("Время поиска первого объекта в коллекции SortedDictionary<TKey, TValue>: ");
            stopWatch.Restart();
            if (collection.dictPeople.ContainsKey(nonexistent.BasePerson) &&
                collection.dictPeople.ContainsValue(nonexistent))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }

            Console.Write("Время поиска несуществующего объекта в коллекции LinkedList<string>: ");
            stopWatch.Restart();
            if (collection.listString.Contains(nonexistent.BasePerson.ToString()))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }


            Console.Write("Время поиска несуществующего объекта в коллекции SortedDictionary<string, TValue>: ");
            stopWatch.Restart();
            if (collection.dictString.ContainsKey(nonexistent.BasePerson.ToString()) &&
                collection.dictString.ContainsValue(nonexistent))
            {
                stopWatch.Stop();
                Console.WriteLine("Найден; " + stopWatch.ElapsedTicks);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("НЕ найден; " + stopWatch.ElapsedTicks);
            }

            Console.ReadKey();
        }
    }
}
