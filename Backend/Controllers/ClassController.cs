using Backend.Migrations;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassController : ControllerBase
{
    private readonly ClassService _classService;

    public ClassController(ClassService classService)
    {
        _classService = classService;
    }

    // Endpoint to list all classes
    [HttpGet("GetAllClasses")]
    public async Task<ActionResult<List<Class>>> GetAllClasses()
    {
        var classes = await _classService.GetAllClassesAsync();
        return Ok(classes);
    }

    // Endpoint to list classes by grade
    [HttpGet("GetClassesByGrade/{grade}")]
    public async Task<ActionResult<List<Class>>> GetClassesByGrade(int grade)
    {
        var classes = await _classService.GetClassesByGradeAsync(grade);
        return Ok(classes);
    }

    // Endpoint to add a student to a class based on class ID
    [HttpPost("AddStudentToClass")]
    public async Task<ActionResult> AddStudentToClass(int studentId, int classId)
    {
        var result = await _classService.AddStudentToClassAsync(studentId, classId);
        if (result)
        {
            return Ok("Student added to class successfully.");
        }
        return BadRequest("Failed to add student to class.");
    }
}