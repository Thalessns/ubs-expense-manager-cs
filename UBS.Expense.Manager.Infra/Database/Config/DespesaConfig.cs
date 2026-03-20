using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UBS.Expense.Manager.Domain.Entities;

namespace UBS.Expense.Manager.Infra.Database.Config;

public class DespesaConfig : IEntityTypeConfiguration<Despesa>
{
    public void Configure(EntityTypeBuilder<Despesa> builder)
    {
        builder.HasKey(d => d.Id);
        
        builder.HasOne<Funcionario>()
            .WithMany()
            .HasForeignKey(d => d.FuncionarioId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(d => d.Categoria)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(d => d.Valor)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(d => d.Moeda)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(d => d.Data)
            .IsRequired();

        builder.Property(d => d.Status)
            .IsRequired()
            .HasMaxLength(20);
    }
}