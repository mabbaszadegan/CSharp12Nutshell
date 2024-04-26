using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter07.Collections
{
    public class MyCollection : IEnumerable
    {
        int[] data = { 1, 2, 3 };

        public IEnumerator GetEnumerator()
        {
            foreach (int i in data)
                yield return i;
        }
    }

    public class MyGenCollection : IEnumerable<int>
    {
        int[] data = { 1, 2, 3 };

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int i in data)
                yield return i;
        }

        // Explicit implementation keeps it hidden:
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
