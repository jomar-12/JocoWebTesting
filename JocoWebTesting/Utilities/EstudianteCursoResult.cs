using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JocoWebTesting.Utilities
{
    public class EstudianteCursoResult
    {
        public List<string> EstudiantesAnadidos { get; set; } = new List<string>();
        public List<string> EstudiantesOmitidos { get; set; } = new List<string>();
    }
}