using System.ComponentModel.DataAnnotations;

namespace NyvieDB.DTO
{
    public class TicketDTOUpt
    {
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public string? Situacao { get; set; }

        public IFormFile? Imagem { get; set; }

        public Guid? IdCliente { get; set; }

        public string? IdUsuario { get; set; }

        public Guid? IdStatusTicket { get; set; }

        public Guid? IdDepartamento { get; set; }

        public Guid? IdPrioridade { get; set; }
    }
}
