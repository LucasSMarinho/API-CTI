using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace NyvieDB.Models;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    [StringLength(40)]
    [Unicode(false)]
    public string IdUsuario { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Imagem { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Senha { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefone { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public Guid? IdDepartamento { get; set; }

    public Guid? IdCargo { get; set; }

    [ForeignKey("IdCargo")]
    [InverseProperty("Usuarios")]
    public virtual Cargo? IdCargoNavigation { get; set; }

    [ForeignKey("IdDepartamento")]
    [InverseProperty("Usuarios")]
    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    [JsonIgnore]
    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();

    [InverseProperty("IdUsuarioNavigation")]
    [JsonIgnore]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
