using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyvieDB.DTO;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamentoRepository _departamentoRepository;

    public DepartamentoController(IDepartamentoRepository departamentoRepository)
    {
        _departamentoRepository = departamentoRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_departamentoRepository.Listar());
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
            return Ok(_departamentoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPost]
    public IActionResult Post(DepartamentoDTO departamento)
    {
        try
        {
            var novoDepartamento = new Departamento
            {
                Nome = departamento.Nome!
            };

            _departamentoRepository.Cadastrar(novoDepartamento);
            return StatusCode(201, novoDepartamento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, DepartamentoDTOUpt departamento)
    {
        try
        {
            var novoDepartamento = new Departamento
            {
                Nome = departamento.Nome!
            };

            _departamentoRepository.AtualizarIdUrl(id, novoDepartamento);
            return Ok(novoDepartamento);
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
            _departamentoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
