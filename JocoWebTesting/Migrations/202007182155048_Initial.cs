namespace JocoWebTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profesions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DepartamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentoes", t => t.DepartamentoId, cascadeDelete: true)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Gpa = c.Double(nullable: false),
                        ProfesionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profesions", t => t.ProfesionId, cascadeDelete: true)
                .Index(t => t.ProfesionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estudiantes", "ProfesionId", "dbo.Profesions");
            DropForeignKey("dbo.Profesions", "DepartamentoId", "dbo.Departamentoes");
            DropIndex("dbo.Estudiantes", new[] { "ProfesionId" });
            DropIndex("dbo.Profesions", new[] { "DepartamentoId" });
            DropTable("dbo.Estudiantes");
            DropTable("dbo.Profesions");
            DropTable("dbo.Departamentoes");
        }
    }
}
