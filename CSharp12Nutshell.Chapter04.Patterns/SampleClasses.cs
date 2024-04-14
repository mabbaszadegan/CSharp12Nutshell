using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter04.Patterns
{
    public class PointClass(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }

    public record PointRecord(int x, int y); // Has compiler-generated deconstructor


}
