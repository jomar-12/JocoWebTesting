using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JocoWebTesting.Models
{
    public class Profesion
    {
        public int Id { get; set; }
        [Display(Name = "Profesión")]
        public string Nombre { get; set; }

        //Foreing key
        public ICollection<Curso> Cursos { get; set; } 

        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

    }
}