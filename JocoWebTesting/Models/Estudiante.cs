using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JocoWebTesting.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        [Display(Name ="Nombre de estudiante")]
        public string Nombre { get; set; }
        public double Gpa { get; set; }


        // Foreing key
        [Display(Name = "Profesión")]
        public int ProfesionId { get; set; }
        public Profesion Profesion { get; set; }
        public List<EstudianteCurso> EstudianteCursos { get; set; }
    }
}