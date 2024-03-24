using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter02.Types
{
    public class PointClass(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
    }

    public struct PointStruct(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
    }
}
