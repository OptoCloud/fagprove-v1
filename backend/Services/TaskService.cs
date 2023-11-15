using backend.Database;
using backend.Database.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace backend.Services;

public class TaskService : ITaskService
{
    readonly DatabaseContext _dbContext;
    readonly ILogger<TaskService> _logger;

    public TaskService(DatabaseContext databaseContext, ILogger<TaskService> logger)
    {
        _dbContext = databaseContext;
        _logger = logger;
    }

    public Task<TaskEntity?> GetTaskAsync(Guid taskId)
    {
        return _dbContext.Tasks.FirstOrDefaultAsync(e => e.Id == taskId);
    }

    public IAsyncEnumerable<TaskEntity> GetTasksByProjectIdAsync(Guid projectId)
    {
        return _dbContext.Tasks.Where(e => e.ProjectId == projectId).AsAsyncEnumerable();
    }

    public async Task<OneOf<TaskEntity, ApiError>> CreateTaskAsync(Guid projectId, string title, string description, DateTime dueDate, string status)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return new ApiError("Title cannot be empty");
        }

        if (await _dbContext.Tasks.AnyAsync(e => e.Title == title))
        {
            return new ApiError("Task with this title already exists");
        }

        var task = new TaskEntity
        {
            ProjectId = projectId,
            Title = title,
            Description = description,
            DueDate = dueDate,
            Status = status
        };

        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();

        return task;
    }

    public async Task<OneOf<TaskEntity, ApiError>> UpdateTaskAsync(Guid taskId, Action<TaskEntity> modifyAction)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(e => e.Id == taskId);

        if (task == null)
        {
            return new ApiError("Task not found");
        }

        modifyAction(task);

        await _dbContext.SaveChangesAsync();

        return task;
    }

    public async Task<OneOf<TaskEntity, ApiError>> DeleteTaskAsync(Guid taskId)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(e => e.Id == taskId);

        if (task == null)
        {
            return new ApiError("Task not found");
        }

        _dbContext.Tasks.Remove(task);
        await _dbContext.SaveChangesAsync();

        return task;
    }
}
