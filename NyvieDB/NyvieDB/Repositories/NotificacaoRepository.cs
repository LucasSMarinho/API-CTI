using Microsoft.EntityFrameworkCore;
using NyvieDB.BdContext;
using NyvieDB.DTO;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Repositories
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly NyvieContext _context;

        public NotificacaoRepository(NyvieContext context)
        {
            _context = context;
        }

        public Notificacao BuscarPorId(Guid idNotificacao)
        {
            try
            {
                return _context.Notificacaos.Find(idNotificacao)!;
            }
            catch
            {
                throw;
            }
        }

        public string Cadastrar(Notificacao novaNotificacao)
        {
            try
            {
                _context.Notificacaos.Add(novaNotificacao);
                _context.SaveChanges();
                return "Notificação cadastrada com sucesso!";
            }
            catch
            {
                throw;
            }
        }

        public string Deletar(Guid idNotificacao)
        {
            try
            {
                var notificacaoBuscada = _context.Notificacaos.Find(idNotificacao);

                if(notificacaoBuscada != null)
                {
                    _context.Notificacaos.Remove(notificacaoBuscada);
                    _context.SaveChanges();
                    return "Notificação deletada com sucesso!";
                }
                else
                {
                    return "Notificação não encontrada!";
                }
            }
            catch
            {

                throw;
            }
        }

        public List<Notificacao> Listar()
        {
            try
            {
                return _context.Notificacaos.Include(n => n.TipoNotificacao).OrderBy(n => n.IdTicket).OrderBy(n => n.IdUsuario).OrderBy(n => n.DataHora).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
