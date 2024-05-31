using Backend.Migrations;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationConfirmationController : ControllerBase
{
    private readonly RegistrationConfirmationService _registrationConfirmationService;

    public RegistrationConfirmationController(RegistrationConfirmationService registrationConfirmationService)
    {
        _registrationConfirmationService = registrationConfirmationService;
    }

    [HttpGet("StudentsWithoutStudentNumber")]
    public async Task<ActionResult<List<Student>>> GetStudentsWithoutStudentNumber()
    {
        var students = await _registrationConfirmationService.GetStudentsWithoutStudentNumberAsync();
        return Ok(students);
    }
    [HttpPost("CreateNewStudentAccount/{studentId}")]
    public async Task<ActionResult> CreateNewStudentAccount(int studentId)
    {
        try
        {
            await _registrationConfirmationService.CreateNewStudentAccountAsync(studentId);
            return Ok("Student account created successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}