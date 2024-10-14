// See https://aka.ms/new-console-template for more information
using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();
Console.WriteLine("Hello, World!");



using (var _context = new AppDbContext())
{



    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        var state = _context.Entry(p).State;
        Console.WriteLine($"{p.Id} : {p.Name} - {p.Price} - {p.Stock} state: {state}");
    });
}