using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyvieDB.DTO;
using NyvieDB.Interfaces;
using NyvieDB.Models;
using NyvieDB.Repositories;

namespace NyvieDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ITicketRepository _ticketRepository;

    public TicketController(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_ticketRepository.Listar());
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
            return Ok(_ticketRepository.BuscarPorId(id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]

    public async Task<IActionResult> Cadastrar([FromForm] TicketDTO ticket)
    {
        
            if(string.IsNullOrEmpty(ticket.Nome))
                return BadRequest("O nome do ticket é obrigatório.");

            Ticket novoTicket = new Ticket();

            if(ticket.Imagem != null && ticket.Imagem.Length != 0)
            {
                var extensao = Path.GetExtension(ticket.Imagem.FileName); 

                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                //garentindo que a pasta exista
                if(!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using(var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await ticket.Imagem.CopyToAsync(stream);
                }

                novoTicket.Imagem = nomeArquivo;
            }

            novoTicket.Nome = ticket.Nome;
            novoTicket.Descricao = ticket.Descricao;
            novoTicket.Situacao = ticket.Situacao;
            novoTicket.IdCliente = ticket.IdCliente;
            novoTicket.IdUsuario = ticket.IdUsuario;
            novoTicket.IdStatusTicket = ticket.IdStatusTicket;
            novoTicket.IdPrioridade = ticket.IdPrioridade;
            novoTicket.IdDepartamento = ticket.IdDepartamento;
        try
        {
            _ticketRepository.Cadastrar(novoTicket);
            return StatusCode(201, novoTicket);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> AtualizarIdUrl(Guid id, TicketDTOUpt ticketAtualizado)
    {
        try
        {
            var ticketBuscado = _ticketRepository.BuscarPorId(id);
            if (ticketBuscado == null)
                return NotFound("Ticket não encontrado");

            if(!string.IsNullOrEmpty(ticketAtualizado.Nome))
                ticketBuscado.Nome = ticketAtualizado.Nome;

            if (!string.IsNullOrEmpty(ticketAtualizado.Descricao))
                ticketBuscado.Descricao = ticketAtualizado.Descricao;

            if (!string.IsNullOrEmpty(ticketAtualizado.Situacao))
                ticketBuscado.Situacao = ticketAtualizado.Situacao;

            if (ticketAtualizado.Imagem != null && ticketAtualizado.Imagem.Length != 0)
            {
                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                //Deleta arquivo antigo

                if (!String.IsNullOrEmpty(ticketBuscado.Imagem))
                {
                    var caminhoAntigo = Path.Combine(caminhoPasta, ticketBuscado.Imagem);
                    if (System.IO.File.Exists(caminhoAntigo))
                        System.IO.File.Delete(caminhoAntigo);
                }

                var extensao = Path.GetExtension(ticketAtualizado.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";


                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await ticketAtualizado.Imagem.CopyToAsync(stream);
                }

                ticketBuscado.Imagem = nomeArquivo;
            }

            try
            {
                _ticketRepository.AtualizarIdUrl(id, ticketBuscado);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest("Erro ao atualizar ticket" + error.Message);
            }
        
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {

        var ticketBuscado = _ticketRepository.BuscarPorId(id);

        if (ticketBuscado == null)
            return NotFound("Ticket não encontrado");

        var pastaRelativa = "wwwroot/imagens";
        var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

        //Deleta o arquivo

        if (!String.IsNullOrEmpty(ticketBuscado.Imagem))
        {
            var caminho = Path.Combine(caminhoPasta, ticketBuscado.Imagem);

            if (System.IO.File.Exists(caminho))
                System.IO.File.Delete(caminho);
        }

        try
        {
            _ticketRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
