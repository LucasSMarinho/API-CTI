using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NyvieDB.Models;

[Table("Notificacao")]
public partial class Notificacao
{
    [Key]
    public Guid IdNotificacao { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataHora { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? IdUsuario { get; set; }

    public Guid? IdTicket { get; set; }

    [Column("TipoNotificacaoID")]
    public Guid? TipoNotificacaoId { get; set; }

    [ForeignKey("IdTicket")]
    [InverseProperty("Notificacaos")]
    public virtual Ticket? IdTicketNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Notificacaos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }

    [ForeignKey("TipoNotificacaoId")]
    [InverseProperty("Notificacaos")]
    public virtual TipoNotificacao? TipoNotificacao { get; set; }
}
