
using System.Collections;
using System.Text;

#region IEnumerable and IEnumerator

var enumerator = "Hello".GetEnumerator();
enumerator.MoveNext();
Console.WriteLine(enumerator.Current); // H
enumerator.MoveNext();
Console.WriteLine(enumerator.Current); // e
enumerator.Reset();
//Console.WriteLine(enumerator.Current); // runtime error


string s = "Hello";

// Because string implements IEnumerable, we can call GetEnumerator():
IEnumerator rator = s.GetEnumerator();

while (rator.MoveNext())
{
    char c = (char)rator.Current;
    Console.Write(c + ".");
}

// Output:  H.e.l.l.o.

int[] array = [1, 2];


#endregion

#region Array

Array.Resize(ref array, 5);

var a=Array.CreateInstance(typeof(int), 7);


StringBuilder[] builders = new StringBuilder[5];
builders[0] = new StringBuilder("builder1");
builders[1] = new StringBuilder("builder2");
builders[2] = new StringBuilder("builder3");

long[] numbers = new long[3];
numbers[0] = 12345;
numbers[1] = 54321;


object[] a1 = { "string", 123, true };
object[] a2 = { "string", 123, true };

Console.WriteLine(a1 == a2);                          // False
Console.WriteLine(a1.Equals(a2));                    // False

IStructuralEquatable se1 = a1;
Console.WriteLine(se1.Equals(a2,
 StructuralComparisons.StructuralEqualityComparer));   // True

StringBuilder[] builders2 = builders;
StringBuilder[] shallowClone = (StringBuilder[])builders.Clone();

#endregion
