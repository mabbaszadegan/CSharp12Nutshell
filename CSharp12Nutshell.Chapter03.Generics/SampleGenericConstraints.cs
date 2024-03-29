using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter03.Generics
{
    class SomeClass
    {
        public SomeClass(int a)
        {

        }
    }
    class SomeClass2 : SomeClass, Interface1
    {
        public SomeClass2() : base(2)
        {

        }
    }
    interface Interface1 { }
    class GenericClass<T, U> where T : SomeClass, Interface1
                                where U : new()
    {

    }
}
