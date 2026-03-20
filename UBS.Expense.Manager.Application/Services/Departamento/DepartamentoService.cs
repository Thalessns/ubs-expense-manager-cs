namespace UBS.Expense.Manager.Application.Services.Departamento;

using UBS.Expense.Manager.Application.DTOs.Departamento;
using UBS.Expense.Manager.Domain.Entities;
using UBS.Expense.Manager.Infra.Repositories.Departamento;

public class DepartamentoService : IDepartamentoService
{
    private readonly IDepartamentoRepository _repository;

    public DepartamentoService(IDepartamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<DepartamentoResponse> CreateDepartamento(DepartamentoRequest request)
    {
        Departamento departamento = ToDepartamento(request);
        await _repository.CreateDepartamento(departamento);
        return ToDepartamentoResponse(departamento);
    }

    public async Task<DepartamentoResponse> GetDepartamentoById(Guid id)
    {
        Departamento? departamento = await _repository.GetDepartamentoById(id);
        if (departamento == null)
        {
            throw new Exception($"Departamento with id '{id}' was  not found.");
        }
        return ToDepartamentoResponse(departamento);
    }

    public async Task<List<DepartamentoResponse>> GetAllDepartamentos()
    {
        var departamentos = await _repository.GetAllDepartamentos();
        return departamentos.Select(ToDepartamentoResponse).ToList();
    }

    public async Task<bool> DeleteDepartamento(Guid id)
    {
        var departamento = await _repository.GetDepartamentoById(id);
        if (departamento == null)
        {
            throw new Exception($"Departamento with id '{id}' not found.");
        }
        return await _repository.DeleteDepartamento(departamento);
    }

    public Departamento ToDepartamento(DepartamentoRequest request)
    {
        return new Departamento(
            request.Nome,
            request.OrcamentoMensal
        );
    }

    public DepartamentoResponse ToDepartamentoResponse(Departamento departamento)
    {
        return new DepartamentoResponse{
            Id = departamento.Id,
            Nome = departamento.Nome,
            OrcamentoMensal = departamento.OrcamentoMensal
        };
    }
}
