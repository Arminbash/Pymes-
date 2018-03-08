using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity;

namespace PymesS.A.Controllers
{
    public class PersonaController : Controller
    {
        private DB_PymesEntities db = new DB_PymesEntities();

        // GET: Persona
        public ActionResult Index()
        {
            var persona = (from s in db.Persona
                           where s.Nombre.StartsWith("E")
                           orderby s.Apellido
                           select s);
            return View(persona.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoPersona = new SelectList(db.TipoPersona, "IdTipoPersona", "NombresTipoPersona");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario");
            return View();
        }

        // POST: Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPersona,Nombre,Apellido,Cedula,Direccion,IdTipoPersona,IdUsuario,activo")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPersona = new SelectList(db.TipoPersona, "IdTipoPersona", "NombresTipoPersona", persona.IdTipoPersona);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario", persona.IdUsuario);
            return View(persona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoPersona = new SelectList(db.TipoPersona, "IdTipoPersona", "NombresTipoPersona", persona.IdTipoPersona);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario", persona.IdUsuario);
            return View(persona);
        }

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPersona,Nombre,Apellido,Cedula,Direccion,IdTipoPersona,IdUsuario,activo")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPersona = new SelectList(db.TipoPersona, "IdTipoPersona", "NombresTipoPersona", persona.IdTipoPersona);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario", persona.IdUsuario);
            return View(persona);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
            db.SaveChanges();
            return RedirectToAction("Index");
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
