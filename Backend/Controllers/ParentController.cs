using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParentController : ControllerBase
{
    private readonly ParentService _parentService;

    public ParentController(ParentService parentService)
    {
        _parentService = parentService;
    }

    [HttpGet("{parentId}")]
    public async Task<IActionResult> GetParentById(int parentId)
    {
        var parent = await _parentService.GetParentByIdAsync(parentId);
        if (parent == null)
        {
            return NotFound();
        }
        return Ok(parent);
    }
    [HttpGet("GetAllParents")]
    public async Task<IActionResult> GetAllParents()
    {
        var parents = await _parentService.GetAllParentsAsync();
        return Ok(parents);
    }
}