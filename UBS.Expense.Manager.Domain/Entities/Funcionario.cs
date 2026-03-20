namespace UBS.Expense.Manager.Domain.Entities;

public class Funcionario
{
    
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Cargo  { get; private set; }
    public Guid DepartamentoId { get; private set; }
    public Guid GestorId { get; private set; }
    
    public Funcionario(){ }

    public Funcionario(string nome, string email, string cargo, Guid departamentoId, Guid gestorId)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Cargo = cargo;
        DepartamentoId = departamentoId;
        GestorId = gestorId;
    }
    
}