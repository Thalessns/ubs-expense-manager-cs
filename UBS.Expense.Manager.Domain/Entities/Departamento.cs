namespace UBS.Expense.Manager.Domain.Entities;

public class Departamento 
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public decimal OrcamentoMensal { get; private set; }
    
    public Departamento() { }

    public Departamento(string nome, decimal orcamentoMensal)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        OrcamentoMensal = orcamentoMensal;
    }
}
