using NyvieDB.Models;
using System.ComponentModel.DataAnnotations;

namespace NyvieDB.Interfaces
{
    public interface IUsuarioRepository
    {
        public string Cadastrar(Usuario novoUsuario);
        public string AtualizarIdUrl(Guid idUsuario, Usuario usuarioAtualizado);
        public string Deletar(Guid idUsuario);
        public Usuario BuscarPorId(Guid idUsuario);
        public Usuario BuscarPorEmailESenha(string email, string senha);
        public List<Usuario> Listar();
    }
}
