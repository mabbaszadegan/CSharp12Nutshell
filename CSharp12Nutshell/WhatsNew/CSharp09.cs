using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.WhatsNew
{
    internal class SampleInitOnlySetters
    {
        public int Id { get; init; }
        public string Name { get; set; }
    }

    internal record SampleRecord
    {
        public SampleRecord()
        {
            Name = string.Empty;
        }
        public SampleRecord(int id, string name) => (Id, Name) = (id, name);

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
