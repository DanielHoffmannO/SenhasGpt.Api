using SenhasGpt.Domain.IApplication;
using Microsoft.AspNetCore.Mvc;

namespace SenhasGpt.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SenhaController : ControllerBase
{
    private readonly ISenhaGptRepository _senhaService;

    public SenhaController(ISenhaGptRepository senhaService)
    {
        _senhaService = senhaService;
    }

    [HttpPost]
    public async Task<IActionResult> NovaSenha(string PalavraChave)
    {
        var retorno = await _senhaService.CriarNovaSenha(PalavraChave);
        return Ok(retorno);
    }
}