using Backend.Context;
using Backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class ParentService
{
    private readonly MyDbContext _context;

    public ParentService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Parent> GetParentByIdAsync(int parentId)
    {
        return await _context.Parents.FirstOrDefaultAsync(p => p.Id == parentId);
    }
    public async Task<List<Parent>> GetAllParentsAsync()
    {
        return await _context.Parents.ToListAsync();
    }
}