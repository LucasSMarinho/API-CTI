using NyvieDB.Models;

namespace NyvieDB.Interfaces;

public interface IClienteRepository
{
    public string Cadastrar(Cliente novoCliente);
    public string AtualizarIdUrl(Guid idCliente, Cliente clienteAtualizado);
    public string Deletar(Guid idCliente);
    public Cliente BuscarPorId(Guid idCliente);
    public List<Cliente> Listar();
}
