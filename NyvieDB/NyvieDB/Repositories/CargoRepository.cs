using NyvieDB.BdContext;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Repositories;

public class CargoRepository : ICargoRepository
{
    private readonly NyvieContext _context;

    public CargoRepository(NyvieContext context)
    {
        _context = context;
    }

    public string AtualizarIdUrl(Guid idCargo, Cargo cargoAtualizado)
    {
        try
        {
            Cargo cargoBuscado = _context.Cargos.Find(idCargo)!;

            if (cargoBuscado != null)
            {
                _context.Cargos.Update(cargoAtualizado);
                cargoBuscado.Nome = cargoAtualizado.Nome == "string" || cargoAtualizado.Nome == "" ? cargoBuscado.Nome : cargoAtualizado.Nome;
                _context.SaveChanges();
                return "Cargo atualizado com sucesso!";
            }
            else
            {
                return "Cargo não encontrado!";
            }
            
        }
        catch (Exception error)
        {
            return ("Erro ao atualizar cargo! " + error.Message);
        }
    }

    public Cargo BuscarPorId(Guid idCargo)
    {
        try
        {
            return _context.Cargos.Find(idCargo)!;
        }
        catch
        {
            throw;
        }
    }

    public string Cadastrar(Cargo novoCargo)
    {
        try
        {
            _context.Cargos.Add(novoCargo);
            _context.SaveChanges();

            return "Cargo cadastrado com sucesso!";
        }
        catch (Exception error)
        {
            return ("Erro ao cadastrar cargo! " + error.Message);
        }
    }

    public string Deletar(Guid idCargo)
    {
        try
        {
            Cargo cargoBuscado = _context.Cargos.Find(idCargo)!;

            if (cargoBuscado != null)
            {
                _context.Cargos.Remove(cargoBuscado);
                _context.SaveChanges();
                return "Cargo deletado com sucesso!";
            }
            else
            {
                return "Cargo não encontrado!";
            }

        }
        catch (Exception error)
        {
            return ("Erro ao deletar cargo! " + error.Message);
        }
    }

    public List<Cargo> Listar()
    {
        return _context.Cargos.OrderBy(c => c.Nome).ToList();
    }
}
