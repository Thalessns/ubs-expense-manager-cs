using System.ComponentModel.DataAnnotations;
using UBS.Expense.Manager.Domain.Enums;

namespace UBS.Expense.Manager.Application.DTOs.Despesa;

public class DespesaRequest
{
    [Required(ErrorMessage = "'FuncionarioId' is required.'")]
    public Guid FuncionarioId { get; set; }
    
    [Required(ErrorMessage = "'Categoria' is required.'")]
    public CategoriaDespesa Categoria { get; set; }
    
    [Required(ErrorMessage = "'Valor' is required.'")]
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "'Valor' must be greater than '0.01'")]
    public decimal Valor { get; set; }
    
    [Required(ErrorMessage = "'Moeda' is required.'")]
    public Moeda Moeda { get; set; }
    
    [Required(ErrorMessage = "'Descricao' is required.'")]
    [MinLength(3, ErrorMessage = "'Descricao' must be at least 3 characters long.")]
    [MaxLength(100, ErrorMessage = "'Descricao' must be less than 100 characters long.")]
    public string Descricao { get; set; }
}
