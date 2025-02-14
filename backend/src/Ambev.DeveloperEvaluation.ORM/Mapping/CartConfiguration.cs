using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(c => c.UserId)
                .IsRequired();

            builder.Property(c => c.BranchId) //  referência à loja onde foi feita a venda
                .IsRequired();

            builder.Property(c => c.Date)
                .IsRequired();

            builder.Property(c => c.TotalPrice) //  Total do carrinho
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.IsCompleted) //  Status de finalizado
                .IsRequired();

            builder.Property(c => c.IsCancelled) //  Status de cancelado
                .IsRequired();

            // 1:N (Cart -> CartItems)
            builder.HasMany(c => c.Items)
                   .WithOne(ci => ci.Cart)
                   .HasForeignKey(ci => ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
