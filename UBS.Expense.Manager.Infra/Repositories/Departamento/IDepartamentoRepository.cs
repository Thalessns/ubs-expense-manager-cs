namespace UBS.Expense.Manager.Infra.Repositories.Departamento;

using UBS.Expense.Manager.Domain.Entities;

public interface IDepartamentoRepository
{
    Task CreateDepartamento(Departamento departamento);
    Task<Departamento?> GetDepartamentoById(Guid id);
    Task<List<Departamento>> GetAllDepartamentos();
    Task<Boolean> DeleteDepartamento(Departamento departamento);
}
