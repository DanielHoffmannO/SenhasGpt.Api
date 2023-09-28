﻿using SenhasGpt.Domain.IApplication;
using Microsoft.AspNetCore.Mvc;
using SenhasGpt.Domain.Model;

namespace SenhasGpt.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfiguracaoController : ControllerBase
{
    private readonly IConfiguracaoService _configuracaoService;

    public ConfiguracaoController(IConfiguracaoService configuracaoService)
    {
        _configuracaoService = configuracaoService;
    }

    /// <summary>
    /// Obtém uma lista de filmes.
    /// </summary>
    [HttpGet]
    public IActionResult ObterConfiguracao()
    {
        return Ok(_configuracaoService.ObterConfiguracao());
    }

    /// <summary>
    /// Adiciona um novo filme.
    /// </summary>
    /// <param name="filme">Informações da Configuracao a ser adicionado.</param>
    [HttpPost]
    public IActionResult AdicionarConfiguracao(SenhaGptConfiguracaoModel model)
    {
        return Ok(_configuracaoService.AdicionarConfiguracao(model));
    }

    /// <summary>
    /// Atualiza os detalhes de um filme existente.
    /// </summary>
    /// <param name="id">ID do filme a ser atualizado.</param>
    /// <param name="config">Novas informações do filme.</param>
    [HttpPut("{id}")]
    public IActionResult AtualizarConfiguracao(short id, SenhaGptConfiguracaoModel model)
    {
        _configuracaoService.AtualizarConfiguracao(id, model);
        return Ok();
    }
}