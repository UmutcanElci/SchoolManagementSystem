using Backend.Migrations;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly CityService _cityService;

    public CityController(CityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet("GetAllCities")]
    public async Task<ActionResult<List<City>>> GetAllCities()
    {
        var cities = await _cityService.GetAllCitiesAsync();
        return Ok(cities);
    }

    [HttpGet("GetCityById/{id}")]
    public async Task<ActionResult<City>> GetCityById(int id)
    {
        var city = await _cityService.GetCityByIdAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        return Ok(city);
    }
}