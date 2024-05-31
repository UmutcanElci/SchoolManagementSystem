using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly TeacherService _teacherService;

    public TeacherController(TeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    // Endpoint to get all teachers
    [HttpGet("GetAllTeachers")]
    public async Task<IActionResult> GetAllTeachers()
    {
        var teachers = await _teacherService.GetAllTeachersAsync();
        return Ok(teachers);
    }

    // Endpoint to add a teacher to a class
    [HttpPost("AddTeacherToClass")]
    public async Task<IActionResult> AddTeacherToClass(int teacherId, int classId)
    {
        var result = await _teacherService.AddTeacherToClassAsync(teacherId, classId);
        if (result)
        {
            return Ok("Teacher added to class successfully.");
        }
        return BadRequest("Failed to add teacher to class.");
    }
}