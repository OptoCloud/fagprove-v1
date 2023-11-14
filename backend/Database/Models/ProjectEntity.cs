using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Database.Models;

public class ProjectEntity
{
    public Guid Id { get; private set; }

    public Guid OwnerId { get; set; }
    public UserEntity Owner { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public DateTime CreatedAt { get; private set; }

    public ICollection<TaskEntity> Tasks { get; set; }
}

public class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        builder.Property(e => e.OwnerId).IsRequired();
        builder.Property(e => e.Title).HasMaxLength(32);
        builder.Property(e => e.Description).HasMaxLength(512);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

        builder.HasOne(e => e.Owner).WithMany(e => e.Projects).HasForeignKey(e => e.OwnerId);
        builder.HasMany(e => e.Tasks).WithOne(e => e.Project).HasForeignKey(e => e.ProjectId);
    }
}
