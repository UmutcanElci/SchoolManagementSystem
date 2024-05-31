using Backend.Context;
using Backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class DistrictService
{
    private readonly MyDbContext _context;
    
    public DistrictService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<District>> GetAllDistrictAsync()
    {
        return await _context.Districts.ToListAsync();
    }
}