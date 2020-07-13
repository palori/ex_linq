using System;
using System.Linq;

namespace intro2linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] numbers = new int[] { 2, 6, 8, 4, 5, 5, 9, 2, 1, 8, 7, 5, 9, 6, 4 };
            string[] names = new string[] {"David", "Sergio", "Maria", "Laura", "Oscar", "Julia", "Oriol"};
            fase1(numbers);
            fase2(numbers);
            fase3(numbers);
            fase4(names);
        }

        private static void title(string title)
        {
            Console.WriteLine($"\n\n---\n{title}:\n");
        }

        public static void fase1(int[] numbers)
        {
            title("fase1");

            // The Three Parts of a LINQ Query:
            // 1. Data source.
            //int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num; 

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }

            //return numQuery;
        }

        public static void fase2(int[] numbers)
        {
            title("fase2");

            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

           double avg = numQuery.Average();
           int max = numQuery.Max();
           int min = numQuery.Min();

           Console.WriteLine($"Avg = {avg}, Max = {max}, Min = {min}");
        }

        public static void fase3(int[] numbers)
        {
            title("fase3");

            var numQuery1 =
                (from num in numbers
                where num >= 5 
                select num).ToArray();

            var numQuery2 =
                (from num in numbers
                where num < 5 
                select num).ToArray();

            Console.Write("Grades >= 5: ");
            foreach (int num in numQuery1)
            {
                Console.Write($" {num}");
            }

            Console.Write("\nGrades < 5: ");
            foreach (int num in numQuery2)
            {
                Console.Write($" {num}");
            }
        }

        public static void fase4(string[] names)
        {
            title("fase4");

            // first query
            var nameQuery1 =
                from name in names
                where (name[0] == 'O' || name[0] == 'o')
                select name;

            Console.Write("Start with 'O' or 'o': ");
            foreach (string name in nameQuery1)
            {
                Console.Write("{0,1} ", name);
            }

            // second query
            var nameQuery2 =
                from name in names
                where name.Length >= 6
                select name;

            Console.Write("\nLength >= 6: ");
            foreach (string name in nameQuery2)
            {
                Console.Write("{0,1} ", name);
            }
        }
    }
}
