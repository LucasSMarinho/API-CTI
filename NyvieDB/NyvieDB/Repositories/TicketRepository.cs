using NyvieDB.BdContext;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly NyvieContext _context;

        public TicketRepository(NyvieContext context)
        {
            _context = context;
        }

        public string AtualizarIdUrl(Guid idTicket, Ticket ticketAtualizado)
        {
            try
            {
                var ticketBuscado = _context.Tickets.Find(idTicket);
                if (ticketBuscado != null)
                {
                    ticketBuscado.IdUsuario = ticketAtualizado.IdUsuario;
                    ticketBuscado.IdDepartamento = ticketAtualizado.IdDepartamento;
                    ticketBuscado.IdCliente = ticketAtualizado.IdCliente;
                    ticketBuscado.IdPrioridade = ticketAtualizado.IdPrioridade;
                    ticketBuscado.IdStatusTicket = ticketAtualizado.IdStatusTicket;
                    ticketBuscado.Nome = ticketAtualizado.Nome;
                    ticketBuscado.Descricao = ticketAtualizado.Descricao;
                    ticketBuscado.Situacao = ticketAtualizado.Situacao;
                    _context.SaveChanges();
                    return "Ticket atualizado com sucesso";
                }
                else
                {
                    return "Ticket não encontrado";
                }


            }
            catch (Exception error)
            {
                return ("Erro ao atualizar ticket" + error.Message);
            }
        }

        public Ticket BuscarPorId(Guid idTicket)
        {
            try
            {
                return _context.Tickets.Find(idTicket)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Cadastrar(Ticket novoTicket)
        {
            try
            {
                var novoTicketCadastrado = new Ticket
                {
                    IdTicket = novoTicket.IdTicket,
                    Nome = novoTicket.Nome,
                    Descricao = novoTicket.Descricao,   
                    Situacao = novoTicket.Situacao,
                    Imagem = novoTicket.Imagem,
                    IdCliente = novoTicket.IdCliente,
                    IdUsuario = novoTicket.IdUsuario,
                    IdStatusTicket = novoTicket.IdStatusTicket,
                    IdDepartamento = novoTicket.IdDepartamento,
                    IdPrioridade = novoTicket.IdPrioridade
                };
                _context.Tickets.Add(novoTicketCadastrado);
                _context.SaveChanges();
                return "Ticket cadastrado com sucesso";
            }
            catch (Exception error)
            {
                return ("Erro ao cadastrar ticket" + error.Message);
            }
        }

        public string Deletar(Guid idTicket)
        {
            try
            {
                var ticketParaDeletar = _context.Tickets.Find(idTicket);
                if (ticketParaDeletar != null)
                {
                    _context.Tickets.Remove(ticketParaDeletar);
                    _context.SaveChanges();
                    return "Ticket deletado com sucesso";
                }
                else
                {
                    return "Ticket não encontrado";
                }
            }
            catch (Exception error)
            {
                return ("Erro ao deletar ticket " + error.Message);
            }
        }

        public List<Ticket> Listar()
        {
            return _context.Tickets.OrderBy(t => t.DataHora).OrderBy(t => t.Nome).ToList();
        }
    }
}
