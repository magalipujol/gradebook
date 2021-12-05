using Xunit;

namespace Gradebook.tests;

public class TypeTests
{
    [Fact]
    public void Test1()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

    }

    private Book GetBook(string name)
    {
        return new Book(name);
    }
}