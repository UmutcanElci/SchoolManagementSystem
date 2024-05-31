using Backend.Context;
using Backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class TeacherService
{
    private readonly MyDbContext _context;
    
    public TeacherService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>> GetAllTeachersAsync()
    {
        return await _context.Teachers.ToListAsync();
    }
}