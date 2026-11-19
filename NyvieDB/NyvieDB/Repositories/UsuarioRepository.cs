using Microsoft.EntityFrameworkCore;
using NyvieDB.BdContext;
using NyvieDB.Interfaces;
using NyvieDB.Models;
using NyvieDB.Utils;

namespace NyvieDB.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly NyvieContext _context;

        public UsuarioRepository(NyvieContext context)
        {
            _context = context;
        }

        public string AtualizarIdUrl(Guid idUsuario, Usuario usuarioAtualizado)
        {
            try
            {
                var usuarioUpt = _context.Usuarios.Find(idUsuario.ToString());

                if (usuarioUpt != null)
                {
                    usuarioUpt.Nome = usuarioAtualizado.Nome == "string" || usuarioAtualizado.Nome == "" ? usuarioUpt.Nome : usuarioAtualizado.Nome;
                    usuarioUpt.Senha = usuarioAtualizado.Senha == "string" || usuarioAtualizado.Senha == "" ? usuarioUpt.Senha : usuarioAtualizado.Senha;
                    usuarioUpt.Email = usuarioAtualizado.Email == "string" || usuarioAtualizado.Email == "" ? usuarioUpt.Email : usuarioAtualizado.Email;
                    usuarioUpt.Telefone = usuarioAtualizado.Telefone == "string" || usuarioAtualizado.Telefone == "" ? usuarioUpt.Telefone : usuarioAtualizado.Telefone;
                    usuarioUpt.Imagem = usuarioAtualizado.Imagem == "string" || usuarioAtualizado.Imagem == "" ? usuarioUpt.Imagem : usuarioAtualizado.Imagem;
                    _context.Usuarios.Update(usuarioUpt);
                    _context.SaveChanges();
                    return "Usuário atualizado com sucesso.";
                }
                else
                {
                    return "Usuário não encontrado.";
                }

            }
            catch (Exception error)
            {
                return ("Erro ao atualizar usuário" + error.Message);
            }
        }

        public Usuario BuscarPorId(Guid idUsuario)
        {
            try
            {
                var usuarioBuscado = _context.Usuarios.Find(idUsuario.ToString())!;
                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.compararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Cadastrar(Usuario novoUsuario)
        {

            try
            {
                novoUsuario.IdUsuario = Guid.NewGuid().ToString();
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha)!;

                var usuarioCadastrado = new Usuario
                {
                    IdUsuario = novoUsuario.IdUsuario,
                    Nome = novoUsuario.Nome,
                    Email = novoUsuario.Email,
                    Telefone = novoUsuario.Telefone,
                    Imagem = novoUsuario.Imagem,
                    Senha = novoUsuario.Senha,
                    IdCargo = novoUsuario.IdCargo,
                    IdDepartamento = novoUsuario.IdDepartamento
                };

                _context.Usuarios.Add(usuarioCadastrado);
                _context.SaveChanges();
                return "Usuário cadastrado com sucesso.";
            }
            catch (Exception error)
            {
                return ("Erro ao cadastrar usuário " + error.Message);
            }
        }

        public string Deletar(Guid idUsuario)
        {
            try
            {
                var usuarioDeletado = _context.Usuarios.Find(idUsuario.ToString());
                if (usuarioDeletado != null)
                {
                    _context.Usuarios.Remove(usuarioDeletado);
                    _context.SaveChanges();
                }
                return "Usuário deletado com sucesso.";
            }
            catch (Exception error)
            {
                return ("Erro ao deletar usuário " + error.Message);
            }
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.OrderBy(u => u.Nome).OrderBy(u => u.Telefone).OrderBy(u => u.Email).Include(u => u.IdCargoNavigation).Include(u => u.IdDepartamentoNavigation).ToList();
        }
    }
}
