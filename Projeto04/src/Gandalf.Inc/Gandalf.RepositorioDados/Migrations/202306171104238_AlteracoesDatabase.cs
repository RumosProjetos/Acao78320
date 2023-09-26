namespace Gandalf.RepositorioDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracoesDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "DataNascimento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vendas", "Promocao", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "NomeUsuario", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Usuarios", "DataNascimento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "DataNascimento");
            DropColumn("dbo.Usuarios", "NomeUsuario");
            DropColumn("dbo.Vendas", "Promocao");
            DropColumn("dbo.Customer", "DataNascimento");
        }
    }
}
