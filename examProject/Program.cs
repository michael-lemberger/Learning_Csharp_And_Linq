using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.IO;


namespace examProject
{
    class Program
    {

        static void Main(string[] args)
        {
         //Using link queries to manipulate lists.
            var vaggies = Vaggie.getVaggies();
            var query = from vaggie in vaggies
                        orderby vaggie.amount descending
                        group vaggie by vaggie.color into typeColor
                        orderby typeColor.Key
                        select typeColor; 

            foreach(var vaggieGroup in query)
            {
                var totalAmount = vaggieGroup.Sum(x => x.amount);
                Console.WriteLine("{0}, Total amount: {1} ", vaggieGroup.Key, totalAmount);
                 
                foreach(var vaggie in vaggieGroup)
                {
                    Console.WriteLine(" Name: {0}, Amount: {1}, color: {2} ", vaggie.name, vaggie.amount,
                        vaggie.color);
                }
            }
            Console.WriteLine("======================================csv======================================");

            //Using linq queries to read csv and turn it into list, and then manipulatin that list.
            var umbrellas = ProcessCsv(@"C:\Users\OWNER\Desktop\ExamProject\examProject\examProject\umbrellas.csv");

            double avrage=0;

            var costs = from cost in umbrellas
                        select cost.Buy;

            foreach (int cost in costs)
            {
                avrage += cost;
            }

            avrage /= costs.Count();

            Console.WriteLine("Avrage of umbrellas: {0}", avrage);

            //Using linq to solve fibonacci
            Console.WriteLine("======================================Fiboncci======================================");
            Console.WriteLine("The 1'th fiboncci number: 0");
            for (int i=1; i<20; i++)
            {
                int fiboNum = Enumerable.Range(1, i)
                                   .Skip(2)
                                   .Aggregate(new { prev = 1, current = 1 },
                                   (num, index) => new { prev = num.current, current = num.prev + num.current }).current;

                Console.WriteLine("The {0}'th fiboncci number: {1}",(i+1), fiboNum);
            }
            Console.WriteLine("======================================Prime_Numbers======================================");
            //Using linq with isPrime function
            int val = 1000;

            IEnumerable<int> primes =
                                     Enumerable.Range(2, 10000)
                                    .Where(number =>
                                     Enumerable.Range(2, (int)Math.Sqrt(number) - 1)
                                    .All(divisor => number % divisor != 0));

            foreach (int x in primes)
            {
                Console.WriteLine(x);
            }

            //Using out variables (not related)
            Console.WriteLine("======================================Out_Variable======================================");
            string full, first, last;
            full = GetMultipleValues(out first, out last);

            Console.WriteLine("full name: {0}, firstname: {1}, lastname: {2}", full, first, last);

            while (Console.ReadKey().Key != ConsoleKey.Escape){}
             
        }

        private static List<CsvLine> ProcessCsv(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(CsvLine.ParseRow).ToList();
        }

        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int age { get; set; }
        }
        static string GetMultipleValues(out string firstName, out string lastName)
        {
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();

            Console.Write("enter last name: ");
            lastName = Console.ReadLine();

            return firstName + " " + lastName;
        }
    }
}
