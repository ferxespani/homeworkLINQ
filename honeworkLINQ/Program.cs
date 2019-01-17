using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace honeworkLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // First, Last, FirstOrDefault, LastOrDefault, Single

            List<int> list = new List<int> { -2, 5, 6, -1, 0, 5, -9, -4 };
            var firstPositive = list.Where(l => l > 0).First();
            var lastNegative = list.Where(l => l < 0).Last();
            Console.WriteLine($"Первый положительный элемент: {firstPositive} и последний отрицатеьный {lastNegative}\n");

            List<int> list1 = new List<int> { -2, -6, -6, -1, -7, -5, -9, -4 };
            var firstPositive1 = list1.Where(l => l > 0).FirstOrDefault();
            Console.WriteLine($"Первый положительный элемент: {firstPositive1}");

            List<int> list2 = new List<int> { 2, 6, 6, 1, 7, 5, 9, 4 };
            var lastNegative1 = list2.Where(l => l < 0).LastOrDefault();
            Console.WriteLine($"Последний отрицательный элемент: {lastNegative1}\n");

            List<string> list3 = new List<string> { "USA", "Israel", "Ukraine", "Spain", "Russia" };

            try
            {
                var strings = list3.Where(l => l.StartsWith("U") || l.StartsWith("u")).Single();
            Console.WriteLine($"Строка, начинающиеся на символ, который дан в условии: {strings}");
            }
            catch(Exception)
            {
                var str = list3.Where(l => l.StartsWith("U") || l.StartsWith("u")).Select(l => l);
                if(str == null)
                {
                    Console.WriteLine("Строк, начинающихся с символа, данного в условии, не обнаружено");
                }
                else
                {
                    foreach(string s in str)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            Console.WriteLine();

            // Distinct

            List<int> list4 = new List<int> { 2, 3, 4, 1, 4, 5, 6, 7, 8, 8, 6, 5, 9, 12, 13, 14, 12 };

            var evenNumbers = list4.Where(n => n % 2 == 0).Distinct();

            foreach(int n in evenNumbers)
            {
                Console.WriteLine(n);
            }

            // Reverse

            int D = 5;
            var result = list2.Where(n => n > D).FirstOrDefault();
            Console.WriteLine($"Первый элемент списка больше D: {result}");

            var evenAndPositiveNumbers = list.Where(n => n % 2 == 0 && n >= 0).Reverse().DefaultIfEmpty(1);
            Console.WriteLine("Четные положительные числа в обратном порядке: ");
            foreach(int i in evenAndPositiveNumbers)
            {
                Console.WriteLine(i);
            }

            // Concat, DefaultIfEmpty

            int K = 4;

            var concat = list.Where(n => n > K).Concat(list4.Where(n => n < K));

            Console.WriteLine("Список, полученный обьединением двух по определенному признаку: ");
            foreach(int i in concat)
            {
                Console.WriteLine(i);
            }

            // GroupBy, ToDictionary

            List<Supplier> suppliers = new List<Supplier>
            {
                new Supplier{ Name = "Adidas", Amount = 456.6, Date = new DateTime(2019, 1, 20) },
                new Supplier{ Name = "Adidas", Amount = 336.6, Date = new DateTime(2019, 2, 20) },
                new Supplier{ Name = "Adidas", Amount = 216.6, Date = new DateTime(2019, 3, 20) },
                new Supplier{ Name = "Nike", Amount = 346.7, Date = new DateTime(2019, 3, 12) },
                new Supplier{ Name = "Nike", Amount = 123.7, Date = new DateTime(2019, 4, 12) },
                new Supplier{ Name = "Fanta", Amount = 34.8, Date = new DateTime(2019, 4, 1) },
                new Supplier{ Name = "Fanta", Amount = 14.8, Date = new DateTime(2019, 5, 1) },
                new Supplier{ Name = "Samsung", Amount = 897.6, Date = new DateTime(2019, 6, 23) },
                new Supplier{ Name = "Samsung", Amount = 197.6, Date = new DateTime(2019, 7, 23) },
            };

            var suppliersGroup = suppliers.GroupBy(s => s.Name).ToDictionary(n => n);



            foreach (KeyValuePair<IGrouping<string, Supplier>, IGrouping<string, Supplier>> pair in suppliersGroup)
            {
                Console.WriteLine(pair);
            }
        }
    }


    class Supplier
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
