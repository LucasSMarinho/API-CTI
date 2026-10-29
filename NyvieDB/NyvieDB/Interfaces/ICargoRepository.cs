using NyvieDB.Models;

namespace NyvieDB.Interfaces;

public interface ICargoRepository
{
    public string Cadastrar(Cargo novoCargo);
    public string AtualizarIdUrl(Guid idCargo, Cargo cargoAtualizado);
    public string Deletar(Guid idCargo);
    public Cargo BuscarPorId(Guid idCargo);
    public List<Cargo> Listar();

}
