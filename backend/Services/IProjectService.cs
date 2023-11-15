using backend.Database.Models;
using backend.DTOs;
using OneOf;

namespace backend.Services;

public interface IProjectService
{
    public Task<ProjectEntity?> GetProjectAsync(Guid projectId);

    public IAsyncEnumerable<ProjectEntity> GetProjectsByUserIdAsync(Guid userId);

    public Task<OneOf<ProjectEntity, ApiError>> CreateProjectAsync(Guid ownerUserId, string title, string description);

    public Task<OneOf<ProjectEntity, ApiError>> UpdateProjectAsync(Guid projectId, Action<ProjectEntity> modifyAction);

    public Task<OneOf<ProjectEntity, ApiError>> DeleteProjectAsync(Guid projectId);
}
