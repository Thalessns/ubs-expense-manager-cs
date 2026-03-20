using UBS.Expense.Manager.Infra.Exceptions;

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

    public async Task<Departamento> GetDepartamentoById(Guid id)
    {
        Departamento? departamento = await context.Departamentos.FindAsync(id);
        if (departamento == null)
        {
            throw new NotFoundException($"Departamento with id {id} was not found.");
        }

        return departamento;
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
