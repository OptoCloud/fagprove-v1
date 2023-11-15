using backend.Database.Models;

namespace backend.DTOs;

public class ApiProject
{
    public ApiProject(ProjectEntity projectEntity)
    {
        Id = projectEntity.Id;
        Title = projectEntity.Title;
        Description = projectEntity.Description;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
