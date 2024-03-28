using CSharp12Nutshell.Chapter03.Inheritance;

Stock msft = new Stock
{
    Name = "MSFT",
    SharesOwned = 1000
};

Console.WriteLine(msft.Name);         // MSFT
Console.WriteLine(msft.SharesOwned);  // 1000

House mansion = new House
{
    Name = "Mansion",
    Mortgage = 250000
};

Console.WriteLine(mansion.Name);      // Mansion
Console.WriteLine(mansion.Mortgage);  // 250000

#region Polymorphism

static void Display(Asset asset)
{
    System.Console.WriteLine(asset.Name);
}

Stock stock = new Stock();
House house = new House();

Display(stock);
Display(house);


static void DisplayHouse(House house)         // Will not accept Asset
{
    System.Console.WriteLine(house.Mortgage);
}

//DisplayHouse(new Asset());     // Compile-time error

#endregion

#region Casting and Reference Conversions

Stock s = new Stock();
Asset a = s;              // Upcast

Console.WriteLine(a == s);        // True

Console.WriteLine(a.Name);           // OK
                                     //Console.WriteLine(a.SharesOwned);    // Compile-time error

msft = new Stock();
a = msft;                      // Upcast
s = (Stock)a;                  // Downcast
Console.WriteLine(s.SharesOwned);   // <No error>
Console.WriteLine(s == a);          // True
Console.WriteLine(s == msft);       // True

House h = new House();
Asset a2 = h;               // Upcast always succeeds
//Stock s2 = (Stock)a2;        // Downcast fails: a is not a Stock

s = a as Stock;       // s is null; no exception thrown

//long x = 3 as long;    // Compile-time error

if (a is Stock)
    Console.WriteLine(((Stock)a).SharesOwned);

if (a is Stock ss)
    Console.WriteLine(ss.SharesOwned);

if (a is Stock s3 && s3.SharesOwned > 100000)
    Console.WriteLine("Wealthy");

if (a is Stock s4 && s4.SharesOwned > 100000)
    Console.WriteLine("Wealthy");
else
    s4 = new Stock();   // s is in scope

Console.WriteLine(s4.SharesOwned);  // Still in scope



#endregion

#region Virtual Function Members
mansion = new House { Name = "McMansion", Mortgage = 250000 };
a = mansion;
Console.WriteLine(mansion.Liability);  // 250000
Console.WriteLine(a.Liability);        // 250000
Console.WriteLine(stock.Liability);        // 0

#endregion

#region Hiding Inherited Members

Console.WriteLine(new A().Counter);
Console.WriteLine(new B().Counter);

Overrider over = new Overrider();
BaseClass b1 = over;
over.Foo();                         // Overrider.Foo
b1.Foo();                           // Overrider.Foo

Hider hider = new Hider();
BaseClass b2 = hider;
hider.Foo();                           // Hider.Foo
b2.Foo();                          // BaseClass.Foo

#endregion

#region The base Keyword

Subclass subclass = new Subclass(123);
#endregion
