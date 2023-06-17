namespace Gandalf.RepositorioDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Endereco = c.String(maxLength: 120),
                        Cidade = c.String(maxLength: 50),
                        Email = c.String(maxLength: 120),
                        NumeroIdentificacaoFiscal = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroFatura = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        Pago = c.Boolean(nullable: false),
                        Cliente_Id = c.Int(),
                        Loja_Id = c.Int(),
                        PontoDeVenda_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Cliente_Id)
                .ForeignKey("dbo.Lojas", t => t.Loja_Id)
                .ForeignKey("dbo.PontoDeVendas", t => t.PontoDeVenda_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Loja_Id)
                .Index(t => t.PontoDeVenda_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Lojas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Morada = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PontoDeVendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Localizacao = c.String(),
                        Loja_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lojas", t => t.Loja_Id)
                .Index(t => t.Loja_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Endereco = c.String(maxLength: 120),
                        Cidade = c.String(maxLength: 50),
                        Email = c.String(maxLength: 120),
                        Telefone = c.String(nullable: false, maxLength: 9),
                        Password = c.String(),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalhesVendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sequencial = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalLinha = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCriacao = c.DateTime(nullable: false),
                        Produto_Id = c.Int(),
                        Venda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id)
                .ForeignKey("dbo.Vendas", t => t.Venda_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.Venda_Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CodigoBarras = c.String(),
                        UnidadeMedida = c.String(),
                        QuantidadePorUnidade = c.Int(nullable: false),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discontinuado = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        QuantidadeBase = c.Int(nullable: false),
                        UnidadeVenda = c.String(),
                        QuantidadeUnidadeVenda = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        Loja_Id = c.Int(),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lojas", t => t.Loja_Id)
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id)
                .Index(t => t.Loja_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.Pagamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValorPago = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCriacao = c.DateTime(nullable: false),
                        Loja_Id = c.Int(),
                        TipoPagamento_Id = c.Int(),
                        Venda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lojas", t => t.Loja_Id)
                .ForeignKey("dbo.TipoPagamentoes", t => t.TipoPagamento_Id)
                .ForeignKey("dbo.Vendas", t => t.Venda_Id)
                .Index(t => t.Loja_Id)
                .Index(t => t.TipoPagamento_Id)
                .Index(t => t.Venda_Id);
            
            CreateTable(
                "dbo.TipoPagamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagamentoes", "Venda_Id", "dbo.Vendas");
            DropForeignKey("dbo.Pagamentoes", "TipoPagamento_Id", "dbo.TipoPagamentoes");
            DropForeignKey("dbo.Pagamentoes", "Loja_Id", "dbo.Lojas");
            DropForeignKey("dbo.Estoques", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Estoques", "Loja_Id", "dbo.Lojas");
            DropForeignKey("dbo.DetalhesVendas", "Venda_Id", "dbo.Vendas");
            DropForeignKey("dbo.DetalhesVendas", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.Vendas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Vendas", "PontoDeVenda_Id", "dbo.PontoDeVendas");
            DropForeignKey("dbo.PontoDeVendas", "Loja_Id", "dbo.Lojas");
            DropForeignKey("dbo.Vendas", "Loja_Id", "dbo.Lojas");
            DropForeignKey("dbo.Vendas", "Cliente_Id", "dbo.Customer");
            DropIndex("dbo.Pagamentoes", new[] { "Venda_Id" });
            DropIndex("dbo.Pagamentoes", new[] { "TipoPagamento_Id" });
            DropIndex("dbo.Pagamentoes", new[] { "Loja_Id" });
            DropIndex("dbo.Estoques", new[] { "Produto_Id" });
            DropIndex("dbo.Estoques", new[] { "Loja_Id" });
            DropIndex("dbo.Produtoes", new[] { "Categoria_Id" });
            DropIndex("dbo.DetalhesVendas", new[] { "Venda_Id" });
            DropIndex("dbo.DetalhesVendas", new[] { "Produto_Id" });
            DropIndex("dbo.PontoDeVendas", new[] { "Loja_Id" });
            DropIndex("dbo.Vendas", new[] { "Usuario_Id" });
            DropIndex("dbo.Vendas", new[] { "PontoDeVenda_Id" });
            DropIndex("dbo.Vendas", new[] { "Loja_Id" });
            DropIndex("dbo.Vendas", new[] { "Cliente_Id" });
            DropTable("dbo.TipoPagamentoes");
            DropTable("dbo.Pagamentoes");
            DropTable("dbo.Estoques");
            DropTable("dbo.Produtoes");
            DropTable("dbo.DetalhesVendas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.PontoDeVendas");
            DropTable("dbo.Lojas");
            DropTable("dbo.Vendas");
            DropTable("dbo.Customer");
            DropTable("dbo.Categorias");
        }
    }
}
