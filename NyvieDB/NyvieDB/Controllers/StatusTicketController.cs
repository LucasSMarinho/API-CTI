using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyvieDB.BdContext;
using NyvieDB.DTO;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusTicketController : ControllerBase
{
    private readonly IStatusTicketRepository _statusTicketRepository;

    public StatusTicketController(IStatusTicketRepository statusTicketRepository)
    {
        _statusTicketRepository = statusTicketRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_statusTicketRepository.Listar());
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            var statusTicket = _statusTicketRepository.BuscarPorId(id);
            if (statusTicket == null)
            {
                return NotFound("Status do ticket não encontrado.");
            }
            return Ok(statusTicket);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]

    public IActionResult Cadastrar(StatusTicketDTO novoStatusTicket)
    {
        try
        {
            var statusTicket = new StatusTicket
            {
                Nome = novoStatusTicket.Nome!
            };
            _statusTicketRepository.Cadastrar(statusTicket);
            return StatusCode(201, statusTicket);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, StatusTicketDTOUpt statusTicketAtualizado)
    {
        try
        {
            var statusTicket = new StatusTicket
            {
                Nome = statusTicketAtualizado.Nome!
            };

            _statusTicketRepository.AtualizarIdUrl(id, statusTicket);
            return Ok(_statusTicketRepository.BuscarPorId(id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]

    public IActionResult Deletar(Guid id)
    {
        try
        {
            _statusTicketRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
