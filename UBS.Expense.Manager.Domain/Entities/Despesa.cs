using UBS.Expense.Manager.Domain.Enums;

namespace UBS.Expense.Manager.Domain.Entities;

public class Despesa
{
    public Guid Id { get; private set; }
    public Guid FuncionarioId { get; private set; }
    public CategoriaDespesa Categoria { get; private set; }
    public decimal Valor { get; private set; }
    public Moeda Moeda { get; private set; }
    public string Descricao { get; private set; }
    public DateTime Data { get; private set; }
    public StatusDespesa Status { get; private set; }
    
    public Despesa(){ }

    public Despesa(
        Guid funcionarioId, CategoriaDespesa categoria, decimal valor, Moeda moeda, string descricao)
    {
        Id = Guid.NewGuid();
        FuncionarioId = funcionarioId;
        Categoria = categoria;
        Valor = valor;
        Moeda = moeda;
        Descricao = descricao;
        Data = DateTime.UtcNow;
        Status = StatusDespesa.Pendente;
    }

    public void UpdateStatus(StatusDespesa newStatus)
    {
        Status = newStatus;
    }
}
