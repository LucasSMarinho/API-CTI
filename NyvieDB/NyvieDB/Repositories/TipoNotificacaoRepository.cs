using NyvieDB.BdContext;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Repositories;

public class TipoNotificacaoRepository : ITipoNotificacaoRepository
{
    private readonly NyvieContext _context;

    public TipoNotificacaoRepository(NyvieContext context)
    {
        _context = context;
    }

    public string AtualizarIdUrl(Guid idTipoNotificacao, TipoNotificacao tipoNotificacaoAtualizado)
    {
        try
        {
            var tipoNotificacaoBuscado = _context.TipoNotificacaos.Find(idTipoNotificacao)!;
            if (tipoNotificacaoBuscado != null)
            {
                tipoNotificacaoBuscado.Nome = tipoNotificacaoAtualizado.Nome == "string" || tipoNotificacaoAtualizado.Nome == "" ? tipoNotificacaoBuscado.Nome : tipoNotificacaoAtualizado.Nome;
                _context.SaveChanges();
                return "Notificação atualizada com sucesso!";
            }
            else
            {
                return "Notificação não encontrada!";
            }


        }
        catch (Exception error)
        {
            return ("Erro ao atualizar Notificação! " + error.Message);
        }
    }

    public TipoNotificacao BuscarPorId(Guid idTipoNotificacao)
    {
        try
        {
            return _context.TipoNotificacaos.Find(idTipoNotificacao)!;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string Cadastrar(TipoNotificacao novoTipoNotificacao)
    {
        try
        {
            _context.TipoNotificacaos.Add(novoTipoNotificacao);
            _context.SaveChanges();

            return "Tipo de notificação cadastrado com sucesso!";
        }
        catch (Exception error)
        {
            return ("Erro ao cadastrar tipo de notificação! " + error.Message);
        }
    }

    public string Deletar(Guid idTipoNotificacao)
    {
        try
        {
            var tipoNotificacaoBuscado = _context.TipoNotificacaos.Find(idTipoNotificacao)!;
            if (tipoNotificacaoBuscado != null)
            {
                _context.TipoNotificacaos.Remove(tipoNotificacaoBuscado);
                _context.SaveChanges();
                return "Tipo de notificação deletada com sucesso!";
            }
            else
            {
                return "Tipo de notificação não encontrada!";
            }


        }
        catch (Exception error)
        {
            return ("Erro ao deletar tipo de notificação! " + error.Message);
        }
    }

    public List<TipoNotificacao> Listar()
    {
        try
        {
            return _context.TipoNotificacaos.OrderBy(tn => tn.Nome).ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
