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

            var average = book.CalculateAverage();
            System.Console.WriteLine(book.ComputeStatistics());
        }
    }
}