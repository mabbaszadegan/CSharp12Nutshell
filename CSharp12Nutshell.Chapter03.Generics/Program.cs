using CSharp12Nutshell.Chapter03.Generics;
using System.Text;
using Generics = CSharp12Nutshell.Chapter03.Generics;

var intStack = new Generics.Stack<int>();
intStack.Push(5);
intStack.Push(10);
int x = intStack.Pop();        // x is 10
int y = intStack.Pop();        // y is 5
Console.WriteLine($"{x}, {y}"); // 10, 5

// Suppose we just want to store integers here:
var stack = new Generics.ObjectStack();

stack.Push("s");          // Wrong type, but no error!
//int i = (int)stack.Pop();  // Downcast - runtime error

#region Generic Methods
static void Swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}

x = 5;
y = 10;
Swap(ref x, ref y);
Swap<int>(ref x, ref y);

Console.WriteLine(intStack[1]);

#endregion

#region Declaring Type Parameters

Dictionary<int, string> myDict1 = new Dictionary<int, string>();
var myDict2 = new Dictionary<int, string>();

#endregion

#region typeof and Unbound Generic Types

Type a1 = typeof(A<>);   // Unbound type (notice no type arguments).
Type a2 = typeof(A<,>);  // Use commas to indicate multiple type args.
Type a3 = typeof(A<int, int>);

Console.WriteLine(a1.ToString()); // CSharp12Nutshell.Chapter03.Generics.A`1[T]
Console.WriteLine(a2.ToString()); // CSharp12Nutshell.Chapter03.Generics.A`2[T1,T2]
Console.WriteLine(a3.ToString()); // CSharp12Nutshell.Chapter03.Generics.A`2[System.Int32,System.Int32]

#endregion

#region The default Generic Value
static string Zap<T>(T[] array)
{
    for (int i = 0; i < array.Length; i++)
        array[i] = default;

    return string.Join(",", array);
}

Console.WriteLine(Zap(new string[5]));  // ",,,,"
Console.WriteLine(Zap(new int[5]));     // "0,0,0,0,0"
#endregion

#region Generic Constraints

_ = new GenericClass<SomeClass2, SomeClass2>();
//_ = new GenericClass<SomeClass, SomeClass>();
//_ = new GenericClass<SomeClass2, SomeClass>();
//_ = new GenericClass<SomeClass, SomeClass>();

static T Max<T>(T a, T b) where T : IComparable<T>
{
    return a.CompareTo(b) > 0 ? a : b;
}

Console.WriteLine(Max("a", "b"));
Console.WriteLine(Max(7, 8));
#endregion


#region Static Data

Console.WriteLine(++Bob<int>.Count);     // 1
Console.WriteLine(++Bob<int>.Count);     // 2
Console.WriteLine(++Bob<string>.Count);  // 1
Console.WriteLine(++Bob<object>.Count);  // 1
Console.WriteLine(++Bob<string>.Count);  // 2

#endregion

#region Type Parameters and Conversions

StringBuilder Foo<T>(T arg)
{
    //if (arg is StringBuilder)
    //    return (StringBuilder)arg;   // Will not compile

    var sb = arg as StringBuilder;
    if (sb != null) return sb;

    if (arg is StringBuilder)
        return (StringBuilder)(object)arg;

    return null;

}

//Generics.Stack<Bear> bears = new Generics.Stack<Bear>();
//Generics.Stack<Animal> animals = bears;

//animals.Push(new Camel());      // Trying to add Camel to bears


ZooCleaner.Wash(new Generics.Stack<Bear>());
ZooCleaner.Wash(new Generics.Stack<Camel>());
ZooCleaner.Wash(new Generics.Stack<Animal>());



//Bear[] bears = new Bear[3];
//Animal[] animals = bears;     // OK
//animals[0] = new Camel();     // Runtime error


var bears = new Generics.Stack<Bear>();
bears.Push(new Bear());
// Bears implements IPoppable<Bear>. We can convert to IPoppable<Animal>:
IPoppable<Animal> popAnimals = bears;   // Legal
Animal a = popAnimals.Pop();

IPushable<Animal> animals = new Generics.Stack<Animal>();
IPushable<Bear> pushBears = animals;    // Legal
bears.Push(new Bear());


#endregion