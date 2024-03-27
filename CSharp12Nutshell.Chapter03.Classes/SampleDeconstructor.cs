using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter03.Classes
{
    internal class SampleDeconstructor
    {
        private readonly float Width, Height;

        private readonly string Name;

        public SampleDeconstructor(float width, float height, string name) =>
            (Width, Height, Name) = (width, height, name);

        public void Deconstruct(out float width, out float height, out string name)
        {
            width = Width;
            height = Height;
            name = Name;
        }
        public void Deconstruct(out float width, out float height)
        {
            width = Width;
            height = Height;
        }

        public void Deconstruct(out string name)
        {
            name = Name;
        }
    }
}
