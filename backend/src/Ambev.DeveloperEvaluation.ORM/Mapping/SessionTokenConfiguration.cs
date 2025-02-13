using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SessionTokenConfiguration : IEntityTypeConfiguration<SessionToken>
    {
        public void Configure(EntityTypeBuilder<SessionToken> builder)
        {
            builder.ToTable("SessionTokens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.ExpiresAt)
                .IsRequired();
        }
    }
}
