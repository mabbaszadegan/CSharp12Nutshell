using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.WhatsNew
{
    internal class SampleRequiredMembers
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
    }

    public interface IParsable<TSelf>
    {
        static abstract TSelf Parse(string s);
    }

    public class ParseString : IParsable<string>
    {
        public static string Parse(string s)
        {
            return $"{string.Join(",", s.ToArray())}";
        }
    }

    file class FileClass
    {
    }
}
