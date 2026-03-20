using Microsoft.AspNetCore.Mvc;
using UBS.Expense.Manager.Application.DTOs.Funcionario;
using UBS.Expense.Manager.Application.Services.Funcionario;

namespace UBS.Expense.Manager.API.Controllers;

[ApiController]
[Route("api/funcionario")]
public class FuncionarioController(IFuncionarioService _service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<FuncionarioResponse>> CreateFuncionario([FromBody] FuncionarioRequest request)
    {
        FuncionarioResponse response = await _service.CreateFuncionario(request);
        return StatusCode(201, response);
    }

    [HttpGet("id:guid")]
    public async Task<ActionResult<FuncionarioResponse>> GetFuncionario(Guid id)
    {
        FuncionarioResponse response = await _service.GetFuncionarioById(id);
        return Ok(response);
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<FuncionarioResponse>>> ListFuncionarios()
    {
        List<FuncionarioResponse> responses = await _service.GetAllFuncionarios();
        return Ok(responses);
    }

    [HttpDelete("id:guid")]
    public async Task<ActionResult> DeleteFuncionario(Guid id)
    {
        await _service.DeleteFuncionario(id);
        return Ok();
    }
}