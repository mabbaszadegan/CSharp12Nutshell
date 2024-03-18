// See https://aka.ms/new-console-template for more information
using CSharp12Nutshell.WhatsNew;
using System.Drawing;

//enable before c# 12
using ListOfInt = System.Collections.Generic.List<int>;

//enable c# 12
using NumberList = double[];
using Location = (int X, int Y);
using Point = CSharp12Nutshell.WhatsNew.Point;
using System.Numerics;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#region C# 12
Console.WriteLine($"----------------------- C# 12 -----------------");
#region Collection expressions
// before C# 12
int[] arrayBefore = { 1, 2, 3 };

// C# 12
int[] arrayInCsharp12 = [1, 2, 3];

CSharp12 cSharp12 = new CSharp12();
//cSharp12.getLength({ 1, 2, 3 });   incorrect 
Console.WriteLine(cSharp12.getLength([1, 2, 3]));

#endregion

#region Primary constructors in classes and structs

Console.WriteLine(new ClassWithPrimaryConstructor("C#", "Class").SayHello());
Console.WriteLine(new StructWithPrimaryConstructor("C#", "Struct").SayHello());

#endregion

#region Default lambda parameters

string SayHelloWithoutLambda(string name = "")
{
    return $"Hi {name}".Trim();
}

var SayHelloWithLambda = (string name = "") =>
{
    return $"Hi {name}".Trim();
};

Console.WriteLine(SayHelloWithoutLambda());
Console.WriteLine(SayHelloWithLambda());

#endregion

#region Alias any type

var list = new ListOfInt();
NumberList numbers = { 2.5, 3.5 };
Location p = (3, 4);


#endregion

#region Inline Array
Point p1 = new Point() { X = 1, Y = 2 };
Point p2 = new Point() { X = 3, Y = 4 };

double distance = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));

#endregion

#endregion

#region C# 11
Console.WriteLine($"----------------------- C# 11 -----------------");
#region Raw string literals

// use three or more quote characters create a raw string
string raw = """<file path="c:\temp\test.txt"></file>""";
Console.WriteLine(raw);

// use $ with raw string you can write multi line string
string multiLineRaw = $"""
  Line 1
  Line 2
  The date and time is {DateTime.Now}
  """;
Console.WriteLine(multiLineRaw);

// use two or more $ in a raw string, allowing you to include braces in the string itself:
Console.WriteLine($$"""{ "TimeStamp": "{{DateTime.Now}}" }""");
// Output: { "TimeStamp": "01/01/2024 12:13:25 PM" }

#endregion

#region UTF-8 strings

var utf8 = "ab→cd"u8;  // Arrow symbol consumes 3 bytes
var str = "ab→cd";  // Arrow symbol consumes 3 bytes
Console.WriteLine("UTF8: " + utf8.Length);      // 7
Console.WriteLine("String: " + str.Length);      // 5

#endregion

#region List patterns

int[] arryAges = { 1, 2, 3, 4, 5 };
Console.WriteLine($"List patterns (array)");

Console.WriteLine(arryAges is [1, 2, 3, 4]);   // False
Console.WriteLine(arryAges is [1, 2, 3, 4, 5]);   // True
Console.WriteLine(arryAges is [1, .., 5]);   // True
Console.WriteLine(arryAges is [.., 5]);   // True
Console.WriteLine(arryAges is [1, ..]);   // True
Console.WriteLine(arryAges is [_, 2, .., 5]);   // True
Console.WriteLine(arryAges is [_, _, 3, .., 5]);   // True

List<int> listAges = [1, 2, 3, 4, 5];
Console.WriteLine($"List patterns (list)");

Console.WriteLine(listAges is [1, 2, 3, 4]);   // False
Console.WriteLine(listAges is [1, 2, 3, 4, 5]);   // True
Console.WriteLine(listAges is [1, .., 5]);   // True
Console.WriteLine(arryAges is [.., 5]);   // True
Console.WriteLine(arryAges is [1, ..]);   // True
Console.WriteLine(listAges is [_, 2, .., 5]);   // True
Console.WriteLine(listAges is [_, _, 3, .., 5]);   // True

#endregion

#region Required members

//var obj1 = new SampleRequiredMembers();  
var obj2 = new SampleRequiredMembers { FirstName = "", LastName = "" };

#endregion

#region Static virtual/abstract interface members

Console.WriteLine(ParseString.Parse("Test Parse String"));

#endregion

#region Generic math

T Sum<T>(T[] numbers) where T : INumber<T>
{
    T total = T.Zero;
    foreach (T n in numbers)
        total += n;      // Invokes addition operator for any numeric type
    return total;
}

int intSum = Sum([3, 5, 7]);
double doubleSum = Sum([3.2, 5.3, 7.1]);
decimal decimalSum = Sum([3.2m, 5.3m, 7.1m]);

#endregion
#endregion

#region C# 10
#region Nondestructive mutation for anonymous types

var a1 = new { A = 1, B = 2, C = 3, D = 4, E = 5 };
var a2 = a1 with { E = 10 };
Console.WriteLine(a2);      // { A = 1, B = 2, C = 3, D = 4, E = 10 }

#endregion

#region New deconstruction syntax

var point = (3, 4);
double x = 0;
(x, double y) = point;
Console.WriteLine($"X={x}, Y={y}");

#endregion

#region Record structs

//record struct StructRecord(int X, int Y);

#endregion

#region Lambda expression enhancements

// 1. implicit typing (var) is permitted:
var greeter = () => "Hello, world";
var square = (int x) => x * x;

// 2. lambda expression can specify a return type
var sqr = int (int x) => x;

// 3.  you can pass a lambda expression into a method parameter of type object, Delegate, or Expression
M1(() => "test");   // Implicitly typed to Func<string>
M2(() => "test");   // Implicitly typed to Func<string>
M3(() => "test");   // Implicitly typed to Expression<Func<string>>

void M1(object x) { }
void M2(Delegate x) { }
void M3(Expression x) { }

// 4. apply attributes to a lambda expression’s compile-generated target method 
var a = [Description("test")] () => { };

#endregion

#region Nested property patterns

var obj = new Uri("https://www.linqpad.net");
Console.WriteLine(obj is Uri { Scheme.Length: 5 }); //true
Console.WriteLine(obj is Uri { Scheme: { Length: 5 } }); //true

var nestedPropertyPattern = new SampleNestedPropertyPattern
{
    Id = 1,
    Name = "Mohammad",
    Age = 34,
    City = "Tehran",
    Address = "Andisheh"
};

Console.WriteLine(nestedPropertyPattern is SampleNestedPropertyPattern { Name: "Mohammad" }); //true
Console.WriteLine(nestedPropertyPattern is SampleNestedPropertyPattern { Age: 20 }); //false

#endregion

#region CallerArgumentExpression

Print($"{DateTime.Now} - test");

void Print(string name, [CallerArgumentExpression(nameof(name))] string expr = null) => Console.WriteLine(expr);

// Output: $"{DateTime.Now} - test"
#endregion

#endregion
