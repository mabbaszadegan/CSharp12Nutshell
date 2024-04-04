using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter04.Delegates
{
    delegate int Transformer(int x);

    public delegate void ProgressReporter(int percentComplete);

    public delegate T Transformer<T>(T arg);

    delegate void D1();
    delegate void D2();

    delegate void StringAction(string s);

    delegate object ObjectRetriever();
}
