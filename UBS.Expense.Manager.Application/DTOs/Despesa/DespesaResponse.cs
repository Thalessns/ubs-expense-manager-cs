using UBS.Expense.Manager.Domain.Enums;

namespace UBS.Expense.Manager.Application.DTOs.Despesa;

public class DespesaResponse
{
    public Guid Id { get; set; }
    public Guid FuncionarioId { get; set; }
    public CategoriaDespesa Categoria { get; set; }
    public decimal Valor { get; set; }
    public Moeda Moeda { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public StatusDespesa Status { get; set; }
}
