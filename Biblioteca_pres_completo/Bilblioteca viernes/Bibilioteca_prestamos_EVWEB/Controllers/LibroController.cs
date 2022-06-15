using Bibilioteca_prestamos_EVWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bibilioteca_prestamos_EVWEB.Controllers
{
    public class LibroController : Controller
    {
        prestamos_bibliotecaEntities db = new prestamos_bibliotecaEntities();

        // GET: Libro
        public ActionResult Index()
        {
            var Libros = db.Libro.ToList();

            return View(Libros);
        }

        public ActionResult Create()
        {          
            ViewBag.id_Editorial = new SelectList(db.Editorial , "id_Editorial", "Nombre");
            ViewBag.id_Autor = new SelectList(db.Autor, "id_Autor", "Nombre");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Libro Libros)
        {
            db.Libro.Add(Libros);
            db.SaveChanges();
    
            ViewBag.id_Editorial = new SelectList(db.Editorial, "id_Editorial", "Nombre");     
            ViewBag.id_Autor = new SelectList(db.Autor, "id_Autor", "Nombre");
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {

                var Libros = db.Libro.Find(id);
                if (Libros != null)
                {
                    ViewBag.id_Editorial = new SelectList(db.Editorial, "id_Editorial", "Nombre",Libros.id_Editorial);
                    ViewBag.id_Autor = new SelectList(db.Autor, "id_Autor", "Nombre",Libros.id_Autor);
                    return View(Libros);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Libro Libros)
        {

            db.Entry(Libros).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var Libros = db.Libro.Find(id);
                if (Libros != null)
                {
                    return View(Libros);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteAccept(int id)
        {
            var Libros = db.Libro.Find(id);
            db.Libro.Remove(Libros);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}