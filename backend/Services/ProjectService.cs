using backend.Database;
using backend.Database.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace backend.Services;

public class ProjectService : IProjectService
{
    public readonly DatabaseContext _dbContext;
    private readonly ILogger<ProjectService> _logger;

    public ProjectService(DatabaseContext dbContext, ILogger<ProjectService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<ProjectEntity?> GetProject(Guid projectId)
    {
        return _dbContext.Projects.FirstOrDefaultAsync(e => e.Id == projectId);
    }

    public IAsyncEnumerable<ProjectEntity> GetProjectsByUserId(Guid userId)
    {
        return _dbContext.Projects.Where(e => e.OwnerId == userId).AsAsyncEnumerable();
    }

    public async Task<OneOf<ProjectEntity, ApiError>> CreateProject(Guid ownerUserId, string title, string description)
    {
        var project = new ProjectEntity
        {
            OwnerId = ownerUserId,
            Title = title,
            Description = description
        };

        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();

        return project;
    }

    public async Task<OneOf<ProjectEntity, ApiError>> UpdateProject(Guid projectId, Action<ProjectEntity> action)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(e => e.Id == projectId);

        if (project == null)
        {
            return new ApiError("Project not found");
        }

        action(project);

        await _dbContext.SaveChangesAsync();

        return project;
    }

    public async Task<OneOf<ProjectEntity, ApiError>> DeleteProject(Guid projectId)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(e => e.Id == projectId);

        if (project == null)
        {
            return new ApiError("Project not found");
        }

        _dbContext.Projects.Remove(project);
        await _dbContext.SaveChangesAsync();

        return project;
    }
}
