using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gandalf.MVCWebApp.Models;

public partial class SqldbProjeto4Context : DbContext
{
    public SqldbProjeto4Context()
    {
    }

    public SqldbProjeto4Context(DbContextOptions<SqldbProjeto4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DetalhesVenda> DetalhesVendas { get; set; }

    public virtual DbSet<Encomenda> Encomendas { get; set; }

    public virtual DbSet<Estoque> Estoques { get; set; }

    public virtual DbSet<Loja> Lojas { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Pagamento> Pagamentoes { get; set; }

    public virtual DbSet<PontoDeVenda> PontoDeVendas { get; set; }

    public virtual DbSet<Produto> Produtoes { get; set; }

    public virtual DbSet<TabelaAleatoriaParaExemplo> TabelaAleatoriaParaExemplos { get; set; }

    public virtual DbSet<TabelaAleatoriaParaExemplosComChavePrimariaComposta> TabelaAleatoriaParaExemplosComChavePrimariaCompostas { get; set; }

    public virtual DbSet<TipoPagamento> TipoPagamentoes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venda> Vendas { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=tcp:sql-projeto4.database.windows.net,1433;Initial Catalog=sqldb-projeto4;Persist Security Info=False;User ID=aulaprojeto;Password=abc,1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Categorias");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_dbo.Customer");

            entity.ToTable("Customer");

            entity.Property(e => e.Cidade).HasMaxLength(50);
            entity.Property(e => e.DataNascimento).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(120);
            entity.Property(e => e.Endereco).HasMaxLength(120);
            entity.Property(e => e.Nome).HasMaxLength(60);
            entity.Property(e => e.NumeroIdentificacaoFiscal).HasMaxLength(9);
        });

        modelBuilder.Entity<DetalhesVenda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.DetalhesVendas");

            entity.HasIndex(e => e.ProdutoId, "IX_Produto_Id");

