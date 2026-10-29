using NyvieDB.Models;

namespace NyvieDB.Interfaces
{
    public interface ITicketRepository
    {
        public string Cadastrar(Ticket novoTicket);

        public string AtualizarIdUrl(Guid idTicket, Ticket ticketAtualizado);

        public string Deletar(Guid idTicket);

        public Ticket BuscarPorId(Guid idTicket);

        public List<Ticket> Listar();
    }
}
