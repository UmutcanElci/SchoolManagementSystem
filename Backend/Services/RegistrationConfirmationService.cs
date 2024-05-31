using System.Text;
using Backend.Context;
using Backend.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class RegistrationConfirmationService
{
    private readonly MyDbContext _context;
    private readonly PasswordService _passwordService;

    public RegistrationConfirmationService(MyDbContext context, PasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }
   
    public async Task<List<Student>> GetStudentsWithoutStudentNumberAsync()
    {
        return await _context.Students
            .Where(s => s.StudentNumber == null)
            .ToListAsync();
    }

    public async Task<Student> GetStudentWithoutStudentNumberByIdAsync(int studentId)
    {
        return await _context.Students
            .Where(s => s.StudentNumber == null && s.Id == studentId)
            .FirstOrDefaultAsync();
    }
    
    public async Task CreateNewStudentAccountAsync(int studentId)
    {
        var student = await GetStudentWithoutStudentNumberByIdAsync(studentId);
        if (student == null)
        {
            throw new Exception("Student not found or already has a student number.");
        }

        // Generate Student Number
        student.StudentNumber = GenerateStudentNumber();

        // Generate Password
        var passwordId = await _passwordService.GenerateAndStorePasswordAsync();

        // Update Student with PasswordId
        student.PasswordId = passwordId;

        // Optionally, you can also update the parent record with the passwordId if needed.
        var parent = await _context.Parents.FindAsync(student.ParentId);
        if (parent != null)
        {
            parent.PasswordId = passwordId;
        }

        // Save changes to the database
        await _context.SaveChangesAsync();
    }

    private string GenerateStudentNumber()
    {
        var random = new Random();
        var studentNumber = new StringBuilder(9);
        for (int i = 0; i < 9; i++)
        {
            studentNumber.Append(random.Next(0, 10).ToString());
        }
        return studentNumber.ToString();
    }
}