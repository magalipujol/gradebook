using System;
namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Gugu");
            book.GradeAdded += OnGradeAdded;
            System.Console.WriteLine(book.Student);
            EnterGrades(book);

            var stats = book.ComputeStatistics();
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The highest grade is {stats.Highest}");
            System.Console.WriteLine($"The lowest grade is {stats.Lowest}");
            System.Console.WriteLine("Letter grades: ");
            printCharList(stats.Letters);

        }
        // the method EnterGrades was written on the main class
        // I only extracted it
        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter  a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void printCharList(List<char> list)
        {
            foreach (var letter in list)
            {
                Console.WriteLine(letter);
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("grade added");
        }
    }
}