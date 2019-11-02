using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Task1=====================");
            Animal animal = new Bear("Vinni");
            Console.WriteLine(animal);
            animal.Eat();
            animal.Sleep();
            animal.Walk();
            ZooWorker worker = new ZooWorker("Ivan");
            worker.Watch(animal);

            Console.WriteLine();
            Console.WriteLine($"Task2=====================");
            Drink dr1 = new Drink("Orange juice", DrinkType.Juice, "JCO inc", 35, 20);
            Drink dr2 = new Drink("Somersby", DrinkType.Alcohol, "XXXXX", 50, 30);
            Drink dr3 = new Drink("Bloody Marry", DrinkType.Coctails, "local", 55, 50);
            Drink dr4 = new Drink("Beer", DrinkType.Alcohol, "Obolon", 50, 30);
            Drink dr5 = new Drink("Somersby", DrinkType.Alcohol, "XXXXX", 50, 30);
            ArrayList list1 = new ArrayList() { dr1, dr2, dr3, dr4, dr5 };
            List<Drink> list2 = new List<Drink>() { dr1, dr2, dr3, dr4, dr5 };
            Console.WriteLine($"ArrayList:");
            foreach (var el in list1)
                Console.WriteLine(el + "\n");
            list1.Sort();
            Console.WriteLine($"Sort() ArrayList:=========================");
            foreach (var el in list1)
                Console.WriteLine(el + "\n");
            list1.Sort(new PriceComparer());
            Console.WriteLine($"Sort(new PriceComparer()) ArrayList:======");
            foreach (var el in list1)
                Console.WriteLine(el + "\n");
            list1.Sort(new ProductionComparer());
            Console.WriteLine($"Sort(new ProductionComparer()) ArrayList:===");
            foreach (var el in list1)
                Console.WriteLine(el + "\n");
            list1.Sort(new CaloriesComparer());
            Console.WriteLine($"Sort(new CaloriesComparer()) ArrayList:===");
            foreach (var el in list1)
                Console.WriteLine(el + "\n");
            Console.WriteLine($"IndexOf(dr1(\"Orange juice\")): {list1.IndexOf(dr1)}");

            Console.WriteLine();
            Console.WriteLine($"List<Drink>:");
            foreach (var el in list2)
                Console.WriteLine(el + "\n");
            list2.Sort();
            Console.WriteLine($"Sort() List<Drink>:=========================");
            foreach (var el in list2)
                Console.WriteLine(el + "\n");
            list2.Sort(new DrinkPriceComparer());
            Console.WriteLine($"Sort(new DrinkPriceComparer()) List<Drink>:======");
            foreach (var el in list2)
                Console.WriteLine(el + "\n");
            list2.Sort(new DrinkProductionComparer());
            Console.WriteLine($"Sort(new DrinkProductionComparer()) List<Drink>:===");
            foreach (var el in list2)
                Console.WriteLine(el + "\n");
            list2.Sort(new DrinkCaloriesComparer());
            Console.WriteLine($"Sort(new DrinkCaloriesComparer()) List<Drink>:===");
            foreach (var el in list2)
                Console.WriteLine(el + "\n");
            Console.WriteLine($"IndexOf(dr1(\"Orange juice\")): {list2.IndexOf(dr1)}");

            Console.WriteLine();
            Console.WriteLine($"Task3=====================");
            Fibo fibo = new Fibo(100);
            foreach (var el in fibo)
                Console.WriteLine(el);

            Console.WriteLine();
            Console.WriteLine($"Task4=====================");
            Employee em1 = new Employee("name1", "sur1", 1000, "pos1");
            Employee em2 = new Employee("name2", "sur2", 2000, "pos2");
            Employee em3 = new Employee("name3", "sur3", 3000, "pos3");
            Employee em4 = new Employee("name4", "sur4", 4000, "pos4");
            Employee em5 = new Employee("name5", "sur5", 5000, "pos5");
            Department dep = new Department();
            dep.Add(em1);
            dep.Add(em2);
            dep.Add(em3);
            dep.Add(em4);
            dep.Add(em5);
            Console.WriteLine($"Department:");
            foreach (var item in dep)
                Console.WriteLine(item);
            Console.WriteLine($"Department reverse:");
            foreach (var item in dep.Reverse())
                Console.WriteLine(item);
        }
    }
}
