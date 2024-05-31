using Backend.Context;
using Backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class CanteenService
{
    private readonly MyDbContext _context;
    public CanteenService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Canteen>> GetCanteenListAsync()
    {
        return await _context.Canteens.Select(c => new Canteen
        {
            Foods = c.Foods,
            Price = c.Price
        }).ToListAsync();
    }
}