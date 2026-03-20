namespace UBS.Expense.Manager.Infra.Repositories.Funcionario;

using Microsoft.EntityFrameworkCore;
using UBS.Expense.Manager.Domain.Entities;
using UBS.Expense.Manager.Infra.Database;

public class FuncionarioRepository(DatabaseContext context) : IFuncionarioRepository
{
    public async Task CreateFuncionario(Funcionario funcionario)
    {
        await context.Funcionarios.AddAsync(funcionario);
        await context.SaveChangesAsync();
    }

    public async Task<Funcionario> GetFuncionarioById(Guid id)
    {
        return await context.Funcionarios.FindAsync(id);
    }

    public async Task<List<Funcionario>> GetAllFuncionarios()
    {
        return await context.Funcionarios.OrderBy(f => f.Nome).ToListAsync();
    }

    public async Task<Boolean> DeleteFuncionario(Funcionario funcionario)
    {
        context.Funcionarios.Remove(funcionario);
        await context.SaveChangesAsync();
        return true;
    }
}