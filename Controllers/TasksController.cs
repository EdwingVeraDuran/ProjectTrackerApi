using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Services;

namespace ProjectTrackerApi.Controllers;

[ApiController]
[Route("api/projects/{projectId}/tasks")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskResponseDto>>> GetAll(Guid projectId)
    {
        var userId = GetUserId();
        if (userId == null)
            return Unauthorized();

        var tasks = await _taskService.GetByProjectIdAsync(projectId, userId.Value);
        return Ok(tasks);
    }

    [HttpGet("{taskId}")]
    public async Task<ActionResult<TaskResponseDto>> GetById(Guid projectId, Guid taskId)
    {
        var userId = GetUserId();
        if (userId == null)
            return Unauthorized();

        var task = await _taskService.GetByIdAsync(projectId, taskId, userId.Value);
        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponseDto>> Create(
        Guid projectId,
        [FromBody] CreateTaskDto dto
    )
    {
        var userId = GetUserId();
        if (userId == null)
            return Unauthorized();

        var task = await _taskService.CreateAsync(projectId, dto, userId.Value);
        if (task == null)
            return NotFound();

        return CreatedAtAction(nameof(GetById), new { projectId, taskId = task.Id }, task);
    }

    [HttpPut("{taskId}")]
    public async Task<ActionResult<TaskResponseDto>> Update(
        Guid projectId,
        Guid taskId,
        [FromBody] UpdateTaskDto dto
    )
    {
        var userId = GetUserId();
        if (userId == null)
            return Unauthorized();

        var task = await _taskService.UpdateAsync(projectId, taskId, dto, userId.Value);
        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpDelete("{taskId}")]
    public async Task<IActionResult> Delete(Guid projectId, Guid taskId)
    {
        var userId = GetUserId();
        if (userId == null)
            return Unauthorized();

        var deleted = await _taskService.DeleteAsync(projectId, taskId, userId.Value);
        if (!deleted)
            return NotFound();

        return NoContent();
    }

    private Guid? GetUserId()
    {
        var claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (claim == null)
            return null;
        return Guid.TryParse(claim, out var id) ? id : null;
    }
}
