using Microsoft.AspNetCore.Mvc;
using ProjectTrackerApi.DTOs;
using ProjectTrackerApi.Services;

namespace ProjectTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : Controller
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    [HttpGet("{taskId}")]
    public async Task<ActionResult<TaskResponseDto>> GetById([FromRoute] int taskId)
    {
        return Ok(await _service.GetById(taskId));
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskResponseDto>>> GetbyProjectId([FromQuery] int projectId)
    {
        return Ok(await _service.GetByProjectId(projectId));
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponseDto>> Create([FromBody] CreateTaskDto dto)
    {
        var task = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { taskId = task.Id }, task);
    }

    [HttpPatch("{taskId}/title")]
    public async Task<ActionResult> UpdateTitle(
        [FromRoute] int taskId,
        [FromBody] UpdateTaskTitleDto dto
    )
    {
        await _service.UpdateTitleAsync(taskId, dto);
        return NoContent();
    }

    [HttpPatch("{taskId}/status")]
    public async Task<ActionResult> UpdateStatus(
        [FromRoute] int taskId,
        [FromBody] UpdateTaskStatusDto dto
    )
    {
        await _service.UpdateStatusAsync(taskId, dto);
        return NoContent();
    }

    [HttpDelete("{taskId}")]
    public async Task<ActionResult> Delete([FromRoute] int taskId)
    {
        await _service.DeleteAsync(taskId);
        return NoContent();
    }
}
