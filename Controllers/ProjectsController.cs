using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Services;
namespace ProjectTrackerApi.Controllers;

[ApiController]
[Route("api/projects")]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectResponseDto>>> GetAll()
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var projects = await _projectService.GetAllAsync(userId.Value);
        return Ok(new { projects });
    }

    [HttpGet("{projectId}")]
    public async Task<ActionResult<ProjectResponseDto>> GetById(Guid projectId)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var project = await _projectService.GetByIdAsync(projectId, userId.Value);
        if (project == null) return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectResponseDto>> Create([FromBody] CreateProjectDto dto)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var project = await _projectService.CreateAsync(dto, userId.Value);
        return CreatedAtAction(nameof(GetById), new { projectId = project.Id }, project);
    }

    [HttpPut("{projectId}")]
    public async Task<ActionResult<ProjectResponseDto>> Update(Guid projectId, [FromBody] UpdateProjectDto dto)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var project = await _projectService.UpdateAsync(projectId, dto, userId.Value);
        if (project == null) return NotFound();

        return Ok(project);
    }

    [HttpDelete("{projectId}")]
    public async Task<IActionResult> Delete(Guid projectId)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var deleted = await _projectService.DeleteAsync(projectId, userId.Value);
        if (!deleted) return NotFound();

        return NoContent();
    }

    private Guid? GetUserId()
    {
        var claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (claim == null) return null;
        return Guid.TryParse(claim, out var id) ? id : null;
    }
}
