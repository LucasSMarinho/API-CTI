using NyvieDB.BdContext;
using NyvieDB.Interfaces;
using NyvieDB.Models;

namespace NyvieDB.Repositories;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly NyvieContext _context;

    public DepartamentoRepository(NyvieContext context)
    {
        _context = context;
    }


    public string AtualizarIdUrl(Guid idDepartamento, Departamento departamentoAtualizado)
    {
        try
        {
            Departamento departamentoBuscado = _context.Departamentos.Find(idDepartamento)!;

            if (departamentoBuscado != null)
            {
                departamentoBuscado.Nome = departamentoAtualizado.Nome == "string" || departamentoAtualizado.Nome == "" ? departamentoBuscado.Nome : departamentoAtualizado.Nome;
                _context.Departamentos.Update(departamentoBuscado);
                _context.SaveChanges();
                return "Departamento atualizado com sucesso! ";
            }
            else
            {
                return "Departamento não encontrado! ";
            }
        }
        catch (Exception error)
        {
            return ("Erro ao atualizar departamento! " + error.Message);
        }
    }

    public Departamento BuscarPorId(Guid idDepartemento)
    {
        try
        {
            Departamento departamentoBuscado = _context.Departamentos.Find(idDepartemento)!;
            return departamentoBuscado;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string Cadastrar(Departamento novoDepartamento)
    {
        try
        {
            _context.Departamentos.Add(novoDepartamento);

            _context.SaveChanges();

            return "Departamento cadastrado com sucesso!";
        }
        catch (Exception error)
        {
            return ("Erro ao cadastrar departamento! " + error.Message);
        }
    }

    public string Deletar(Guid idDepartamento)
    {
        try
        {
            Departamento departamentoBuscado = _context.Departamentos.Find(idDepartamento)!;

            if (departamentoBuscado != null)
            {
                _context.Departamentos.Remove(departamentoBuscado);
                _context.SaveChanges();
                return "Departamento deletado com sucesso!";
            }
            else
            {
                return "Departamento não encontrado!";
            }
        }
        catch (Exception error)
        {
            return ("Erro ao deletar departamento! " + error.Message);
        }
    }

    public List<Departamento> Listar()
    {
        try
        {
            return _context.Departamentos.OrderBy(d => d.Nome).ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
