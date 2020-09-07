namespace JocoWebTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstudianteCursoMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes");
            DropIndex("dbo.Matriculas", new[] { "EstudianteId" });
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            CreateTable(
                "dbo.EstudianteCursoes",
                c => new
                    {
                        CursoId = c.Int(nullable: false),
                        EstudianteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CursoId, t.EstudianteId })
                .ForeignKey("dbo.Cursoes", t => t.CursoId, cascadeDelete: false)
                .ForeignKey("dbo.Estudiantes", t => t.EstudianteId, cascadeDelete: false)
                .Index(t => t.CursoId)
                .Index(t => t.EstudianteId);
            
            DropTable("dbo.Matriculas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstudianteId = c.Int(),
                        CursoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.EstudianteCursoes", "EstudianteId", "dbo.Estudiantes");
            DropForeignKey("dbo.EstudianteCursoes", "CursoId", "dbo.Cursoes");
            DropIndex("dbo.EstudianteCursoes", new[] { "EstudianteId" });
            DropIndex("dbo.EstudianteCursoes", new[] { "CursoId" });
            DropTable("dbo.EstudianteCursoes");
            CreateIndex("dbo.Matriculas", "CursoId");
            CreateIndex("dbo.Matriculas", "EstudianteId");
            AddForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes", "Id");
            AddForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes", "Id");
        }
    }
}
