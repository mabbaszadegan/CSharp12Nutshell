using CSharp12Nutshell.Chapter04.Patterns;
using System.Drawing;

var obj = new object();

if (obj is string)
    Console.WriteLine(((string)obj).Length);

if (obj is string s)
    Console.WriteLine(s.Length);

if (obj is string { Length: 4 })
    Console.WriteLine("A string with 4 characters");

#region Constant Pattern

if (obj is 2)
    Console.WriteLine("obj is 2");

if (obj is int && (int)obj == 2)
    Console.WriteLine("obj is 2");

if (2.Equals(obj))
    Console.WriteLine("obj is 2");

#endregion

#region Relational Patterns

if (obj is > 100)
    Console.WriteLine("x is greater than 100");

string Weight = obj switch
{
    < 18.5m => "underweight",
    < 25m => "normal",
    < 30m => "overweight",
    _ => "obese"
};

Console.WriteLine($"Weight: {Weight}");

obj = 2m;                  // obj is decimal
Console.WriteLine(obj is < 3m);  // True
Console.WriteLine(obj is < 3);   // False

#endregion

#region Pattern Combinators

bool IsJanetOrJohn(string name) => name.ToUpper() is "JANET" or "JOHN";

bool IsVowel(char c) => c is 'a' or 'e' or 'i' or 'o' or 'u';

bool Between1And9(int n) => n is >= 1 and <= 9;

bool IsLetter(char c) => c is >= 'a' and <= 'z'
                            or >= 'A' and <= 'Z'
                            and not 'b' and not 'B';

Console.WriteLine(IsLetter('A')); // True
Console.WriteLine(IsLetter('B')); // False
Console.WriteLine(IsLetter('z')); // True
Console.WriteLine(IsLetter('2')); // False

if (obj is not string)
    Console.WriteLine("obj is not string");


#endregion

#region var Pattern

bool IsJanetOrJoe(string name) =>
  name.ToUpper() is var upper && (upper == "JANET" || upper == "JOE");

//bool IsJanetOrJoe(string name)
//{
//    string upper = name.ToUpper();
//    return upper == "JANET" || upper == "JOHN";
//}

#endregion

#region Tuple and Positional Patterns

var p = (2, 3);
Console.WriteLine(p is (2, 3));   // True

int AverageCelsiusTemperature(Season season, bool daytime) =>
  (season, daytime) switch
  {
      (Season.Spring, true) => 20,
      (Season.Spring, false) => 16,
      (Season.Summer, true) => 27,
      (Season.Summer, false) => 22,
      (Season.Fall, true) => 18,
      (Season.Fall, false) => 12,
      (Season.Winter, true) => 10,
      (Season.Winter, false) => -2,
      _ => throw new Exception("Unexpected combination")
  };

Console.WriteLine(AverageCelsiusTemperature(Season.Summer, false)); //22
Console.WriteLine(AverageCelsiusTemperature(Season.Summer, true));  //27
Console.WriteLine(AverageCelsiusTemperature(Season.Winter, false)); //-2


var pointClass = new PointClass(2, 2);
var pointRecord = new PointRecord(2, 2);

Console.WriteLine(pointClass is (2, 2));  // True
Console.WriteLine(pointRecord is (2, 2));  // True

string Print(object obj) => obj switch
{
    PointClass(0, 0) => "Empty point",
    PointClass(var x, var y) when x == y => "Diagonal",
    PointClass(var x, var y) when x > y => "X is great",
    PointClass(var x, var y) when x < y => "y is great",
    _ => "No Support"
};

Console.WriteLine(Print((2, 2)));               // "No Support"
Console.WriteLine(Print(new PointClass(2, 2))); // "Diagonal"
Console.WriteLine(Print(new PointClass(2, 5))); // "X is great"
Console.WriteLine(Print((2M, 2M)));             // "No Support"
Console.WriteLine(Print(('A', 'C')));            // "No Support"

#endregion

#region Property Patterns

//bool ShouldAllow(Uri uri) => uri switch
//{
//    { Scheme: "http", Port: 80 } => true,
//    { Scheme: "https", Port: 443 } => true,
//    { Scheme: "ftp", Port: 21 } => true,
//    { Scheme: { Length: 4 }, Port: 80 } => true,
//    { Scheme.Length: 5, Port: 443 } => true,
//    { Host: { Length: < 1000 }, Port: > 0 } => true,
//    { Scheme: "http" } when string.IsNullOrWhiteSpace(uri.Query) => true,
//    { IsLoopback: true } => true,
//    _ => false
//};

bool ShouldAllow(object uri) => uri switch
{
    Uri { Scheme: "http", Port: 80 } httpUri => httpUri.Host.Length < 1000,
    Uri { Scheme: "https", Port: 443 } httpUri when httpUri.Host.Length < 1000 => true,
    Uri { Scheme: "http", Port: 8080, Host: string host } => host.Length < 1000,
    Uri { Scheme: "http", Port: 8081, Host: var host } => host.Length < 1000,
};

#endregion

#region List Patterns

int[] numbers = { 0, 1, 7, 8, 4 };
Console.WriteLine(numbers is [0, 1, 7, 8, 4]);   // True
Console.WriteLine(numbers is [0, 1, _, _, 4]);   // True
Console.WriteLine(numbers is [0, 1, var x, 8, 4] && x > 1);   // True
Console.WriteLine(numbers is [0, .., 4]);    // True
Console.WriteLine(numbers is [0, .. var mid, 4] && mid.Contains(7)); // True

#endregion