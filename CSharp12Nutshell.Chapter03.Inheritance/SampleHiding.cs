using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter03.Inheritance
{
    public class A { public int Counter = 1; }
    public class B : A { public int Counter = 2; }


    public class BaseClass
    {
        public virtual void Foo() { Console.WriteLine("BaseClass.Foo"); }
    }

    public class Overrider : BaseClass
    {
        public override void Foo() { Console.WriteLine("Overrider.Foo"); }
    }

    public class Hider : BaseClass
    {
        public new void Foo() { Console.WriteLine("Hider.Foo"); }
    }

    public class Baseclass
    {
        public int X;
        public Baseclass() { }
        public Baseclass(int x) => X = x;
    }

    public class Subclass : Baseclass
    {
        public Subclass(int x) : base(x) { }
    }
}
