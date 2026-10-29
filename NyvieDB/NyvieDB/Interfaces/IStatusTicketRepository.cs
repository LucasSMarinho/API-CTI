using NyvieDB.Models;

namespace NyvieDB.Interfaces;

public interface IStatusTicketRepository
{
    public string Cadastrar(StatusTicket novoStatusTicket);
    public string AtualizarIdUrl(Guid idStatusTicket, StatusTicket statusTicketAtualizado);
    public string Deletar(Guid idStatusTicket);
    public StatusTicket BuscarPorId(Guid idStatusTicket);
    public List<StatusTicket> Listar();

}
