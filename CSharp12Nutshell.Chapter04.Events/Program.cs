using CSharp12Nutshell.Chapter04.Events;

var stockPC = new Stock("PC");

stockPC.PriceChanged += (s, e) =>
{
    Console.WriteLine($"PriceChanged...");
};

//stockPC.PriceChanged = (s, e) => { Console.WriteLine("It's me..."); }; // cannot assign
//stockPC.PriceChanged = null; // cannot set null;
//stockPC.PriceChanged(100, 200); // cannot invoke

stockPC.Price = 100;
stockPC.Price = 110;

#region Standard Event Pattern

#endregion
