using System.ComponentModel.DataAnnotations;

namespace UBS.Expense.Manager.Application.DTOs.Funcionario;

public class FuncionarioRequest
{
    [Required(ErrorMessage = "Funcionario's 'Nome' is required.")]
    [MinLength(3, ErrorMessage = "'Nome' content must be 3 chars or greater.")]
    [MaxLength(50, ErrorMessage =  "'Nome' content must be 50 chars or less.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Funcionario's 'Email' is required.")]
    [EmailAddress(ErrorMessage = "'Email' is invalid.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Funcionario's 'Cargo' is required.")]
    [MinLength(3, ErrorMessage = "'Cargo' content must be 3 chars or greater.")]
    [MaxLength(50, ErrorMessage =  "'Cargo' content must be 50 chars or less.")]
    public string Cargo { get; set; }
    
    [Required(ErrorMessage = "Funcionario's 'DepartamentoId' is required.")]
    public Guid DepartamentoId { get; set; }
    
    [Required(ErrorMessage = "Funcionario's 'GestorId' is required.")]
    public Guid GestorId { get; set; }
}
