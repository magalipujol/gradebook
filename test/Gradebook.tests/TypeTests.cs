using Xunit;

namespace Gradebook.tests;

// this delegate describes any method that returns and takes a string.
public delegate string WriteLogDelegate(string logMessage);

public class TypeTests
{
    public void DoNothing() { }
    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log = ReturnMessage;

        // this points log to the method
        log += ReturnMessage;

        var result = log("gugis");
        Assert.Equal("gugis", result);
    }
    // this is a method that matches de conditions of the delegate
    string ReturnMessage(string message) {
        return message;
    }

    [Fact]
    public void CanPassByReferenceValueTypes()
    {
        var x = GetInt();
        SetInt(ref x);
        Assert.Equal(42, x);
    }

    [Fact]
    public void StringBehaveLikeValueTypes()
    {
        string something = "gugu";
        var upper = MakeUppercase(something);
        Assert.Equal("gugu", something);
        Assert.Equal("GUGU", upper);

    }

    public string MakeUppercase(string smt)
    {
        // The method doesn't change the string invoked on, it returns a copy of the string converted to upper
        return smt.ToUpper();
    }
    public void SetInt(ref int x)
    {
        x = 42;
    }
    public int GetInt()
    {
        return 3;
    }

    [Fact]
    public void CanPassByReferenceAValue()
    {
        var book1 = GetBook("Student 1");
        GetBookSetName(ref book1, "Generic name");

        Assert.Equal("Generic name", book1.Student);
    }
    [Fact]
    public void TwoVariablesCanReferenceTheSameObject()
    {
        var book1 = GetBook("Student1");
        // book2 and book1 contain the same pointer to an object
        var book2 = book1;

        Assert.Same(book1, book2);
        // The line above is the same as:
        // Assert.True(Object.ReferenceEquals(book1, book2))
        // It checks if both variables point to the same location of memory
        // they reference the same object
    }
    [Fact]
    public void CanSetNameFromReference()
    {
        var book1 = GetBook("Student 1");
        SetName(book1, "new student");

        Assert.Equal("new student", book1.Student);
    }
    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        var book1 = GetBook("Student 1");
        var book2 = GetBook("Student 2");

        Assert.Equal("Student 1", book1.Student);
        Assert.Equal("Student 2", book2.Student);
    }

    private Book GetBook(string name)
    {
        return new Book(name);
    }

    private void GetBookSetName(ref Book book, string name)
    {
        book = new Book(name);
    }

    private void SetName(Book book, string name)
    {
        book.Student = name;
    }
}