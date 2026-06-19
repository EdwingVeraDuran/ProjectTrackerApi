using Microsoft.AspNetCore.Mvc;
using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Enums;
using ProjectTrackerApi.Services;

namespace ProjectTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : Controller
{
    private readonly IProjectService _service;

    public ProjectsController(IProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectResponseDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<ActionResult<ProjectResponseDto>> Create([FromBody] CreateProjectDto dto)
    {
        var project = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = project.Id }, project);
    }

    [HttpPut("{projectId}/status")]
    public async Task<IActionResult> UpdateStatus(int projectId, [FromBody] ProjectStatus status)
    {
        await _service.UpdateStatusAsync(projectId, status);
        return NoContent();
    }

    [HttpDelete("{projectId}")]
    public async Task<IActionResult> Delete(int projectId)
    {
        await _service.DeleteAsync(projectId);
        return NoContent();
    }
}
