using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyvieDB.DTO;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_clienteRepository.Listar());
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
            return Ok(_clienteRepository.BuscarPorId(id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    public IActionResult Cadastrar(ClienteDTO cliente)
    {
        try
        {
            var novoCliente = new Cliente
            {
                Nome = cliente.Nome!,
                Telefone = cliente.Telefone
            };
            _clienteRepository.Cadastrar(novoCliente);
            return StatusCode(201, novoCliente);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, ClienteDTOUpt cliente)
    {
        try
        {
            var clienteAtualizado = new Cliente
            {
                Nome = cliente.Nome!,
                Telefone = cliente.Telefone
            };

            _clienteRepository.AtualizarIdUrl(id, clienteAtualizado);
            return Ok(_clienteRepository.BuscarPorId(id));
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
            _clienteRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
