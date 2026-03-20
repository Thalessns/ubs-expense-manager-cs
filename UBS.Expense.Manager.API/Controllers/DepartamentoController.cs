namespace UBS.Expense.Manager.API.Controllers;

using UBS.Expense.Manager.Application.DTOs.Departamento;
using UBS.Expense.Manager.Application.Services.Departamento;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/departamento")]
[Produces("application/json")]
public class DepartamentoController(IDepartamentoService _service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<DepartamentoResponse>> CreateDepartamento([FromBody] DepartamentoRequest request)
    {
        DepartamentoResponse response = await _service.CreateDepartamento(request);
        return StatusCode(201,response);
    }

    [HttpGet("id:guid")]
    public async Task<ActionResult<DepartamentoResponse>> GetDepartamentoById(Guid id)
    {
        DepartamentoResponse response = await _service.GetDepartamentoById(id);
        return Ok(response);
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<DepartamentoResponse>>> GetAllDepartamentos()
    {
        List<DepartamentoResponse> responses = await _service.GetAllDepartamentos();
        return Ok(responses);
    }

    [HttpDelete("id:guid")]
    public async Task<ActionResult> DeleteDepartamento(Guid id)
    {
        await _service.DeleteDepartamento(id);
        return NoContent();
    }
}