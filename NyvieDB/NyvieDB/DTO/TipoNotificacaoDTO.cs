using System.ComponentModel.DataAnnotations;

namespace NyvieDB.DTO
{
    public class TipoNotificacaoDTO
    {
        [Required(ErrorMessage = "O campo Nome no Post é obrigatório.")]

        public string? Nome { get; set; }
    }
}
