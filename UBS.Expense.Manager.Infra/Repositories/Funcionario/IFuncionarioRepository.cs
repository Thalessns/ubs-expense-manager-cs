namespace UBS.Expense.Manager.Infra.Repositories.Funcionario;

using UBS.Expense.Manager.Domain.Entities;

public interface IFuncionarioRepository
{
    Task CreateFuncionario(Funcionario funcionario);
    Task<Funcionario> GetFuncionarioById(Guid id);
    Task<List<Funcionario>> GetAllFuncionarios();
    Task<Boolean> DeleteFuncionario(Funcionario funcionario);
}
