using System.ComponentModel.DataAnnotations;

namespace NyvieDB.DTO
{
    public class PrioridadeDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string? Nome { get; set; }
    }
}
