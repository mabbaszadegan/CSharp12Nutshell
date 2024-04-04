
using CSharp12Nutshell.Chapter04.Delegates;

//int Square(int x)
//{
//    return x * x;
//}

//int Square(int x) => x * x;

//Transformer transformer = Square;

//Console.WriteLine(transformer(5)); //25

#region Writing Plug-in Methods with Delegates

int[] values = [1, 2, 3];
Transform(values, Square);      // Hook in the Square method

foreach (int i in values)
    Console.Write(i + "  ");      // 1   4   9

values = [1, 2, 3];
Transform(values, Cube);      // Hook in the Cube method

foreach (int i in values)
    Console.Write(i + "  ");      // 1   8   27

void Transform(int[] values, Transformer t)
{
    for (int i = 0; i < values.Length; i++)
        values[i] = t(values[i]);
}

int Square(int x) => x * x;
int Cube(int x) => x * x * x;

#endregion

#region Instance and Static Method Targets
Transformer t1 = SampleClass.Square;
Transformer t2 = new SampleClass().Cube;

Console.WriteLine(t1(2) + "     " + t2(2));  // 4   8
Console.WriteLine(t1.Target);  // null
Console.WriteLine(t2.Target);  // sampleClass

#endregion

#region Multicast Delegates

Transformer t = SampleClass.Square;
t += new SampleClass().Cube;
Console.WriteLine("Multicast Delegates: " + t(2));
Console.WriteLine(string.Join(", ", t.GetInvocationList().Select(q => q.Method.ToString())));  // Int32 Square(Int32), Int32 Cube(Int32)

t -= SampleClass.Square;
Console.WriteLine(string.Join(", ", t.GetInvocationList().Select(q => q.Method.ToString())));  // Int32 Cube(Int32)

Transformer transformer = null;
transformer += SampleClass.Square;
Console.WriteLine(string.Join(", ", transformer.GetInvocationList().Select(q => q.Method.ToString())));  // Int32 Square(Int32)
transformer -= SampleClass.Square;
Console.WriteLine(transformer is null);  // true

ProgressReporter p = WriteProgressToConsole;
p += WriteProgressToFile;
Util.HardWork(p);
Console.WriteLine(p.Method);  // sampleClass

p(5);
void WriteProgressToConsole(int percentComplete)
  => Console.WriteLine(percentComplete);

void WriteProgressToFile(int percentComplete)
  => System.IO.File.WriteAllText("progress.txt",
                                   percentComplete.ToString());
Transformer tt = null;
var testDelegate = Delegate.Combine(tt, SampleClass.Square);
testDelegate = Delegate.Combine(testDelegate, new SampleClass().Cube);
testDelegate = Delegate.Remove(testDelegate, new SampleClass().Cube);

#endregion

#region Generic Delegate Types

int[] intValues = [1, 2, 3];
string[] stringValues = ["Mohammad", "Ali"];

Util.Transform(intValues, Square);      // Hook in Square
foreach (int i in intValues)
    Console.Write(i + "  ");           // 1   4   9

string sayHello(string s) => $"Hello, {s}";
Util.Transform(stringValues, sayHello);      // Hook in Square
foreach (string i in stringValues)
    Console.Write(i + "  ");           // Hello, Mohammad  Hello, Ali

#endregion

#region The Func and Action Delegates
Util.TransformWithFunc(intValues, Square);
Util.TransformWithFunc(stringValues, sayHello);
#endregion

#region Delegates Versus Interfaces

Util.TransformAll(values, new Squarer());
foreach (int i in values)
    Console.WriteLine(i);

#endregion

#region Delegate Compatibility
D1 d1 = Method1;
//D2 d2 = d1;                           // Compile-time error
D2 d2 = new D2(d1);
void Method1() { }

Transformer transformer1 = Square;
Transformer transformer2 = Square;
Transformer transformer3 = Cube;
Transformer transformer4 = transformer1 + Cube;
Transformer transformer5 = transformer2 + Cube;

Console.WriteLine(transformer1 == transformer2); // True
Console.WriteLine(transformer1 == transformer3); // False
Console.WriteLine(transformer4 == transformer5); // False

StringAction sa = new StringAction(ActOnObject);
sa("hello");

void ActOnObject(object o) => Console.WriteLine(o);   // hello

ObjectRetriever o = new ObjectRetriever(RetrieveString);
object result = o();
Console.WriteLine(result);      // hello

string RetrieveString() => "hello";
#endregion
