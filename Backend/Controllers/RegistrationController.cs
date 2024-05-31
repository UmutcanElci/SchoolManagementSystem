using Backend.Migrations;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly RegistrationService _registrationService;

    public RegistrationController(RegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var success = await _registrationService.RegisterStudentAsync(registerDto);
            if (success)
            {
                return Ok("Registration successful.");
            }
            else
            {
                return StatusCode(500, "Internal server error.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}