
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

var a = Array.CreateInstance(typeof(int), 7);


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

#region Enumeration

int[] myArray = { 1, 2, 3 };
foreach (int val in myArray)
    Console.WriteLine(val);

Array.ForEach(myArray, (a) => Console.WriteLine(a));
Array.ForEach(new[] { 1, 2, 3 }, Console.WriteLine);
Array.ForEach([1, 2, 3], Console.WriteLine);

#endregion

#region Length and Rank

string[,,] s3 = new string[5, 4, 8];
Console.WriteLine($"{nameof(s3.Length)} -> {s3.Length}");                  //160
Console.WriteLine($"{nameof(s3.LongLength)} -> {s3.LongLength}");          //160
Console.WriteLine($"{nameof(s3.GetLength)} -> {s3.GetLength(1)}");         //4
Console.WriteLine($"{nameof(s3.GetLongLength)} -> {s3.GetLongLength(2)}"); //8
Console.WriteLine($"{nameof(s3.GetLowerBound)} -> {s3.GetLowerBound(2)}"); //0
Console.WriteLine($"{nameof(s3.GetUpperBound)} -> {s3.GetUpperBound(2)}"); //7


#endregion

#region Searching

Console.WriteLine(Array.BinarySearch([12, 5, 14, 7], 0, 2, 5));             // -1 because array is not sorted

Console.WriteLine(Array.IndexOf(["a", "b", "5", "c", "d", "5"], "5"));      //2
Console.WriteLine(Array.LastIndexOf(["a", "b", "5", "c", "d", "5"], "5"));  //5

Console.WriteLine(string.Join(",", Array.FindAll(["a", "b", "5A", "c", "d", "5"], (a) => { return a == "5"; })));  //5,5
Console.WriteLine(string.Join(",", Array.TrueForAll(["a", "b", "5A", "c", "d", "5"], (a) => { return a == "5"; })));  //5,5

#endregion

#region Sorting

int[] arr = [2, 5, 8, 1];
Array.Sort(arr);

Console.WriteLine(string.Join(",", arr));  //1,2,5,8

numbers = [3, 2, 1];
string[] words = { "three", "two", "one" };
Array.Sort(numbers, words);

// numbers array is now { 1, 2, 3 }
// words   array is now { "one", "two", "three" }

#endregion

#region Reversing Elements

Array.Reverse(arr);
Console.WriteLine(string.Join(",", arr));  //8,5,2,1

#endregion

#region Copying

int[,] int3X3 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
int[] int3 = [1, 5, 6];
var clone = int3X3.Clone();

int[] copy3 = new int[3];
int3.CopyTo(copy3, 0);

int[,] copy3X3 = new int[3, 3];
Array.Copy(int3X3, copy3X3, 5);

Array.ConstrainedCopy(int3X3, 0, copy3X3, 3, 5);

#endregion

#region Converting and Resizing

float[] reals = { 1.3f, 1.5f, 1.8f };
int[] wholes = Array.ConvertAll(reals, r => Convert.ToInt32(r));

// wholes array is { 1, 2, 2 }

Array.Resize(ref wholes, 5);
Console.WriteLine(string.Join(",", wholes));  // { 1, 2, 2, 0, 0 }

#endregion