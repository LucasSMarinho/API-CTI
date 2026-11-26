using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyvieDB.DTO;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacaoController : ControllerBase
    {
        private readonly INotificacaoRepository _notificacaoRepository;

        public NotificacaoController(INotificacaoRepository notificacaoRepository)
        {
            _notificacaoRepository = notificacaoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_notificacaoRepository.Listar());
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
                return Ok(_notificacaoRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(NotificacaoDTO novaNotificacao)
        {
            try
            {
                var notificacaoCriada = new Notificacao
                {
                    TipoNotificacaoId = novaNotificacao.TipoNotificacaoId,
                    IdUsuario = novaNotificacao.IdUsuario,
                    IdTicket = novaNotificacao.IdTicket,
                    Descricao = novaNotificacao.Descricao!
                };

                var resultado = _notificacaoRepository.Cadastrar(notificacaoCriada);
                return StatusCode(201, resultado);
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
                var resultado = _notificacaoRepository.Deletar(id);
                return Ok(resultado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
