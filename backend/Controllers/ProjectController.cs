using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async IAsyncEnumerable<ApiProject> ListProjects()
    {
        Guid userId = Guid.Parse(User.Identity.Name!);

        var result = _projectService.GetProjectsByUserIdAsync(userId);

        await foreach (var project in result)
        {
            yield return new ApiProject(project);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProject([FromQuery] Guid projectId)
    {
        var result = await _projectService.GetProjectAsync(projectId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(new ApiProject(result));
    }
}