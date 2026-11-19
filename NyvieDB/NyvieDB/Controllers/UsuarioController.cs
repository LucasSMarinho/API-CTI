using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyvieDB.DTO;
using NyvieDB.Interfaces;
using NyvieDB.Models;
using NyvieDB.Repositories;
using System.Net.Sockets;

namespace NyvieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
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
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm] UsuarioDTO usuario)
        {

            if (string.IsNullOrEmpty(usuario.Nome))
                return BadRequest("O nome do ticket é obrigatório.");

            var novoUsuario = new Usuario();

            if (usuario.Imagem != null && usuario.Imagem.Length != 0)
            {
                var extensao = Path.GetExtension(usuario.Imagem.FileName);

                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await usuario.Imagem.CopyToAsync(stream);
                }

                novoUsuario.Imagem = nomeArquivo;
            }


            novoUsuario.Nome = usuario.Nome!;
            novoUsuario.Email = usuario.Email!;
            novoUsuario.Senha = usuario.Senha!;
            novoUsuario.Telefone = usuario.Telefone;
            novoUsuario.IdDepartamento = usuario.IdDepartamento;
            novoUsuario.IdCargo = usuario.IdCargo;



            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201, novoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UsuarioDTOUpt usuario)
        {
            try
            {
                var usuarioAtualizado = new Usuario
                {
                    Nome = usuario.Nome!,
                    Email = usuario.Email!,
                    Senha = usuario.Senha!,
                    Telefone = usuario.Telefone,
                    IdDepartamento = usuario.IdDepartamento,
                    IdCargo = usuario.IdCargo
                };
                _usuarioRepository.AtualizarIdUrl(id, usuarioAtualizado);
                return Ok(usuarioAtualizado);
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
                var resultado = _usuarioRepository.Deletar(id);
                return Ok(resultado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
