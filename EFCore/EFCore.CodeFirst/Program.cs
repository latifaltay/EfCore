// See https://aka.ms/new-console-template for more information
using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();
Console.WriteLine("Hello, World!");



using (var _context = new AppDbContext())
{
    // For Old Data

    var product = await _context.Products.FirstAsync();


    Console.WriteLine($"ilk state  {_context.Entry(product).State}");

    _context.Entry(product).State = EntityState.Detached;
    Console.WriteLine($"Son state  {_context.Entry(product).State}");

    product.Name = "Kalem 2000";
    Console.WriteLine($"Son 2 state  {_context.Entry(product).State}");

    //_context.Entry(product).State = EntityState.Deleted;
    //_context.Remove(product);


    Console.WriteLine($"ikinci state  {_context.Entry(product).State}");

    await _context.SaveChangesAsync();

    Console.WriteLine($"Save Change state  {_context.Entry(product).State}");

    // For New Data
    //var newProduct = new Product { Name = "kalem 300", Price = 200, Stock = 100, Barcode = 123 };

    //Console.WriteLine($"ilk state  {_context.Entry(newProduct).State}");

    //_context.Entry(newProduct).State = EntityState.Added;
    ////await _context.AddAsync(newProduct);

    //Console.WriteLine($"ikinci state  {_context.Entry(newProduct).State}");


    //Console.WriteLine(_context.Entry(newProduct).State);

    //await _context.SaveChangesAsync();

    //Console.WriteLine($"Save Change state  {_context.Entry(newProduct).State}");


    //var products = await _context.Products.ToListAsync();

    //products.ForEach(p =>
    //{
    //    var state = _context.Entry(p).State;
    //    Console.WriteLine($"{p.Id} : {p.Name} - {p.Price} - {p.Stock} state: {state}");
    //});
}