using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UBS.Expense.Manager.Domain.Entities;

namespace UBS.Expense.Manager.Infra.Database.Config;

public class FuncionarioConfig : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.HasKey(f => f.Id);
        
        builder.Property(f => f.Nome)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(f => f.Email)
            .IsUnique();
        
        builder.Property(f => f.Cargo)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne<Departamento>()
            .WithMany()
            .HasForeignKey(f => f.DepartamentoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Funcionario>()
            .WithMany()
            .HasForeignKey(f => f.GestorId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
