using Backend.Migrations;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DistrictController : ControllerBase
{
    public readonly DistrictService _districtService;
    public DistrictController(DistrictService districtService)
    {
        _districtService = districtService;
    }
    [HttpGet("GetAllDistrict")]
    public async Task<ActionResult<List<District>>> GetAllDistrictAsync()
    {
        var district = await _districtService.GetAllDistrictAsync();
        return Ok(district);
    }
    
}