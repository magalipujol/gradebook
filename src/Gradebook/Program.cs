using System;
namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Gugu");
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

            var stats = book.ComputeStatistics();
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The highest grade is {stats.Highest}");
            System.Console.WriteLine($"The lowest grade is {stats.Lowest}");
            System.Console.WriteLine("Letter grades: ");
            printCharList(stats.Letters);

        }

        static void printCharList(List<char> list)
        {
            foreach (var letter in list)
            {
                Console.WriteLine(letter);
            }
        }
    }
}