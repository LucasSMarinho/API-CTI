using System.ComponentModel.DataAnnotations;

namespace NyvieDB.DTO;

public class DepartamentoDTO
{
    [Required(ErrorMessage = "O campo Nome no Post é obrigatório.")]
    public string? Nome { get; set; }
}