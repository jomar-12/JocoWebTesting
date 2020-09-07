using JocoWebTesting.Models;
using JocoWebTesting.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JocoWebTesting.Controllers
{
    public class EstudianteCursoController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult EstudianteEnCurso()
        {
            ViewBag.Profesiones = new SelectList(context.Profesiones.ToList(), "Id", "Nombre");

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EstudianteEnCurso(int? curso, int[] estudiantesId)
        {
            if (!curso.HasValue || estudiantesId == null)
            {
                ViewBag.Profesiones = new SelectList(context.Profesiones.ToList(), "Id", "Nombre");
                ViewBag.NotValidated = "Debe llenar toda la información.";

                return View();
            }

            EstudianteCursoResult estudianteCursoResult = new EstudianteCursoResult();

            foreach (var id in estudiantesId)
            {
                var est = context.Estudiantes.Find(id);

                if (context.EstudiantesCursos.Any(x => x.EstudianteId == est.Id && x.CursoId == curso.Value))
                {
                    estudianteCursoResult.EstudiantesOmitidos.Add(est.Nombre);
                }
                else
                {
                    context.EstudiantesCursos.Add(new EstudianteCurso { CursoId = curso.Value, EstudianteId = id });
                    estudianteCursoResult.EstudiantesAnadidos.Add(est.Nombre);
                }
            }

            context.SaveChanges();

            ViewBag.Profesiones = new SelectList(context.Profesiones.ToList(), "Id", "Nombre");
            ViewBag.SaveResult = estudianteCursoResult;

            return View();
        }

        public ActionResult EstudiantesPorCurso()
        {
            return View();
        }

        public PartialViewResult GetCursos(int profesionId)
        {
            var cursos = context.Cursos.Where(x => x.ProfesionId == profesionId).ToList();

            var cursosDropDown = new SelectList(cursos, "Id", "NombreCurso");

            return PartialView("_cursos", cursosDropDown);
        }

        public PartialViewResult GetEstudiantes(int profesionId)
        {
            var estudiantes = context.Estudiantes.Where(x => x.ProfesionId == profesionId).ToList();

            return PartialView("_estudiantes", estudiantes);
        }
    }
}