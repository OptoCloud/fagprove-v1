using backend.Database.Models;
using backend.DTOs;
using OneOf;

namespace backend.Services;

public interface ITaskService
{
    public Task<TaskEntity?> GetTaskAsync(Guid taskId);

    public IAsyncEnumerable<TaskEntity> GetTasksByProjectIdAsync(Guid projectId);

    public Task<OneOf<TaskEntity, ApiError>> CreateTaskAsync(Guid projectId, string title, string description, DateTime dueDate, string status);

    public Task<OneOf<TaskEntity, ApiError>> UpdateTaskAsync(Guid taskId, Action<TaskEntity> modifyAction);

    public Task<OneOf<TaskEntity, ApiError>> DeleteTaskAsync(Guid taskId);
}
