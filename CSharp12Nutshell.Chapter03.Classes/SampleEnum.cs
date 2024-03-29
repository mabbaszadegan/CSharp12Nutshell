using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter03.Classes
{
    //enum BorderSides
    //{
    //    None = 0,
    //    Left = 1, 
    //    Right = 1 << 1, 
    //    Top = 1 << 2,
    //    Bottom = 1 << 3
    //}

    [Flags]
    enum BorderSides
    {
        None = 0,
        Left = 1, Right = 1 << 1, Top = 1 << 2, Bottom = 1 << 3,
        LeftRight = Left | Right,
        TopBottom = Top | Bottom,
        All = LeftRight | TopBottom
    }
}
