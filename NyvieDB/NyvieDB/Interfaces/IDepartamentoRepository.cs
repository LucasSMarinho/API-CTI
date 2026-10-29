using NyvieDB.Models;

namespace NyvieDB.Interfaces;

public interface IDepartamentoRepository
{
    public string Cadastrar(Departamento novoDepartamento);
    public string AtualizarIdUrl(Guid idDepartamento, Departamento departamentoAtualizado);
    public string Deletar(Guid idDepartamento);
    Departamento BuscarPorId(Guid idDepartemento);
    List<Departamento> Listar();

}
