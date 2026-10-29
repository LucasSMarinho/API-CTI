using System.ComponentModel.DataAnnotations;

namespace NyvieDB.DTO
{
    //Arrumar Nome para ser NOT NULL
    public class TicketDTO
    {
        [Required(ErrorMessage = "O nome do ticket é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descrição do ticket é obrigatória.")]
        public string Descricao { get; set; } = "nada";

        [Required(ErrorMessage = "A situação do ticket é obrigatória.")]
        public string Situacao { get; set; } = "nada";

        public IFormFile? Imagem { get; set; }

        [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
        public Guid? IdCliente { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public string? IdUsuario { get; set; }

        [Required(ErrorMessage = "O ID do status do ticket é obrigatório.")]
        public Guid? IdStatusTicket { get; set; }

        [Required(ErrorMessage = "O ID do departamento é obrigatório.")]
        public Guid? IdDepartamento { get; set; }

        [Required(ErrorMessage = "O ID da prioridade é obrigatório.")]
        public Guid? IdPrioridade { get; set; }

    }
}
