// See https://aka.ms/new-console-template for more information

using EFCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;

using (var _context = new AppDbContext()) 
{
    var product = await _context.Products.ToListAsync();

    product.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name}");
    });

}