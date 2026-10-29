using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyvieDB.DTO;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadeController : ControllerBase
    {
        private readonly IPrioridadeRepository _prioridadeRepository;

        public PrioridadeController(IPrioridadeRepository prioridadeRepository)
        {
            _prioridadeRepository = prioridadeRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_prioridadeRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_prioridadeRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(PrioridadeDTO prioridade)
        {
            try
            {
                var novaPrioridade = new Prioridade
                {
                    Nome = prioridade.Nome!
                };

                return StatusCode(201, prioridade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, PrioridadeDTOUpt prioridade)
        {
            try
            {
                var novaPrioridade = new Prioridade
                {
                    Nome = prioridade.Nome!
                };

                _prioridadeRepository.AtualizarIdUrl(id, novaPrioridade);
                return Ok(novaPrioridade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _prioridadeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
