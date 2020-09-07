using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Web;

namespace JocoWebTesting.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Código { get; set; }

        [Display(Name ="Curso")]
        public string NombreCurso { get; set; }

        //Foreing Key

        [Display(Name ="Profesión")]
        public int ProfesionId { get; set; }
        public Profesion Profesion { get; set; }

        public List<EstudianteCurso> EstudianteCursos { get; set; }

        public static void DameNumeros(Action<int> counter, int numbers)
        {
            for (int i = 1; i <= numbers; i++)
            {
                Thread.Sleep(1000);
                counter(i);
            }
        }

    }
}