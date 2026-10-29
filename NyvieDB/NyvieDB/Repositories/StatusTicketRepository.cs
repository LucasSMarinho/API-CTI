using NyvieDB.BdContext;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Repositories
{
    public class StatusTicketRepository : IStatusTicketRepository
    {
        private readonly NyvieContext _context;

        public StatusTicketRepository(NyvieContext context)
        {
            _context = context;
        }

        public string AtualizarIdUrl(Guid idStatusTicket, StatusTicket statusTicketAtualizado)
        {
            try
            {
                var statusTicketBuscado = _context.StatusTickets.Find(idStatusTicket)!;
                if (statusTicketBuscado != null)
                {
                    statusTicketBuscado.Nome = statusTicketAtualizado.Nome == "string" || statusTicketAtualizado.Nome == "" ? statusTicketBuscado.Nome : statusTicketAtualizado.Nome;
                    _context.SaveChanges();
                    return "Status do ticket atualizado com sucesso!";
                }
                else
                {
                    return "Status do ticket não encontrado!";
                }
            }
            catch (Exception error)
            {
                return ("Erro ao atualizar status do ticket! " + error.Message);
            }
        }

        public string Cadastrar(StatusTicket novoStatusTicket)
        {
            try
            {
                _context.StatusTickets.Add(novoStatusTicket);
                _context.SaveChanges();
                return "Status do ticket cadastrado com sucesso!";
            }
            catch (Exception error)
            {
                return ("Erro ao cadastrar status do ticket! " + error.Message);
            }
        }

        public string Deletar(Guid idStatusTicket)
        {
            try
            {
                var statusTicketBuscado = _context.StatusTickets.Find(idStatusTicket)!;
                if (statusTicketBuscado != null)
                {
                    _context.StatusTickets.Remove(statusTicketBuscado);
                    _context.SaveChanges();
                    return "Status do ticket deletado com sucesso!";
                }
                else
                {
                    return "Status do ticket não encontrado!";
                }
            }
            catch (Exception error)
            {
                return ("Erro ao deletar status do ticket! " + error.Message);
            }
        }

        public StatusTicket BuscarPorId(Guid idStatusTicket)
        {
            return _context.StatusTickets.Find(idStatusTicket)!;
        }

        public List<StatusTicket> Listar()
        {
            return _context.StatusTickets.OrderBy(st => st.Nome).ToList();
        }
    }
}
