using System.ComponentModel.DataAnnotations;

namespace NyvieDB.DTO
{
    public class ClienteDTO
    {
        [Required(ErrorMessage = "O campo Nome no Post é obrigatório.")]

        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Telefone no Post é obrigatório.")]
        public string? Telefone { get; set; }
    }
}
