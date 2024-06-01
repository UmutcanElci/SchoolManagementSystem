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

    [HttpGet("GetAllClasses")]
    public async Task<IActionResult> GetAllClasses()
    {
        var classes = await _classService.GetAllClassesAsync();
        return Ok(classes);
    }

    [HttpGet("GetClassesByGrade/{grade}")]
    public async Task<IActionResult> GetClassesByGrade(int grade)
    {
        var classes = await _classService.GetClassesByGradeAsync(grade);
        return Ok(classes);
    }

    [HttpPost("AddStudentToClass")]
    public async Task<IActionResult> AddStudentToClass([FromQuery] int studentId, [FromQuery] int classId)
    {
        var result = await _classService.AddStudentToClassAsync(studentId, classId);
        if (result)
        {
            return Ok();
        }
        else
        {
            return BadRequest("Could not add student to class.");
        }
    }
    [HttpGet("GetStudentsWithoutClass")]
    public async Task<IActionResult> GetStudentsWithoutClass()
    {
        var students = await _classService.GetStudentsWithoutClassAsync();
        return Ok(students);
    }
}