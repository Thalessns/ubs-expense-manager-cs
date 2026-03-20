namespace UBS.Expense.Manager.Application.Services.Despesa;

using UBS.Expense.Manager.Application.DTOs.Despesa;
using UBS.Expense.Manager.Domain.Entities;
using UBS.Expense.Manager.Domain.Enums;
using UBS.Expense.Manager.Infra.Repositories.Despesa;

public class DespesaService : IDespesaService
{
    private readonly IDespesaRepository _repository;

    public DespesaService(IDespesaRepository repository)
    {
        _repository = repository;
    }

    public async Task<DespesaResponse> CreateDespesa(DespesaRequest request)
    {
        Despesa despesa = ToDespesa(request);
        await _repository.CreateDespesa(despesa);
        return ToDespesaResponse(despesa);
    }

    public async Task<DespesaResponse> GetDespesaById(Guid id)
    {
        Despesa? despesa = await _repository.GetDespesaById(id);
        if (despesa == null)
        {
            throw new Exception($"Despesa com id '{id}' não foi encontrada.");
        }
        return ToDespesaResponse(despesa);
    }

    public async Task<List<DespesaResponse>> GetFilteredDespesas(
        Guid? funcionarioId,
        CategoriaDespesa? categoria,
        Moeda? moeda,
        StatusDespesa? status,
        DateTime? dataInicio,
        DateTime? dataFim
    )
    {
        List<Despesa> despesas = await _repository.GetFilteredDespesas(
            funcionarioId,
            categoria,
            moeda,
            status,
            dataInicio,
            dataFim
        );
        return despesas.Select(ToDespesaResponse).ToList();
    }

    public async Task<DespesaResponse> UpdateDespesa(Guid id, StatusDespesa newStatus)
    {
        Despesa? despesa = await _repository.GetDespesaById(id);
        if (despesa == null)
        {
            throw new Exception($"Despesa com id '{id}' não foi encontrada.");
        }
        despesa.UpdateStatus(newStatus);
        await _repository.UpdateDespesa(despesa);
        return ToDespesaResponse(despesa);
    }

    public async Task<Boolean> DeleteDespesa(Guid id)
    {
        Despesa? despesa = await _repository.GetDespesaById(id);
        if (despesa == null)
        {
            throw new Exception($"Despesa com id '{id}' não foi encontrada.");
        }
        return await _repository.DeleteDespesa(despesa);
    }

    public DespesaResponse ToDespesaResponse(Despesa despesa)
    {
        return new DespesaResponse
        {
            Id = despesa.Id,
            FuncionarioId = despesa.FuncionarioId,
            Categoria = despesa.Categoria,
            Valor = despesa.Valor,
            Moeda = despesa.Moeda,
            Descricao = despesa.Descricao,
            Data = despesa.Data,
            Status = despesa.Status
        };
    }

    public Despesa ToDespesa(DespesaRequest request)
    {
        return new Despesa(
            request.FuncionarioId,
            request.Categoria,
            request.Valor,
            request.Moeda,
            request.Descricao
        );
    }
}
