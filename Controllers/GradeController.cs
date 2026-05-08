using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradeController : ControllerBase
{
    private readonly IGradeService _gradeService;

    public GradeController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var grades = await _gradeService.GetAll();
        return Ok(grades);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Id must be a positive integer.");
        }

        var grade = await _gradeService.GetById(id);
        if (grade == null)
        {
            return NotFound($"Grade with Id {id} was not found.");
        }

        return Ok(grade);
    }

    [HttpGet("top/{n}")]
    public async Task<IActionResult> GetTopN(int n)
    {
        if (n <= 0)
        {
            return BadRequest("N must be a positive integer.");
        }

        var grades = await _gradeService.GetTopN(n);
        return Ok(grades);
    }
}
