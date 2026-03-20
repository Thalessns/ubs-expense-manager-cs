using Microsoft.AspNetCore.Mvc;
using UBS.Expense.Manager.Application.DTOs.Despesa;
using UBS.Expense.Manager.Application.Services.Despesa;
using UBS.Expense.Manager.Domain.Enums;

namespace UBS.Expense.Manager.API.Controllers;

[ApiController]
[Route("api/despesa")]
public class DespesaController(IDespesaService _service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<DespesaResponse>> CreateDespesa([FromBody] DespesaRequest request)
    {
        DespesaResponse response = await _service.CreateDespesa(request);
        return StatusCode(201, response);
    }

    [HttpGet("id:guid")]
    public async Task<ActionResult<DespesaResponse>> GetDespesa(Guid id)
    {
        DespesaResponse response = await _service.GetDespesaById(id);
        return Ok(response);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<List<DespesaResponse>>> GetFilteredDespesas(
        [FromQuery] 
        Guid? funcionarioId,
        CategoriaDespesa? categoria,
        Moeda? moeda,
        StatusDespesa? status,
        DateTime? dataInicio,
        DateTime? dataFim
    )
    {
        List<DespesaResponse> responses = await _service.GetFilteredDespesas(
            funcionarioId,
            categoria,
            moeda,
            status,
            dataInicio,
            dataFim
        );
        return Ok(responses);
    }

    [HttpDelete("id:guid")]
    public async Task<ActionResult> DeleteDespesa(Guid id)
    {
        await _service.DeleteDespesa(id);
        return NotFound();
    }
}