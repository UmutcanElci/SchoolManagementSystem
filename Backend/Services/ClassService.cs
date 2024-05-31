﻿using Backend.Context;
using Backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class ClassService
{
    private readonly MyDbContext _context;

    public ClassService(MyDbContext context)
    {
        _context = context;
    }

    // List all classes
    public async Task<List<Class>> GetAllClassesAsync()
    {
        return await _context.Classes.ToListAsync();
    }

    // List classes by selected student's grade
    public async Task<List<Class>> GetClassesByGradeAsync(int grade)
    {
        return await _context.Classes
            .Where(c => c.Grade == grade)
            .ToListAsync();
    }

    // Add selected student to a class based on class ID
    public async Task<bool> AddStudentToClassAsync(int studentId, int classId)
    {
        var student = await _context.Students.FindAsync(studentId);
        if (student == null)
        {
            return false; // Student not found
        }

        var classEntity = await _context.Classes
            .FirstOrDefaultAsync(c => c.Id == classId && c.Grade == student.Grade);
        if (classEntity == null)
        {
            return false; // Class not found or grade mismatch
        }

        student.ClassId = classEntity.Id;
        await _context.SaveChangesAsync();
        return true;
    }
}