namespace JocoWebTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecascadeTRUE : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes");
            DropIndex("dbo.Matriculas", new[] { "EstudianteId" });
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            AlterColumn("dbo.Matriculas", "EstudianteId", c => c.Int());
            AlterColumn("dbo.Matriculas", "CursoId", c => c.Int());
            CreateIndex("dbo.Matriculas", "EstudianteId");
            CreateIndex("dbo.Matriculas", "CursoId");
            AddForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes", "Id");
            AddForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes");
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes");
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            DropIndex("dbo.Matriculas", new[] { "EstudianteId" });
            AlterColumn("dbo.Matriculas", "CursoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Matriculas", "EstudianteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matriculas", "CursoId");
            CreateIndex("dbo.Matriculas", "EstudianteId");
            AddForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes", "Id", cascadeDelete: true);
        }
    }
}
