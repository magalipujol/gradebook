using System;
namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Gugu");
            book.AddGrade(5.1);
            book.AddGrade(46.2);
            book.AddGrade(85.6);
            book.AddGrade(20.6);

            var stats = book.ComputeStatistics();
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The highest grade is {stats.Highest}");
            System.Console.WriteLine($"The lowest grade is {stats.Lowest}");
        }
    }
}