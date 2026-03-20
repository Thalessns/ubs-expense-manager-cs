namespace UBS.Expense.Manager.Application.Services.Despesa;

using UBS.Expense.Manager.Application.DTOs.Despesa;
using UBS.Expense.Manager.Domain.Entities;
using UBS.Expense.Manager.Domain.Enums;

public interface IDespesaService
{
    Task<DespesaResponse> CreateDespesa(DespesaRequest request);
    Task<DespesaResponse> GetDespesaById(Guid id);
    Task<List<DespesaResponse>> GetFilteredDespesas(
        Guid? funcionarioId,
        CategoriaDespesa? categoria,
        Moeda? moeda,
        StatusDespesa? status,
        DateTime? dataInicio,
        DateTime? dataFim
    );

    Task<DespesaResponse> UpdateDespesa(Guid id, StatusDespesa newStatus);

    Task<Boolean> DeleteDespesa(Guid id);
    DespesaResponse ToDespesaResponse(Despesa despesa);
    Despesa ToDespesa(DespesaRequest request);
}
