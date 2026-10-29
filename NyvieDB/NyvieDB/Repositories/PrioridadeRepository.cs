using NyvieDB.BdContext;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Repositories
{
    public class PrioridadeRepository : IPrioridadeRepository
    {
        private readonly NyvieContext _context;

        public PrioridadeRepository(NyvieContext context)
        {
            _context = context;
        }

        public string AtualizarIdUrl(Guid idPrioridade, Prioridade prioridadeAtualizada)
        {
            try
            {
                var prioridadeBuscada = _context.Prioridades.Find(idPrioridade);

                if (prioridadeBuscada != null)
                {
                    prioridadeBuscada.Nome = prioridadeBuscada.Nome == "string" || prioridadeBuscada.Nome == "" ? prioridadeBuscada.Nome : prioridadeAtualizada.Nome;
                    _context.SaveChanges();
                    return "Prioridade atualizada com sucesso!";
                }
                else
                {
                    return "Prioridade não encontrada!";
                }

            }
            catch (Exception error)
            {
                return ("Erro ao atualizar prioridade! " + error.Message);
            }
        }

        public Prioridade BuscarPorId(Guid idPrioridade)
        {
            try
            {
                return _context.Prioridades.Find(idPrioridade)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Cadastrar(Prioridade novaPrioridade)
        {
            try
            {
                _context.Prioridades.Add(novaPrioridade);
                _context.SaveChanges();
                return "Prioridade cadastrada com sucesso!";
            }
            catch (Exception error)
            {
                return ("Erro ao cadastrar prioridade! " + error.Message);
            }
        }

        public string Deletar(Guid idPrioridade)
        {
            try
            {
                var prioridadeBuscada = _context.Prioridades.Find(idPrioridade);

                if (prioridadeBuscada != null)
                {
                    _context.Prioridades.Remove(prioridadeBuscada);
                    _context.SaveChanges();
                    return "Prioridade deletada com sucesso!";
                }
                else
                {
                    return "Prioridade não encontrada!";
                }

            }
            catch (Exception error)
            {
                return ("Erro ao deletar prioridade! " + error.Message);
            }
        }

        public List<Prioridade> Listar()
        {
            return _context.Prioridades.OrderBy(p => p.Nome).ToList();
        }
    }
}
