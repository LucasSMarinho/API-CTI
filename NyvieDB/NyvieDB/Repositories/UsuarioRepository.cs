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
                var usuarioUpt = _context.Usuarios.Find(idUsuario);

                if (usuarioUpt != null)
                {
                    usuarioAtualizado.Nome = usuarioUpt.Nome == "string" || usuarioUpt.Nome == "" ? usuarioAtualizado.Nome : usuarioUpt.Nome;
                    usuarioAtualizado.Senha = usuarioUpt.Senha == "string" || usuarioUpt.Senha == "" ? usuarioAtualizado.Senha : usuarioUpt.Senha;
                    usuarioAtualizado.Email = usuarioUpt.Email == "string" || usuarioUpt.Email == "" ? usuarioAtualizado.Email : usuarioUpt.Email;
                    usuarioAtualizado.Telefone = usuarioUpt.Telefone == "string" || usuarioUpt.Telefone == "" ? usuarioAtualizado.Telefone : usuarioUpt.Telefone;
                    usuarioAtualizado.Imagem = usuarioUpt.Imagem == "string" || usuarioUpt.Imagem == "" ? usuarioAtualizado.Imagem : usuarioUpt.Imagem;
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
                var usuarioBuscado = _context.Usuarios.Find(idUsuario)!;
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
                var usuarioCadastrado = new Usuario
                {
                    Nome = novoUsuario.Nome,
                    Email = novoUsuario.Email,
                    Telefone = novoUsuario.Telefone,
                    Imagem = novoUsuario.Imagem
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
                var usuarioDeletado = _context.Usuarios.Find(idUsuario);
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
            return _context.Usuarios.OrderBy(u => u.Nome).OrderBy(u => u.Telefone).OrderBy(u => u.Email).ToList();
        }
    }
}
