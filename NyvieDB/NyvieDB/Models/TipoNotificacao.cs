using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace NyvieDB.Models;

[Table("TipoNotificacao")]
public partial class TipoNotificacao
{
    [Key]
    public Guid IdTipoNotificacao { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [InverseProperty("TipoNotificacao")]
    [JsonIgnore]
    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();
}
