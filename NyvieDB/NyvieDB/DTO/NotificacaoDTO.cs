using System.ComponentModel.DataAnnotations;

namespace NyvieDB.DTO
{
    public class NotificacaoDTO
    {
        public string? DataHora { get; set; }

        public Guid? TipoNotificacaoId { get; set; }  

        public Guid? IdTicket { get; set; }
        
        public string? IdUsuario { get; set; }    

        public string? Descricao { get; set; }
    }
}
