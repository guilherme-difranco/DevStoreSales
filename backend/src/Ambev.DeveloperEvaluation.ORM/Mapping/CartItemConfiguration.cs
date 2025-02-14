using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(ci => ci.CartId)
                .IsRequired();

            builder.Property(ci => ci.ProductId)
                .IsRequired();

            builder.Property(ci => ci.Quantity)
                .IsRequired();

            builder.Property(ci => ci.UnitPrice) //  Preço unitário
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(ci => ci.Discount) //  Desconto aplicado
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Property(ci => ci.TotalAmount) // Total do item considerando o desconto
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
