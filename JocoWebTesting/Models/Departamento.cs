using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JocoWebTesting.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Display(Name = "Departamento")]
        public string Nombre { get; set; }

        // Foreing Key

        public ICollection<Profesion> Profesiones { get; set; }
    }
}