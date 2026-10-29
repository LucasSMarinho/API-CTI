using NyvieDB.Models;

namespace NyvieDB.Interfaces;

public interface ITipoNotificacaoRepository
{
    public string Cadastrar(TipoNotificacao novoTipoNotificacao);
    public string AtualizarIdUrl(Guid idTipoNotificacao, TipoNotificacao tipoNotificacaoAtualizado);
    public string Deletar(Guid idTipoNotificacao);
    public TipoNotificacao BuscarPorId(Guid idTipoNotificacao);
    public List<TipoNotificacao> Listar();
}
