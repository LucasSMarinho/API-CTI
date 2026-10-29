using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace NyvieDB.Models;

[Table("Cliente")]
public partial class Cliente
{
    [Key]
    public Guid IdCliente { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefone { get; set; }

    [InverseProperty("IdClienteNavigation")]
    [JsonIgnore]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
