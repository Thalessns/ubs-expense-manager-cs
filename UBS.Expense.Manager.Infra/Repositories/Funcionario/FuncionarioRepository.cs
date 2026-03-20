using Npgsql;
using UBS.Expense.Manager.Infra.Exceptions;

namespace UBS.Expense.Manager.Infra.Repositories.Funcionario;

using Microsoft.EntityFrameworkCore;
using UBS.Expense.Manager.Domain.Entities;
using UBS.Expense.Manager.Infra.Database;

public class FuncionarioRepository(DatabaseContext context) : IFuncionarioRepository
{
    public async Task CreateFuncionario(Funcionario funcionario)
    {
        try
        {
            await context.Funcionarios.AddAsync(funcionario);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                throw new BadRequestException($"Email '{funcionario.Email}' already exists.");
            }
            throw new Exception(ex.Message);
        }
        
    }

    public async Task<Funcionario> GetFuncionarioById(Guid id)
    {
        Funcionario? funcionario = await context.Funcionarios.FindAsync(id);
        if (funcionario == null)
        {
            throw new NotFoundException($"Funcionario with  id {id} was not found.");
        }
        return funcionario;
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