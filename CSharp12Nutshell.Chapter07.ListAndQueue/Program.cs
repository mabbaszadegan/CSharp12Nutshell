using System.Collections;
List<int>.Enumerator enumerator = new List<int>.Enumerator { };


#region List<T> and ArrayList

List<int> numberList = new List<int>();
ArrayList numberArrays = new ArrayList(numberList);

numberList.Add(0);
Console.WriteLine(numberList.Count);    // 1
Console.WriteLine(numberArrays.Count);  // 0

List<DateTime> dateList = new List<DateTime>();
dateList.Add(DateTime.Now);
ArrayList dateArrays = new ArrayList(dateList);
dateArrays.Add(DateTime.Now.AddDays(1));

Console.WriteLine(dateList.Count);      // 1
Console.WriteLine(dateArrays.Count);    // 2
dateArrays[0] = DateTime.Now.AddDays(-1);

Console.WriteLine(dateList[0]);    //Today
Console.WriteLine(dateArrays[0]);  //Yesterday


var words = new List<string>();    // New string-typed list

words.Add("melon");
words.Add("avocado");
words.AddRange(["banana", "plum"]);
words.Insert(0, "lemon");                   // Insert at start
words.InsertRange(0, ["peach", "nashi"]);   // Insert at start

words.Remove("melon");
words.RemoveAt(3);                         // Remove the 4th element
words.RemoveRange(0, 2);                   // Remove first 2 elements

// Remove all strings starting in 'n':
words.RemoveAll(s => s.StartsWith("n"));

Console.WriteLine(words[0]);                          // first word
Console.WriteLine(words[words.Count - 1]);            // last word
foreach (string w in words) Console.WriteLine(w);      // all words
List<string> subset = words.GetRange(1, 2);            // 2nd->3rd words

string[] wordsArray = words.ToArray();    // Creates a new typed array

// Copy first two elements to the end of an existing array:
string[] existing = new string[1000];
words.CopyTo(0, existing, 998, 2);

List<string> upperCaseWords = words.ConvertAll(s => s.ToUpper());
List<int> lengths = words.ConvertAll(s => s.Length);

ArrayList al = new ArrayList();
al.Add("hello");
string first = (string)al[0];
string[] strArr = (string[])al.ToArray(typeof(string));

//int firstNumber = (int)al[0];    // Runtime exception


ArrayList sampleArrayList = new ArrayList();
sampleArrayList.AddRange(new[] { 1, 5, 9 });
List<int> list = sampleArrayList.Cast<int>().ToList();

#endregion

#region LinkedList<T>

LinkedList<int> intLinkList = new LinkedList<int>();

var tune = new LinkedList<string>();
tune.AddFirst("do");                           // do
tune.AddLast("so");                            // do - so

tune.AddAfter(tune.First, "re");               // do - re- so
tune.AddAfter(tune.First.Next, "mi");          // do - re - mi- so
tune.AddBefore(tune.Last, "fa");               // do - re - mi - fa- so

tune.RemoveFirst();                             // re - mi - fa - so
tune.RemoveLast();                              // re - mi - fa

LinkedListNode<string> miNode = tune.Find("mi");
tune.Remove(miNode);                           // re - fa
tune.AddFirst(miNode);                         // mi- re - fa

foreach (string ts in tune) Console.WriteLine(ts);

#endregion

#region Queue<T> and Queue

var q = new Queue<int>();
q.Enqueue(10);
q.Enqueue(20);
int[] data = q.ToArray();         // Exports to an array
Console.WriteLine(q.Count);      // "2"
Console.WriteLine(q.Peek());     // "10"
Console.WriteLine(q.Dequeue());  // "10"
Console.WriteLine(q.Dequeue());  // "20"
//Console.WriteLine(q.Dequeue());  // throws an exception (queue empty)

#endregion

#region Stack<T> and Stack

var s = new Stack<int>();
s.Push(1);                      //            Stack = 1
s.Push(2);                      //            Stack = 1,2
s.Push(3);                      //            Stack = 1,2,3
Console.WriteLine(s.Count);     // Prints 3
Console.WriteLine(s.Peek());    // Prints 3,  Stack = 1,2,3
Console.WriteLine(s.Pop());     // Prints 3,  Stack = 1,2
Console.WriteLine(s.Pop());     // Prints 2,  Stack = 1
Console.WriteLine(s.Pop());     // Prints 1,  Stack = <empty>
//Console.WriteLine(s.Pop());     // throws exception

#endregion

#region BitArray

BitArray bitArray = new BitArray(new int[] { 10, 20 });
Console.WriteLine(bitArray.Length); // 64 bit, every int is 32 bit

var bits = new BitArray(2);
bits[1] = true;

bits.Xor(bits);               // Bitwise exclusive-OR bits with itself
Console.WriteLine(bits[1]);   // False

#endregion

#region HashSet<T> and SortedSet<T>

HashSet<int> set = new HashSet<int>();
set.Add(10);
set.Add(20);
set.Add(20);
Console.WriteLine(set.Count);  // 2

SortedSet<string> sortedStrings = new SortedSet<string>();
sortedStrings.Add("a");
sortedStrings.Add("c");
sortedStrings.Add("a");
sortedStrings.Add("b");
Console.WriteLine(sortedStrings.Count);  // 3

var letters = new HashSet<char>("the quick brown fox");

Console.WriteLine(letters.Contains('t'));      // true
Console.WriteLine(letters.Contains('j'));      // false

foreach (char c in letters) Console.Write(c);   // the quickbrownfx


letters = new HashSet<char>("the quick brown fox");
letters.IntersectWith("aeiou");
foreach (char c in letters) Console.Write(c);     // euio


letters = new HashSet<char>("the quick brown fox");
letters.ExceptWith("aeiou");
foreach (char c in letters) Console.Write(c);     // th qckbrwnfx


letters = new HashSet<char>("the quick brown fox");
letters.SymmetricExceptWith("the lazy brown fox");
Console.WriteLine();
foreach (char c in letters) Console.Write(c);     // quicklazy


var sortedLetters = new SortedSet<char>("the quick brown fox");
foreach (char c in sortedLetters) Console.Write(c);   //  bcefhiknoqrtuwx

foreach (char c in sortedLetters.GetViewBetween('f', 'i'))
    Console.Write(c);                                    //  fhi

#endregion