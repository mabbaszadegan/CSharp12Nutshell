using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.WhatsNew
{
    class SampleIndicesAndRanges
    {
        string[] words = "The quick brown fox".Split();

        public string this[Index index] => words[index];
        public string[] this[Range range] => words[range];
    }

    struct SampleReadOnlyMembers
    {
        public int X, Y;
        //public readonly void ResetX() => X = 0;  // Error!
    }

    file interface ILogger
    {
        void Log(string text) => Console.WriteLine(Prefix + text);
        static string Prefix = "";
    }

    file class SampleAsynchronousStreams
    {
        async IAsyncEnumerable<int> RangeAsync(int start, int count, int delay)
        {
            for (int i = start; i < start + count; i++)
            {
                await Task.Delay(delay);
                yield return i;
            }
        }

        public async Task write()
        {
            await foreach (var number in RangeAsync(0, 10, 100))
                Console.WriteLine(number);
        }
    }
}
