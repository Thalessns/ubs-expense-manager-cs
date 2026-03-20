namespace UBS.Expense.Manager.Application.DTOs.Funcionario;

public class FuncionarioResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Cargo { get; set; }
    public Guid DepartamentoId { get; set; }
    public Guid? GestorId { get; set; }
}
