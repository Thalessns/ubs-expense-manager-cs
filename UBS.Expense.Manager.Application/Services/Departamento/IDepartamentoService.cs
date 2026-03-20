namespace UBS.Expense.Manager.Application.Services.Departamento;

using UBS.Expense.Manager.Application.DTOs.Departamento;
using UBS.Expense.Manager.Domain.Entities;

public interface IDepartamentoService
{
    Task<DepartamentoResponse> CreateDepartamento(DepartamentoRequest request);
    Task<DepartamentoResponse> GetDepartamentoById(Guid id);
    Task<List<DepartamentoResponse>> GetAllDepartamentos();
    Task<bool> DeleteDepartamento(Guid id);
    Departamento ToDepartamento(DepartamentoRequest request);
    DepartamentoResponse ToDepartamentoResponse(Departamento departamento);
}
