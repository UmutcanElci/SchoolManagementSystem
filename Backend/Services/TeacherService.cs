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

    // Get all teachers
    public async Task<List<Teacher>> GetAllTeachersAsync()
    {
        return await _context.Teachers.ToListAsync();
    }

    // Add teacher to a class
    public async Task<bool> AddTeacherToClassAsync(int teacherId, int classId)
    {
        var teacher = await _context.Teachers.FindAsync(teacherId);
        if (teacher == null)
        {
            return false; // Teacher not found
        }

        var classEntity = await _context.Classes.FindAsync(classId);
        if (classEntity == null)
        {
            return false; // Class not found
        }

        // Check if the teacher is already assigned to the class
        var existingAssignment = await _context.ClassesAndTeachers
            .FirstOrDefaultAsync(ct => ct.ClassId == classId && ct.TeacherId == teacherId);
        if (existingAssignment != null)
        {
            return false; // Teacher already assigned to the class
        }

        // Create a new entry in the join table ClassesAndTeachers
        _context.ClassesAndTeachers.Add(new ClassesAndTeacher { ClassId = classId, TeacherId = teacherId });
        await _context.SaveChangesAsync();
        return true;
    }
}