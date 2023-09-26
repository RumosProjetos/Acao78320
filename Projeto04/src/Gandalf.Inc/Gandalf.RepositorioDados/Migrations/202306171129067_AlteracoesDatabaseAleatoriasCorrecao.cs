namespace Gandalf.RepositorioDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracoesDatabaseAleatoriasCorrecao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Encomendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DadosEncomenda = c.String(),
                        EmbalarParaPresente = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TabelaAleatoriaParaExemplosComChavePrimariaCompostas",
                c => new
                    {
                        ChavePrimariaPart01 = c.Int(nullable: false, identity: true),
                        ChavePrimariaPart02 = c.DateTime(nullable: false),
                        Dados = c.String(),
                    })
                .PrimaryKey(t => t.ChavePrimariaPart01);
            
            CreateTable(
                "dbo.TabelaAleatoriaParaExemplos",
                c => new
                    {
                        ChavePrimaria = c.Guid(nullable: false, identity: true),
                        Dados = c.String(),
                    })
                .PrimaryKey(t => t.ChavePrimaria);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TabelaAleatoriaParaExemplos");
            DropTable("dbo.TabelaAleatoriaParaExemplosComChavePrimariaCompostas");
            DropTable("dbo.Encomendas");
        }
    }
}
