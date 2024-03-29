using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter03.Generics
{
    class Animal { }
    class Bear : Animal
    {
        public Bear Pop()
        {
            throw new NotImplementedException();
        }
    }
    class Camel : Animal { }

    class ZooCleaner
    {
        // public static void Wash(Stack<Animal> animals) { }

        public static void Wash<T>(Stack<T> animals) where T : Animal { }
    }
}
