// See https://aka.ms/new-console-template for more information
using CSharp12Nutshell.Chapter02.Types;
using System.Text;

Console.WriteLine("Hello, World!");

#region Types and Conversions

int num1 = 12;
long num2 = num1; // implicit convert
Console.WriteLine($"{num1}, {num2}"); // 12 12

//short num3 = num1; // cannot implicity convert type

short num3 = (short)num1; // explicit convert

string str = "123";
var num4 = Convert.ToBoolean(num3);
#endregion

#region Value Types Versus Reference Types

PointClass pointClass1 = null;
//PointStruct pointClass2 = null;

#endregion

#region Overflow check operators

int a = 1000000;
int b = 1000000;

int c = unchecked(a * b);
Console.WriteLine(c);

long qa = 0;
unchecked
{
    qa = int.MaxValue + 1;
};

Console.WriteLine(qa);
#endregion

#region Variables and Parameters

static int Factorial(int x)
{
    if (x == 0) return 1;
    return x * Factorial(x - 1);
}


StringBuilder ref1 = new StringBuilder("object1");
Console.WriteLine(ref1);
// The StringBuilder referenced by ref1 is now eligible for GC.

StringBuilder ref2 = new StringBuilder("object2");
StringBuilder ref3 = ref2;
// The StringBuilder referenced by ref2 is NOT yet eligible for GC.

Console.WriteLine(ref3);      // object2
ValueType type;
#endregion

StringBuilder sb = new StringBuilder();
Foo(sb);
Console.WriteLine(sb.ToString());    // test

static void Foo(StringBuilder fooSB)
{
    fooSB.Append("test");
    fooSB = null;
}

