# C# and .Net Fundamentals

- (CLR means Common Language Runtime) .Net is a runtime, which means that it provides a space for the application to run. It know how to bring the program to life, manage the memory and communicate with the OS.
- (FCL means Framework Class Library). In addition to a runtime, .Net also provides a set of libraries.
- The solution file is a file that contains all the references to the files that I want to run tests on.
- There is a difference between passing a parameter by reference and by value. Passing by reference a variable means that you're passing the location of memory of the variable, and passing by value means that the value of the variable is being copied, if it's a primitive type it copies the value itself, but if not, it copies the pointer.
- To know the type of a variable (value or reference), press <kbd>F12</kbd>, and if it's defined as a 'struct', it's a value type, and if it's defined as a 'class', it's a reference type.
For example, Boolean is a value type of C#, and bool is the .Net shortcut.
- .Net has a garbage collector, that keeps that of all the object and variables I create, and knows when there's no variables and no fields that are pointing to or using that object, and cleans up that space. So I don't have to tell .Net that i'm finished using an object and tell the runtime to delete that object of free up the memory.
- A delegate is a reference type variable that has the reference to a method.

- In order to run the code, I have to be in the folder of the project and press <kbd>Ctrl</kbd> + <kbd>F5</kbd> or execute the following command
~~~
$ dotnet run
~~~
and to run the tests in the solution file, execute
~~~
$ dotnet test
~~~


