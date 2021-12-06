using Xunit;

namespace Gradebook.tests;

public class BookTests
{
    public void DoNothing() { }
    [Fact]
    public void BookCalculatesGradesStats()
    {
        var book = new Book("gugu's book");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);

        var result = book.ComputeStatistics();

        Assert.Equal(85.6, result.Average, 1);
        Assert.Equal(90.5, result.Highest, 1);
        Assert.Equal(77.3, result.Lowest, 1);
        Assert.Equal('B', result.Letters[0]);
    }
}