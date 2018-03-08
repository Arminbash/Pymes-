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
    public class PagoManoObrasController : Controller
    {
        private DB_PymesEntities db = new DB_PymesEntities();

        public void actualizar_mo()
        {
            var pagomanoobra = db.PagoManoObra.ToList();
            foreach (var n in pagomanoobra)
            {
                n.total = n.HorasTrabjadas * n.PagoxHora;
            }
            db.SaveChanges();
        }
        // GET: PagoManoObras
        public ActionResult Index()
        {
            var pagoManoObra = db.PagoManoObra.Include(p => p.Persona);
            return View(pagoManoObra.ToList());
        }

        // GET: PagoManoObras/Details/5
        public ActionResult Details(int? id)
        {
            actualizar_mo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagoManoObra pagoManoObra = db.PagoManoObra.Find(id);
            if (pagoManoObra == null)
            {
                return HttpNotFound();
            }
            return View(pagoManoObra);
        }

        

        // GET: PagoManoObras/Create
        public ActionResult Create()
        {


            ViewBag.IdPersona = new SelectList(db.Persona, "IdPersona", "Nombre");
            return View();


        }

        // POST: PagoManoObras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPagoManoObra,IdPersona,HorasTrabjadas,PagoxHora,total,activo")] PagoManoObra pagoManoObra)
        {
            if (ModelState.IsValid)
            {
                db.PagoManoObra.Add(pagoManoObra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPersona = new SelectList(db.Persona, "IdPersona", "Nombre", pagoManoObra.IdPersona);
            return View(pagoManoObra);
        }

        // GET: PagoManoObras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagoManoObra pagoManoObra = db.PagoManoObra.Find(id);
            if (pagoManoObra == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPersona = new SelectList(db.Persona, "IdPersona", "Nombre", pagoManoObra.IdPersona);
            return View(pagoManoObra);
        }

        // POST: PagoManoObras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPagoManoObra,IdPersona,HorasTrabjadas,PagoxHora,total,activo")] PagoManoObra pagoManoObra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagoManoObra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPersona = new SelectList(db.Persona, "IdPersona", "Nombre", pagoManoObra.IdPersona);
            return View(pagoManoObra);
        }

        // GET: PagoManoObras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagoManoObra pagoManoObra = db.PagoManoObra.Find(id);
            if (pagoManoObra == null)
            {
                return HttpNotFound();
            }
            return View(pagoManoObra);
        }

        // POST: PagoManoObras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagoManoObra pagoManoObra = db.PagoManoObra.Find(id);
            db.PagoManoObra.Remove(pagoManoObra);
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
