using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Database.Models;

public class AuthTokenEntity
{
    public Guid Id { get; private set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }

    public required string TokenHash { get; set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime ExpiresAt { get; private set; }
}

public class AuthTokenEntityConfiguration : IEntityTypeConfiguration<AuthTokenEntity>
{
    public void Configure(EntityTypeBuilder<AuthTokenEntity> builder)
    {
        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        builder.Property(e => e.TokenHash).HasMaxLength(512);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
        builder.Property(e => e.ExpiresAt).HasDefaultValueSql("now() + interval '1 day'"); // Auth tokens expire after 1 day

        builder.HasIndex(e => e.TokenHash).IsUnique();
    }
}
