using Backend.Context;
using Backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class CityService
{
    private readonly MyDbContext _context;
    private readonly ILogger<CityService> _logger;

    public CityService(MyDbContext context, ILogger<CityService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<City>> GetAllCitiesAsync()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task<City> GetCityByIdAsync(int id)
    {
        var city = await _context.Cities.FindAsync(id);

        if (city == null)
        {
            _logger.LogWarning("City with Id {Id} not found.", id);
        }
        else
        {
            _logger.LogInformation("City with Id {Id} retrieved successfully.", id);
        }

        return city;
    }
}