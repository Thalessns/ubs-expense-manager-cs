namespace UBS.Expense.Manager.Infra.Repositories.Despesa;

using UBS.Expense.Manager.Domain.Entities;
using UBS.Expense.Manager.Domain.Enums;

public interface IDespesaRepository
{
    public Task CreateDespesa(Despesa despesa);
    public Task<Despesa?> GetDespesaById(Guid id);
    public Task<List<Despesa>> GetFilteredDespesas(
        Guid? funcionarioId,
        CategoriaDespesa? categoria,
        Moeda? moeda,
        StatusDespesa? status,
        DateTime? dataInicio,
        DateTime? dataFim
    );
    public Task<Despesa> UpdateDespesa(Despesa despesa);
    public Task<Boolean> DeleteDespesa(Despesa despesa);
}