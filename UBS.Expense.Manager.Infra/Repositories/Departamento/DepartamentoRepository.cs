namespace UBS.Expense.Manager.Infra.Repositories.Departamento;

using Microsoft.EntityFrameworkCore;
using UBS.Expense.Manager.Infra.Database;
using UBS.Expense.Manager.Domain.Entities;

public class DepartamentoRepository(DatabaseContext context) : IDepartamentoRepository
{
    public async Task CreateDepartamento(Departamento departamento)
    {
        await context.Departamentos.AddAsync(departamento);
        await context.SaveChangesAsync();
    }

    public async Task<Departamento?> GetDepartamentoById(Guid id)
    {
        return await context.Departamentos.FindAsync(id);
    }

    public async Task<List<Departamento>> GetAllDepartamentos()
    {
        return await context.Departamentos.OrderBy(d => d.Nome).ToListAsync();
    }

    public async Task<bool> DeleteDepartamento(Departamento departamento)
    {
        context.Departamentos.Remove(departamento);
        await context.SaveChangesAsync();
        return true;
    }
}
