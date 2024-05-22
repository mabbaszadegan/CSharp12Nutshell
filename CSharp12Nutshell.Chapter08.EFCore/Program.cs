using CSharp12Nutshell.Chapter08.EFCore;
using CSharp12Nutshell.Chapter08.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

#region DbContext

//TestDB();

void TestDB()
{

    //NutshellDbContext nutshellDbContext = new NutshellDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<NutshellDbContext>
    //{

    //});

    //var dbCreated = nutshellDbContext.Database.EnsureCreated();
    //Console.WriteLine(dbCreated);


    using var dbContext = new NutshellDbContext();
    Console.WriteLine(dbContext.Customers.Count());
    // Executes "SELECT COUNT(*) FROM [Customer] AS [c]"


    Customer cust = new Customer()
    {
        Name = "Sara Wells"
    };
    dbContext.Customers.Add(cust);
    dbContext.SaveChanges();    // Writes changes back to database


    Customer customer = dbContext.Customers
      .Single(c => c.Name == "Sara Wells");

    customer.Name = "Dr. Sara Wells";
    dbContext.SaveChanges();
}
#endregion

#region Object Tracking

using (var dbContext = new NutshellDbContext())
{

    Customer a = dbContext.Customers.OrderBy(c => c.Name).First();
    Customer b = dbContext.Customers.Single(c => c.Id == 2);
    Customer c = dbContext.Customers.AsNoTracking().Single(c => c.Id == 2);
    List<Customer> customers = dbContext.Customers.ToList();
    List<Customer> customersNotracking = dbContext.Customers.AsNoTracking().ToList();
    a.Name = "it's changed";

    Console.WriteLine(
                        $"\n{a.Name} " +                       // it's changed
                        $"\n{b.Name} " +                       // it's changed
                        $"\n{c.Name}" +                        // David
                        $"\n{customers[1].Name}" +             // it's changed
                        $"\n{customersNotracking[1].Name}" +   // David
                        $"");
}

#endregion

#region Change Tracking

using (var dbContext = new NutshellDbContext())
{
    List<Customer> customers = dbContext.Customers.ToList();
    customers[0].Address = "London";
    customers[1].Name = "Joe";
    dbContext.Customers.Add(new Customer { Name = "Peter", Address = "Paris" });

    var productAsNoTracking = dbContext.Products.OrderBy(p => p.Name).AsNoTracking().FirstOrDefault();
    productAsNoTracking.Quantity = 50;
    var product = dbContext.Products.OrderBy(p => p.Name).LastOrDefault();
    product.Quantity = 30;

    foreach (var e in dbContext.ChangeTracker.Entries())
    {
        Console.WriteLine($"{e.Entity.GetType().FullName} is {e.State}");
        foreach (var m in e.Members)
            Console.WriteLine(
              $"  {m.Metadata.Name}: '{m.CurrentValue}' modified: {m.IsModified}");
    }
}

#endregion

#region Navigation Properties

using (var dbContext = new NutshellDbContext())
{
    List<Customer> customers = dbContext.Customers.ToList();
    var customersWithPurchases = customers.Where(c => c.Purchases.Any());


    Customer cust = dbContext.Customers.Single(c => c.Id == 1);

    Purchase p1 = new Purchase { Description = "Bike", Price = 500 };
    Purchase p2 = new Purchase { Description = "Tools", Price = 100 };

    cust.Purchases.Add(p1);
    cust.Purchases.Add(p2);

    dbContext.SaveChanges();


    var customer = dbContext.Customers.First();
    Console.WriteLine(customer.Purchases.Count);    // Always 0

    var customerIncludePurchases = dbContext.Customers
              .Include(c => c.Purchases)
              .Where(c => c.Id == 2).First();

    var custInfo = dbContext.Customers
              .Where(c => c.Id == 2)
              .Select(c => new
              {
                  Name = c.Name,
                  Purchases = c.Purchases.Select(p => new { p.Description, p.Price })
              })
              .First();
}

#endregion

#region Lazy loading

#endregion

