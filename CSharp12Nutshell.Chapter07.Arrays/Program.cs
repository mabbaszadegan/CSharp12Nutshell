#region Construction and Indexing

int[] myArray = { 1, 2, 3 };
int first = myArray[0];
int last = myArray[myArray.Length - 1];


// Create a string array 2 elements in length:
Array a = Array.CreateInstance(typeof(string), 2);
a.SetValue("hi", 0);                             //  → a[0] = "hi";
a.SetValue("there", 1);                          //  → a[1] = "there";
string s = (string)a.GetValue(0);               //  → s = a[0];

// We can also cast to a C# array as follows:
string[] cSharpArray = (string[])a;
string s2 = cSharpArray[0];

object[] aSharpArray = (object[])a;

Console.WriteLine(a.Rank);
Demo();

Console.WriteLine(a.Length);
Array.Clear(a, 0, a.Length);
Console.WriteLine(a.Length);

void WriteFirstValue(Array a)
{
    Console.Write(a.Rank + "-dimensional; ");

    // The indexers array will automatically initialize to all zeros, so
    // passing it into GetValue or SetValue will get/set the zero-based
    // (i.e., first) element in the array.

    int[] indexers = new int[a.Rank];
    Console.WriteLine("First value is " + a.GetValue(indexers));
}

void Demo()
{
    int[] oneD = { 1, 2, 3 };
    int[,] twoD = { { 5, 6 }, { 8, 9 } };

    WriteFirstValue(oneD);   // 1-dimensional; first value is 1
    WriteFirstValue(twoD);   // 2-dimensional; first value is 5
}
#endregion