            entity.HasIndex(e => e.VendaId, "IX_Venda_Id");

            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.PrecoUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProdutoId).HasColumnName("Produto_Id");
            entity.Property(e => e.TotalLinha).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VendaId).HasColumnName("Venda_Id");

            entity.HasOne(d => d.Produto).WithMany(p => p.DetalhesVenda)
                .HasForeignKey(d => d.ProdutoId)
                .HasConstraintName("FK_dbo.DetalhesVendas_dbo.Produtoes_Produto_Id");

            entity.HasOne(d => d.Venda).WithMany(p => p.DetalhesVenda)
                .HasForeignKey(d => d.VendaId)
                .HasConstraintName("FK_dbo.DetalhesVendas_dbo.Vendas_Venda_Id");
        });

        modelBuilder.Entity<Encomenda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Encomendas");

            entity.Property(e => e.Discriminator).HasMaxLength(128);
        });

        modelBuilder.Entity<Estoque>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Estoques");

            entity.HasIndex(e => e.LojaId, "IX_Loja_Id");

            entity.HasIndex(e => e.ProdutoId, "IX_Produto_Id");

            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.DataModificacao).HasColumnType("datetime");
            entity.Property(e => e.LojaId).HasColumnName("Loja_Id");
            entity.Property(e => e.ProdutoId).HasColumnName("Produto_Id");

            entity.HasOne(d => d.Loja).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.LojaId)
                .HasConstraintName("FK_dbo.Estoques_dbo.Lojas_Loja_Id");

            entity.HasOne(d => d.Produto).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.ProdutoId)
                .HasConstraintName("FK_dbo.Estoques_dbo.Produtoes_Produto_Id");
        });

        modelBuilder.Entity<Loja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Lojas");

            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.DataModificacao).HasColumnType("datetime");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Pagamentoes");

            entity.HasIndex(e => e.LojaId, "IX_Loja_Id");

            entity.HasIndex(e => e.TipoPagamentoId, "IX_TipoPagamento_Id");

            entity.HasIndex(e => e.VendaId, "IX_Venda_Id");

            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.LojaId).HasColumnName("Loja_Id");
            entity.Property(e => e.TipoPagamentoId).HasColumnName("TipoPagamento_Id");
            entity.Property(e => e.ValorPago).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VendaId).HasColumnName("Venda_Id");

            entity.HasOne(d => d.Loja).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.LojaId)
                .HasConstraintName("FK_dbo.Pagamentoes_dbo.Lojas_Loja_Id");

            entity.HasOne(d => d.TipoPagamento).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.TipoPagamentoId)
                .HasConstraintName("FK_dbo.Pagamentoes_dbo.TipoPagamentoes_TipoPagamento_Id");

            entity.HasOne(d => d.Venda).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.VendaId)
                .HasConstraintName("FK_dbo.Pagamentoes_dbo.Vendas_Venda_Id");
        });

        modelBuilder.Entity<PontoDeVenda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.PontoDeVendas");

            entity.HasIndex(e => e.LojaId, "IX_Loja_Id");

            entity.Property(e => e.LojaId).HasColumnName("Loja_Id");

            entity.HasOne(d => d.Loja).WithMany(p => p.PontoDeVenda)
                .HasForeignKey(d => d.LojaId)
                .HasConstraintName("FK_dbo.PontoDeVendas_dbo.Lojas_Loja_Id");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Produtoes");

            entity.HasIndex(e => e.CategoriaId, "IX_Categoria_Id");

            entity.Property(e => e.CategoriaId).HasColumnName("Categoria_Id");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.DataModificacao).HasColumnType("datetime");
            entity.Property(e => e.PrecoUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK_dbo.Produtoes_dbo.Categorias_Categoria_Id");
        });

        modelBuilder.Entity<TabelaAleatoriaParaExemplo>(entity =>
        {
            entity.HasKey(e => e.ChavePrimaria).HasName("PK_dbo.TabelaAleatoriaParaExemplos");

            entity.Property(e => e.ChavePrimaria).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<TabelaAleatoriaParaExemplosComChavePrimariaComposta>(entity =>
        {
            entity.HasKey(e => e.ChavePrimariaPart01).HasName("PK_dbo.TabelaAleatoriaParaExemplosComChavePrimariaCompostas");

            entity.Property(e => e.ChavePrimariaPart02).HasColumnType("datetime");
        });

        modelBuilder.Entity<TipoPagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.TipoPagamentoes");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Usuarios");

            entity.Property(e => e.Cidade).HasMaxLength(50);
            entity.Property(e => e.DataNascimento).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(120);
            entity.Property(e => e.Endereco).HasMaxLength(120);
            entity.Property(e => e.Nome).HasMaxLength(60);
            entity.Property(e => e.NomeUsuario)
                .HasMaxLength(15)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Telefone).HasMaxLength(9);
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Vendas");

            entity.HasIndex(e => e.ClienteId, "IX_Cliente_Id");

            entity.HasIndex(e => e.LojaId, "IX_Loja_Id");

            entity.HasIndex(e => e.PontoDeVendaId, "IX_PontoDeVenda_Id");

            entity.HasIndex(e => e.UsuarioId, "IX_Usuario_Id");

            entity.Property(e => e.ClienteId).HasColumnName("Cliente_Id");
            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.DataModificacao).HasColumnType("datetime");
            entity.Property(e => e.LojaId).HasColumnName("Loja_Id");
            entity.Property(e => e.PontoDeVendaId).HasColumnName("PontoDeVenda_Id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venda)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_dbo.Vendas_dbo.Customer_Cliente_Id");

            entity.HasOne(d => d.Loja).WithMany(p => p.Venda)
                .HasForeignKey(d => d.LojaId)
                .HasConstraintName("FK_dbo.Vendas_dbo.Lojas_Loja_Id");

            entity.HasOne(d => d.PontoDeVenda).WithMany(p => p.Venda)
                .HasForeignKey(d => d.PontoDeVendaId)
                .HasConstraintName("FK_dbo.Vendas_dbo.PontoDeVendas_PontoDeVenda_Id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Venda)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_dbo.Vendas_dbo.Usuarios_Usuario_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
