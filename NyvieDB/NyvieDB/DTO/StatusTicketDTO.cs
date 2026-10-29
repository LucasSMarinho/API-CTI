using System.ComponentModel.DataAnnotations;

namespace NyvieDB.DTO
{
    public class StatusTicketDTO
    {
        [Required(ErrorMessage = "O campo Nome no Post é obrigatório.")]
        public string? Nome { get; set; }

       
    }
}
