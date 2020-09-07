using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JocoWebTesting.Models
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext() : base ("DefaultConnection")
        {

        }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesion> Profesiones { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EstudianteCurso>().HasKey(x => new { x.CursoId, x.EstudianteId });
        }
    }
}