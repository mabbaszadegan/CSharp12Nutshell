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
using System;

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

#region C# 9
#region Init-only setters
SampleInitOnlySetters sampleInitOnlySetters = new SampleInitOnlySetters { Id = 1 };
//sampleInitOnlySetters.Id = 5; //has error because id just can init
#endregion

#region Records
SampleRecord record = new SampleRecord(1, "Mohammad");
SampleRecord record2 = record with { Id = 2 };
#endregion

#region Pattern-matching improvements
string GetWeightCategory(decimal bmi) => bmi switch
{
    < 18.5m => "underweight",
    < 25m => "normal",
    < 30m => "overweight",
    _ => "obese"
};

Console.WriteLine(GetWeightCategory(12)); //underweight
Console.WriteLine(GetWeightCategory(26)); //overweight

bool IsVowel(char c) => c
                            is 'a'
                            or 'e'
                            or 'i'
                            or 'o'
                            or 'u';
bool IsLetter(char c) => c
                            is >= 'a' and <= 'z'
                            or >= 'A' and <= 'Z';
#endregion

#region Target-typed new expressions
StringBuilder sb1 = new();
StringBuilder sb2 = new("Test");
#endregion
#endregion

#region C# 8

#region Indices and ranges
char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
char lastElement = vowels[^1];   // 'u'
char secondToLast = vowels[^2];   // 'o'
//Ranges let you “slice” an array by using the .. operator:

char[] firstTwo = vowels[..2];    // 'a', 'e'
char[] lastThree = vowels[2..];    // 'i', 'o', 'u'
char[] middleOne = vowels[2..3];   // 'i'
char[] lastTwo = vowels[^2..];   // 'o', 'u'

Index last = ^1;
Range firstTwoRange = 0..2;
firstTwo = vowels[firstTwoRange];   // 'a', 'e'

SampleIndicesAndRanges sampleIndicesAndRanges = new SampleIndicesAndRanges();
Console.WriteLine(sampleIndicesAndRanges[^1]);
#endregion

#region Null-coalescing assignment
string s = null;

if (s == null) s = "Hello, world";
s ??= "Hello, world";

#endregion

#region Using declarations
if (File.Exists("file.txt"))
{
    //omit the brackets and statement block following a using statement
    using var reader = File.OpenText("file.txt");
    Console.WriteLine(reader.ReadLine());
}

#endregion

#region Read-only members
// look at csharp08.cs
#endregion

#region Default interface members
// look at csharp08.cs

#endregion

#region Switch expressions
int cardNumber = 11;
string cardName = cardNumber switch    // assuming cardNumber is an int
{
    13 => "King",
    12 => "Queen",
    11 => "Jack",
    _ => "Pip card"   // equivalent to 'default'
};
#endregion

#region Tuple, positional, and property patterns

int cardNo = 12; string suite = "spades";
string cardTitle = (cardNo, suite) switch
{
    (13, "spades") => "King of spades",
    (13, "clubs") => "King of clubs",
    (12, "spades") => "Queen of spades",
};

Console.WriteLine(cardTitle);
#endregion

#region Nullable reference types
#nullable enable    // Enable nullable reference types from this point on

string s1 = null;   // Generates a compiler warning! (s1 is non-nullable)
string? s2 = null;  // OK: s2 is nullable reference type

#endregion

#region Asynchronous streams
// look at csharp08.sc

#endregion
#endregion

#region C# 7
#region Type patterns and pattern variables

var o = new Object();
switch (o)
{
    case int i:
        Console.WriteLine("It's an int!");
        break;
    case string ss:
        Console.WriteLine(ss.Length);    // We can use the s variable
        break;
    case bool b when b == true:        // Matches only when b is true
        Console.WriteLine("True");
        break;
    case null:
        Console.WriteLine("Nothing");
        break;
}
#endregion

#region Local methods
void WriteCubes()
{
    Console.WriteLine(Cube(3));
    Console.WriteLine(Cube(4));
    Console.WriteLine(Cube(5));

    int Cube(int value) => value * value * value;
}
#endregion

#region More expression-bodied members
var sampleMoreExpressionBodiedMembers = new SampleMoreExpressionBodiedMembers("Mohammad");
#endregion

#region Deconstructors

var joe = new SampleMoreExpressionBodiedMembers("Joe Bloggs");
var (first, seccond) = joe;          // Deconstruction
Console.WriteLine(first);        // Joe
Console.WriteLine(seccond);         // Bloggs

#endregion

#region Tuples
var bob = ("Bob", 23);
Console.WriteLine(bob.Item1);   // Bob
Console.WriteLine(bob.Item2);   // 23

var tuple = (name: "Bob", age: 23);
Console.WriteLine(tuple.name);     // Bob
Console.WriteLine(tuple.age);      // 23


#endregion
#endregion
