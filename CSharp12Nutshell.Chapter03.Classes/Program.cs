// See https://aka.ms/new-console-template for more information
using CSharp12Nutshell.Chapter03.Classes;

Console.WriteLine("Hello, World!");


#region Deconstructors

var rect = new SampleDeconstructor(3, 4, "test");
(float width, float height, string name) = rect;          // Deconstruction
Console.WriteLine(width + " " + height + " " + name);    // 3 4 test

var (w, h) = rect;          // Deconstruction
Console.WriteLine(w + " " + h);    // 3 4

rect.Deconstruct(out var n);        // Deconstruction
Console.WriteLine(n);    // test

#endregion