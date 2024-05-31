using Backend.Migrations;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CanteenController : ControllerBase
{
    private readonly CanteenService _canteenService;

    public CanteenController(CanteenService canteenService)
    {
        _canteenService = canteenService;
    }
    
    [HttpGet("CanteenList")]
    public async Task<ActionResult<List<Canteen>>> GetCanteenListAsync()
    {
        var canteen =  await _canteenService.GetCanteenListAsync();
        return Ok(canteen);
    }
}