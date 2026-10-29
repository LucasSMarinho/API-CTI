using NyvieDB.Models;

namespace NyvieDB.Interfaces
{
    public interface IPrioridadeRepository
    {
        public string Cadastrar(Prioridade novaPrioridade);
        public string AtualizarIdUrl(Guid idPrioridade, Prioridade prioridadeAtualizada);
        public string Deletar(Guid idPrioridade);
        public Prioridade BuscarPorId(Guid idPrioridade);
        public List<Prioridade> Listar();
    }
}