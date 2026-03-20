using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UBS.Expense.Manager.Domain.Entities;

namespace UBS.Expense.Manager.Infra.Database.Config;

public class DepartamentoConfig : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.HasKey(d => d.Id);
        
        builder.Property(d => d.Nome)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.OrcamentoMensal)
            .IsRequired()
            .HasPrecision(18, 2);
    }
}
