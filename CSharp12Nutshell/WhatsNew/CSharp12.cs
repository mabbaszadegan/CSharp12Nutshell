using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NumberList = double[];
using Point = (int X, int Y);

namespace CSharp12Nutshell.WhatsNew
{
    internal class CSharp12
    {
        private readonly char[] _chars;
        private readonly List<char> _list;
        private readonly HashSet<char> _set;

        public CSharp12()
        {
            _chars = ['a', 's', 'd'];
            _list = ['a', 's', 'd'];
            _set = ['a', 's', 'd'];
        }

        public string getValues()
        {

            return $"""
                chars: [{string.Join(",", _chars)}]
                list: [{string.Join(",", _list)}]
                set: [{string.Join(",", _set)}]

                """;
        }

        public int getLength(int[] numbers)
        {
            return numbers.Length;
        }
    }

    internal class ClassWithPrimaryConstructor(string firstName, string lastName)
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string SayHello() => $"Hello {firstName} {lastName}";
    }

    internal struct StructWithPrimaryConstructor(string firstName, string lastName)
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public readonly string SayHello() => $"Hello {firstName} {lastName}";
    }

    //[System.Runtime.CompilerServices.InlineArray(4)]
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    file class FileClass
    {
    }
}
