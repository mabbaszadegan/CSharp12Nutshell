using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.WhatsNew
{
    public class SampleMoreExpressionBodiedMembers
    {
        string name;

        public SampleMoreExpressionBodiedMembers(string name) => Name = name;

        public string Name
        {
            get => name;
            set => name = value ?? "";
        }

        ~SampleMoreExpressionBodiedMembers() => Console.WriteLine("finalize");

        public void Deconstruct(out string firstName, out string lastName)
        {
            int spacePos = name.IndexOf(' ');
            firstName = name.Substring(0, spacePos);
            lastName = name.Substring(spacePos + 1);
        }
    }
}
