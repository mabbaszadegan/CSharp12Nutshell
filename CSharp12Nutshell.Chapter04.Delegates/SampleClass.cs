using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter04.Delegates
{
    internal class SampleClass
    {
        public static int Square(int x) => x * x;
        public int Cube(int x) => x * x * x;
    }

    class Squarer : ITransformer
    {
        public int Transform(int x) => x * x;
    }

    class Cube : ITransformer
    {
        public int Transform(int x) => x * x * x;
    }

    public class Util
    {
        public static void HardWork(ProgressReporter p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * 10);                           // Invoke delegate
                System.Threading.Thread.Sleep(100);  // Simulate hard work
            }
        }

        public static void Transform<T>(T[] values, Transformer<T> t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t(values[i]);
        }

        public static void TransformWithFunc<T>(T[] values, Func<T, T> transformer)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = transformer(values[i]);
        }

        public static void TransformAll(int[] values, ITransformer t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t.Transform(values[i]);
        }
    }
}
