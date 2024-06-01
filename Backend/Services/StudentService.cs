using Backend.Context;
using Backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class StudentService
{
    private readonly MyDbContext _myDbContext;
    
    public StudentService(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }
    
    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _myDbContext.Students.ToListAsync();
    }
    public async Task<Student>? GetStudentByIdAsync(int studentId)
    {
        return await _myDbContext.Students.FirstOrDefaultAsync(s => s.Id == studentId) ?? throw new InvalidOperationException();
    }
    
}