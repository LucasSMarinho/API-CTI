using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyvieDB.DTO;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoNotificacaoController : ControllerBase
{
    private readonly ITipoNotificacaoRepository _tipoNotificacaoRepository;

    public TipoNotificacaoController(ITipoNotificacaoRepository tipoNotificacaoRepository)
    {
        _tipoNotificacaoRepository = tipoNotificacaoRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_tipoNotificacaoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            return Ok(_tipoNotificacaoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPost]
    public IActionResult Post(TipoNotificacaoDTO novoTipoNotificacao)
    {
        try
        {
            var tipoNotificacao = new TipoNotificacao
            {
                Nome = novoTipoNotificacao.Nome!
            };

            _tipoNotificacaoRepository.Cadastrar(tipoNotificacao);

            return StatusCode(201, tipoNotificacao);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, TipoNotificacaoDTOUpt tipoNotificacao)
    {
        try
        {
            var tipoNotificacaoAtualizado = new TipoNotificacao
            {
                Nome = tipoNotificacao.Nome!
            };

            _tipoNotificacaoRepository.AtualizarIdUrl(id, tipoNotificacaoAtualizado);
            return StatusCode(200, tipoNotificacaoAtualizado);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _tipoNotificacaoRepository.Deletar(id);
            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
