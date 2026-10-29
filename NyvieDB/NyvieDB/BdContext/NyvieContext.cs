using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NyvieDB.Models;

namespace NyvieDB.BdContext;

public partial class NyvieContext : DbContext
{
    public NyvieContext()
    {
    }

    public NyvieContext(DbContextOptions<NyvieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Notificacao> Notificacaos { get; set; }

    public virtual DbSet<Prioridade> Prioridades { get; set; }

    public virtual DbSet<StatusTicket> StatusTickets { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TipoNotificacao> TipoNotificacaos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NYVIEDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargo__6C98562524469A29");

            entity.Property(e => e.IdCargo).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D594664267B1A1E5");

            entity.Property(e => e.IdCliente).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433DB5A05E7E");

            entity.Property(e => e.IdDepartamento).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Notificacao>(entity =>
        {
            entity.HasKey(e => e.IdNotificacao).HasName("PK__Notifica__046D3872CCF09539");

            entity.Property(e => e.IdNotificacao).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DataHora).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdTicketNavigation).WithMany(p => p.Notificacaos).HasConstraintName("FK__Notificac__IdTic__2A164134");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificacaos).HasConstraintName("FK__Notificac__IdUsu__29221CFB");

            entity.HasOne(d => d.TipoNotificacao).WithMany(p => p.Notificacaos).HasConstraintName("FK__Notificac__TipoN__2B0A656D");
        });

        modelBuilder.Entity<Prioridade>(entity =>
        {
            entity.HasKey(e => e.IdPrioridade).HasName("PK__Priorida__3A85138FC08BBB83");

            entity.Property(e => e.IdPrioridade).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<StatusTicket>(entity =>
        {
            entity.HasKey(e => e.IdStatusTicket).HasName("PK__StatusTi__18C78E6BE441338A");

            entity.Property(e => e.IdStatusTicket).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK__Ticket__4B93C7E752019617");

            entity.Property(e => e.IdTicket).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DataHora).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Tickets).HasConstraintName("FK__Ticket__IdClient__208CD6FA");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Tickets).HasConstraintName("FK__Ticket__IdDepart__236943A5");

            entity.HasOne(d => d.IdPrioridadeNavigation).WithMany(p => p.Tickets).HasConstraintName("FK__Ticket__IdPriori__245D67DE");

            entity.HasOne(d => d.IdStatusTicketNavigation).WithMany(p => p.Tickets).HasConstraintName("FK__Ticket__IdStatus__22751F6C");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tickets).HasConstraintName("FK__Ticket__IdUsuari__2180FB33");
        });

        modelBuilder.Entity<TipoNotificacao>(entity =>
        {
            entity.HasKey(e => e.IdTipoNotificacao).HasName("PK__TipoNoti__437AF74489EAC992");

            entity.Property(e => e.IdTipoNotificacao).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF970DDA820E");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Usuarios).HasConstraintName("FK__Usuario__IdCargo__571DF1D5");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Usuarios).HasConstraintName("FK__Usuario__IdDepar__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
