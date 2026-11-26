using NyvieDB.DTO;
using NyvieDB.Models;

namespace NyvieDB.Interfaces
{
    public interface INotificacaoRepository
    {
        public string Cadastrar(Notificacao novaNotificacao);

        public string Deletar(Guid idNotificacao);

        public Notificacao BuscarPorId(Guid idNotificacao);

        public List<Notificacao> Listar();
    }
}
