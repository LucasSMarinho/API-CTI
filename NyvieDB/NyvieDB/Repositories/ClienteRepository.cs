using NyvieDB.BdContext;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly NyvieContext _context;

        public ClienteRepository(NyvieContext context)
        {
            _context = context;
        }

        public string AtualizarIdUrl(Guid idCliente, Cliente cliente)
        {
            try
            {
                var clienteAtualizado = _context.Clientes.Find(idCliente);

                if (clienteAtualizado != null)
                {
                    clienteAtualizado.Nome = cliente.Nome == "string" || cliente.Nome == "" ? clienteAtualizado.Nome : cliente.Nome;
                    _context.SaveChanges();
                    return "Cliente atualizado com sucesso. ";
                }
                else
                {
                    return "Cliente não encontrado. ";
                }

            }
            catch (Exception error)
            {
                return ("Erro ao atualizar cliente " + error.Message);
            }
        }

        public Cliente BuscarPorId(Guid idCliente)
        {
            try
            {
                var clienteBuscado = _context.Clientes.Find(idCliente)!;
                return clienteBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Cadastrar(Cliente novoCliente)
        {
            try
            {
                var clienteCadastrado = new Cliente
                {
                    Nome = novoCliente.Nome,
                    Telefone = novoCliente.Telefone
                };

                _context.Clientes.Add(clienteCadastrado);
                _context.SaveChanges();
                return "Cliente cadastrado com sucesso. ";
            }
            catch (Exception error)
            {
                return ("Erro ao cadastrar cliente " + error.Message);
            }
        }

        public string Deletar(Guid idCliente)
        {
            try
            {
                var clienteDeletado = _context.Clientes.Find(idCliente);
                if (clienteDeletado != null)
                {
                    _context.Clientes.Remove(clienteDeletado);
                    _context.SaveChanges();
                    return "Cliente deletado com sucesso.";
                }
                else
                {
                    return "Cliente não encontrado.";
                }
            }
            catch (Exception error)
            {
                return ("Erro ao deletar cliente " + error.Message);
            }
        }

        public List<Cliente> Listar()
        {
            return _context.Clientes.OrderBy(c => c.Nome).OrderBy(c => c.Telefone).ToList();
        }
    }
}
