using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            // Nome da tabela (opcional, se quiser mudar o default)
            builder.ToTable("Sales");

            // Chave primária
            builder.HasKey(s => s.Id);

            // Exemplos de configuração de colunas
            builder.Property(s => s.SaleNumber)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(s => s.CustomerName)
                   .HasMaxLength(100)
                   .IsRequired();

            // Relacionamento (1 Sale -> muitos SaleItems)
            builder.HasMany(s => s.Items)
                   .WithOne(i => i.Sale)
                   .HasForeignKey(i => i.SaleId);
        }
    }
}
