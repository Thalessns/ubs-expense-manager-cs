namespace UBS.Expense.Manager.Application.Services.Funcionario;

using UBS.Expense.Manager.Application.DTOs.Funcionario;
using UBS.Expense.Manager.Domain.Entities;

public interface IFuncionarioService
{
    Task<FuncionarioResponse> CreateFuncionario(FuncionarioRequest request);
    Task<FuncionarioResponse> GetFuncionarioById(Guid id);
    Task<List<FuncionarioResponse>> GetAllFuncionarios();
    Task<Boolean> DeleteFuncionario(Guid id);
    Funcionario ToFuncionario(FuncionarioRequest request);
    FuncionarioResponse ToFuncionarioResponse(Funcionario funcionario);
}
