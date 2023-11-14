using backend.Database.Models;
using backend.DTOs;
using OneOf;

namespace backend.Services;

public interface IProjectService
{
    public Task<ProjectEntity?> GetProject(Guid projectId);

    public IAsyncEnumerable<ProjectEntity> GetProjectsByUserId(Guid userId);

    public Task<OneOf<ProjectEntity, ApiError>> CreateProject(Guid ownerUserId, string title, string description);

    public Task<OneOf<ProjectEntity, ApiError>> UpdateProject(Guid projectId, Action<ProjectEntity> modifyAction);

    public Task<OneOf<ProjectEntity, ApiError>> DeleteProject(Guid projectId);
}
