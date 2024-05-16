using CSharp12Nutshell.Chapter07.Dictionaries;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;

KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>("key1", "value1");
Console.WriteLine(keyValuePair.ToString());
keyValuePair.Deconstruct(out string key, out string value);
Console.WriteLine($"key:{key}, value:{value}");

Hashtable hashtable = new Hashtable();
hashtable.Add(1, "value1");
hashtable.Add(2, "value2");
hashtable.Add("3", 3);

#region IDictionary<TKey,TValue>

IDictionary<int, string> dict = new Dictionary<int, string>();
dict.Add(1, "value1");
dict[2] = "value 2";
dict[2] = "value2";
//dict.Add(2, "new value2");


var item1 = dict[1];
if (dict.ContainsKey(3))
{
    var item3 = dict[3];
}

var hasValue2 = dict.TryGetValue(2, out var item2);

foreach (var item in dict)
{
    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
}

#endregion

#region IDictionary

IDictionary sampleDictionary = new Hashtable();
sampleDictionary.Add(1, "value1");
sampleDictionary.Add(2, "value2");
foreach (DictionaryEntry item in sampleDictionary)
{
    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
}


#endregion

#region Dictionary<TKey,TValue> and Hashtable

var d = new Dictionary<string, int>();

d.Add("One", 1);
d["Two"] = 2;     // adds to dictionary because "two" isn't already present
d["Two"] = 22;    // updates dictionary because "two" is now present
d["Three"] = 3;

Console.WriteLine(d["Two"]);                // Prints "22"
Console.WriteLine(d.ContainsKey("One"));   // true (fast operation)
Console.WriteLine(d.ContainsValue(3));     // true (slow operation)
int val = 0;
if (!d.TryGetValue("onE", out val))
    Console.WriteLine("No val");              // "No val" (case sensitive)

// Three different ways to enumerate the dictionary:

foreach (KeyValuePair<string, int> kv in d)          //  One; 1
    Console.WriteLine(kv.Key + "; " + kv.Value);      //  Two; 22
                                                      //  Three; 3

foreach (string s in d.Keys) Console.Write(s);      // OneTwoThree
Console.WriteLine();
foreach (int i in d.Values) Console.Write(i);       // 1223

#endregion

#region OrderedDictionary

OrderedDictionary orderedDictionary = new OrderedDictionary();
orderedDictionary.Add("1", "value1");
orderedDictionary.Add("3", "value3");
orderedDictionary.Add("2", "value2");

Console.WriteLine(orderedDictionary[2]);

#endregion

#region ListDictionary and HybridDictionary

ListDictionary listDictionary = new ListDictionary();
HybridDictionary hybridDictionary = new HybridDictionary();
#endregion

#region Sorted Dictionaries

SortedDictionary<string,string> sortedDict = new SortedDictionary<string,string>();
sortedDict.Add("Ali", "value1");
sortedDict.Add("Negar", "value1");
sortedDict.Add("Omid", "value1");

// MethodInfo is in the System.Reflection namespace

var sorted = new SortedList<string, MethodInfo>();

foreach (MethodInfo m in typeof(object).GetMethods())
    sorted[m.Name] = m;

foreach (string name in sorted.Keys)
    Console.WriteLine(name);
/*
Equals
GetHashCode
GetType
ReferenceEquals
ToString
 */
foreach (MethodInfo m in sorted.Values)
    Console.WriteLine(m.Name + " returns a " + m.ReturnType);
/*
Equals returns a System.Boolean
GetHashCode returns a System.Int32
GetType returns a System.Type
ReferenceEquals returns a System.Boolean
ToString returns a System.String
 */

#endregion