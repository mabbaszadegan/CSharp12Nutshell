using System.Runtime.CompilerServices;

static void Foo(
    [CallerMemberName] string memberName = null,
    [CallerFilePath] string filePath = null,
    [CallerLineNumber] int lineNumber = 0)
{
    Console.WriteLine(memberName);
    Console.WriteLine(filePath);
    Console.WriteLine(lineNumber);
}

Foo();