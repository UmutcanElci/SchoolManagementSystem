using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;
    
    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }
    
    [HttpGet("GetAllStudents")]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    }

    [HttpGet("GetStudentsById/{Id}")]
    public async Task<IActionResult> GetStudentsByGrade(int Id)
    {
        var students = await _studentService.GetStudentByIdAsync(Id);
        return Ok(students);
    }
    
}