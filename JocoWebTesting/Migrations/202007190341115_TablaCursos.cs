namespace JocoWebTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaCursos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Código = c.String(),
                        NombreCurso = c.String(),
                        ProfesionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profesions", t => t.ProfesionId, cascadeDelete: true)
                .Index(t => t.ProfesionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cursoes", "ProfesionId", "dbo.Profesions");
            DropIndex("dbo.Cursoes", new[] { "ProfesionId" });
            DropTable("dbo.Cursoes");
        }
    }
}
