namespace UBS.Expense.Manager.Application.Services.Funcionario;

using UBS.Expense.Manager.Application.DTOs.Funcionario;
using UBS.Expense.Manager.Domain.Entities;
using UBS.Expense.Manager.Infra.Repositories.Funcionario;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _repository;

    public FuncionarioService(IFuncionarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<FuncionarioResponse> CreateFuncionario(FuncionarioRequest request)
    {
        Funcionario funcionario = ToFuncionario(request);
        await _repository.CreateFuncionario(funcionario);
        return ToFuncionarioResponse(funcionario);
    }

    public async Task<FuncionarioResponse> GetFuncionarioById(Guid id)
    {
        Funcionario funcionario = await _repository.GetFuncionarioById(id);
        return ToFuncionarioResponse(funcionario);
    }

    public async Task<List<FuncionarioResponse>> GetAllFuncionarios()
    {
        List<Funcionario> funcionarios = await _repository.GetAllFuncionarios();
        return funcionarios.Select(ToFuncionarioResponse).ToList();
    }

    public async Task<bool> DeleteFuncionario(Guid id)
    {
        Funcionario funcionario = await _repository.GetFuncionarioById(id);
        return await _repository.DeleteFuncionario(funcionario);
    }

    public FuncionarioResponse ToFuncionarioResponse(Funcionario funcionario)
    {
        return new FuncionarioResponse
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Email = funcionario.Email,
            Cargo = funcionario.Cargo,
            DepartamentoId = funcionario.DepartamentoId,
            GestorId = funcionario.GestorId
        };
    }

    public Funcionario ToFuncionario(FuncionarioRequest request)
    {
        return new Funcionario(
            request.Nome,
            request.Email,
            request.Cargo,
            request.DepartamentoId,
            request.GestorId
        );
    }
}
