using Backend.Context;
using Backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class RegistrationConfirmationService
{
    private readonly MyDbContext _context;

    public RegistrationConfirmationService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetStudentsWithoutStudentNumberAsync()
    {
        return await _context.Students
            .Where(s => s.StudentNumber == null)
            .ToListAsync();
    }

    public async Task CreateNewStudentAccountAsync()
    {
        //Generate Student Number 
        //Generate Password and add the Id to both Students and Parents
        //Send Email or sms
        return;
    }
}