using Microsoft.AspNetCore.Mvc;
using ProjectTrackerApi.Data;

namespace ProjectTrackerApi.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    private readonly AppDbContext _db;

    public HealthController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var dbOk = await _db.Database.CanConnectAsync();

        return Ok(
            new
            {
                status = "healthy",
                database = dbOk ? "connected" : "unreachable",
                timestamp = DateTime.UtcNow,
            }
        );
    }
}
