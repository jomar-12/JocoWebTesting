using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JocoWebTesting.Models;

namespace JocoWebTesting.Controllers
{
    public class CursosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cursos
        public ActionResult Index()
        {
            var cursos = db.Cursos.Include(c => c.Profesion);
            return View(cursos.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.ProfesionId = new SelectList(db.Profesiones, "Id", "Nombre");
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Código,NombreCurso,ProfesionId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfesionId = new SelectList(db.Profesiones, "Id", "Nombre", curso.ProfesionId);
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfesionId = new SelectList(db.Profesiones, "Id", "Nombre", curso.ProfesionId);
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Código,NombreCurso,ProfesionId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfesionId = new SelectList(db.Profesiones, "Id", "Nombre", curso.ProfesionId);
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursos.Find(id);
            db.Cursos.Remove(curso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Students(int? id, string nombreCurso, string nombreProfesion)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Curso curso = db.Cursos.Find(id);

            if (curso == null)
            {
                return HttpNotFound();
            }

            var estudianteCurso = db.EstudiantesCursos.Include(x => x.Estudiante).Where(c => c.CursoId == curso.Id).ToList();
            ViewBag.Profesion = nombreProfesion;
            ViewBag.Curso = nombreCurso;

            return View(estudianteCurso);
        }

        public ActionResult DeleteFromCourse(int? estudianteId, int? cursoId, string nombreCurso, string nombreProfesion)
        {
            if(!(estudianteId.HasValue && cursoId.HasValue))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var estudiantecurso = db.EstudiantesCursos.Where(c => c.EstudianteId == estudianteId.Value && c.CursoId == cursoId.Value).FirstOrDefault();

            if(estudiantecurso == null)
            {
                return HttpNotFound();
            }

            db.EstudiantesCursos.Remove(estudiantecurso);
            db.SaveChanges();

            return RedirectToAction("Students", new { id = cursoId, nombreCurso, nombreProfesion });

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
