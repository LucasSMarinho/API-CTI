using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyvieDB.DTO;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoController : ControllerBase
{
    private readonly ICargoRepository _cargoRepository;

    public CargoController(ICargoRepository cargoRepository)
    {
        _cargoRepository = cargoRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_cargoRepository.Listar());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetbyId(Guid id)
    {
        try
        {
            return Ok(_cargoRepository.BuscarPorId(id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    public IActionResult Cadastrar(CargoDTO cargo)
    {
        try
        {
            var novoCargo = new Cargo
            {
                Nome = cargo.Nome!
            };
            _cargoRepository.Cadastrar(novoCargo);
            return StatusCode(201, novoCargo);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, CargoDTOUpt cargo)
    {
        try
        {
            var cargoExistente = new Cargo
            {
                Nome = cargo.Nome!
            };

            _cargoRepository.AtualizarIdUrl(id, cargoExistente);
            return Ok(cargoExistente);
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
            _cargoRepository.Deletar(id);

            return NoContent();
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}