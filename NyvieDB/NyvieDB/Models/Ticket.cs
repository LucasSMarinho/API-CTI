using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace NyvieDB.Models;

[Table("Ticket")]
public partial class Ticket
{
    [Key]
    public Guid IdTicket { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Nome { get; set; }

    [StringLength(512)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string Situacao { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataHora { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Imagem { get; set; }

    public Guid? IdCliente { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? IdUsuario { get; set; }

    public Guid? IdStatusTicket { get; set; }

    public Guid? IdDepartamento { get; set; }

    public Guid? IdPrioridade { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("Tickets")]
    public virtual Cliente? IdClienteNavigation { get; set; }

    [ForeignKey("IdDepartamento")]
    [InverseProperty("Tickets")]
    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    [ForeignKey("IdPrioridade")]
    [InverseProperty("Tickets")]
    public virtual Prioridade? IdPrioridadeNavigation { get; set; }

    [ForeignKey("IdStatusTicket")]
    [InverseProperty("Tickets")]
    public virtual StatusTicket? IdStatusTicketNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Tickets")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }

    [InverseProperty("IdTicketNavigation")]
    [JsonIgnore]
    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();
}
