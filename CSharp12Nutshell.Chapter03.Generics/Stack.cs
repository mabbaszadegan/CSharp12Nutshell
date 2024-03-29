using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter03.Generics
{
    public interface IPoppable<out T> { T Pop(); }
    public interface IPushable<in T> { void Push(T obj); }

    public class Stack<T> : IPoppable<T>, IPushable<T>
    {
        int position;
        T[] data = new T[100];
        public void Push(T obj) => data[position++] = obj;
        public T Pop() => data[--position];
        public Stack<T> Clone() => new Stack<T>();   // Legal
        public T this[int index] => data[index];
    }

    class A<T> where T : A<T>
    { }
    class A<T1, T2> { }
    class B<T> { void X() { Type t = typeof(T); } }

    public class ObjectStack
    {
        int position;
        object[] data = new object[10];
        public void Push(object obj) => data[position++] = obj;
        public object Pop() => data[--position];
    }

    class SpecialStack<T> : Stack<T> { } //open
    class IntStack<T> : Stack<int> { } //close

    class KeyedList<T, TKey> : List<T> { }

    class Bob<T>
    {
        public static int Count;
    }


}
