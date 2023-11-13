using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Database.Models;

public class TaskEntity
{
    public Guid Id { get; private set; }

    public Guid ProjectId { get; set; }
    public ProjectEntity Project { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public DateTime DueDate { get; set; }

    public required string Status { get; set; }

    public DateTime CreatedAt { get; private set; }
}

public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        builder.Property(e => e.Title).HasMaxLength(32);
        builder.Property(e => e.Description).HasMaxLength(512);
        builder.Property(e => e.DueDate).IsRequired();
        builder.Property(e => e.Status).HasMaxLength(32);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    }
}