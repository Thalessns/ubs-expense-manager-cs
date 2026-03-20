using System.ComponentModel.DataAnnotations;

namespace UBS.Expense.Manager.Application.DTOs.Departamento;

public class DepartamentoRequest
{
    [Required(ErrorMessage = "Departamento's 'nome' is required.")]
    [MinLength(3, ErrorMessage = "'Nome' content must be 3 chars or greater.")]
    [MaxLength(50, ErrorMessage =  "'Nome' content must be 50 chars or less.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Departamento's 'OrcamentoMensal' is required.")]
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "'OrcamentoMensal' must be greater than 0.01.")]
    public decimal OrcamentoMensal { get; set; }
}
