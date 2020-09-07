namespace JocoWebTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Matricula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstudianteId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursoes", t => t.CursoId, cascadeDelete: false)
                .ForeignKey("dbo.Estudiantes", t => t.EstudianteId, cascadeDelete: false)
                .Index(t => t.EstudianteId)
                .Index(t => t.CursoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes");
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes");
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            DropIndex("dbo.Matriculas", new[] { "EstudianteId" });
            DropTable("dbo.Matriculas");
        }
    }
}
