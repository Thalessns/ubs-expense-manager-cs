using UBS.Expense.Manager.Infra.Exceptions;

namespace UBS.Expense.Manager.Infra.Repositories.Despesa;

using Microsoft.EntityFrameworkCore;
using UBS.Expense.Manager.Domain.Entities;
using UBS.Expense.Manager.Domain.Enums;
using UBS.Expense.Manager.Infra.Database;

public class DespesaRepository(DatabaseContext context) : IDespesaRepository
{
    public async Task CreateDespesa(Despesa despesa)
    {
        await context.Despesas.AddAsync(despesa);
        await context.SaveChangesAsync();
    }

    public async Task<Despesa> GetDespesaById(Guid id)
    {
        Despesa? despesa = await context.Despesas.FindAsync(id);
        if (despesa == null)
        {
            throw new NotFoundException($"Despesa with id {id} was not found.");
        }
        return despesa;
    }

    public async Task<List<Despesa>> GetFilteredDespesas(
        Guid? funcionarioId,
        CategoriaDespesa? categoria,
        Moeda? moeda,
        StatusDespesa? status,
        DateTime? dataInicio,
        DateTime? dataFim
    )
    {
        var query = context.Despesas.AsQueryable();

        if (funcionarioId.HasValue)
        {
            query = query.Where(d => d.FuncionarioId == funcionarioId);
        }
        if (categoria.HasValue)
        {
            query = query.Where(d => d.Categoria == categoria);
        }
        if (moeda.HasValue)
        {
            query = query.Where(d => d.Moeda == moeda);
        }
        if (status.HasValue)
        {
            query = query.Where(d => d.Status == status);
        }
        if (dataInicio.HasValue)
        {
            query = query.Where(d => d.Data >= dataInicio);
        }
        if (dataFim.HasValue)
        {
            query = query.Where(d => d.Data <= dataFim);
        }

        return await query.OrderBy(d => d.Data).ToListAsync();
    }

    public async Task<Despesa> UpdateDespesa(Despesa despesa)
    {
        context.Despesas.Update(despesa);
        await context.SaveChangesAsync();
        return despesa;
    }

    public async Task<Boolean> DeleteDespesa(Despesa despesa)
    {
        context.Despesas.Remove(despesa);
        await context.SaveChangesAsync();
        return true;
    }
}