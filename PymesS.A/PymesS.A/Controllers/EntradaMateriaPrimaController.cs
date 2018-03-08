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
    public class EntradaMateriaPrimaController : Controller
    {
        private DB_PymesEntities db = new DB_PymesEntities();

        // GET: EntradaMateriaPrima
        public ActionResult Index()
        {
            var entradaMateriaPrima = db.EntradaMateriaPrima.Include(e => e.Proveedor).Include(e => e.Inventario);
            return View(entradaMateriaPrima.ToList());
        }

        // GET: EntradaMateriaPrima/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaMateriaPrima entradaMateriaPrima = db.EntradaMateriaPrima.Find(id);
            if (entradaMateriaPrima == null)
            {
                return HttpNotFound();
            }
            return View(entradaMateriaPrima);
        }

        // GET: EntradaMateriaPrima/Create
        public ActionResult Create()
        {
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombres");
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "IdInventario");
            return View();
        }

        // POST: EntradaMateriaPrima/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMatriaPrima,IdProveedor,IdInventario,NombreMateriaPrima,FechaEntrante,CantidadEntrante,Descripcion,PrecioxUnidad,activo")] EntradaMateriaPrima entradaMateriaPrima)
        {
            if (ModelState.IsValid)
            {
                db.EntradaMateriaPrima.Add(entradaMateriaPrima);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombres", entradaMateriaPrima.IdProveedor);
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "IdInventario", entradaMateriaPrima.IdInventario);
            return View(entradaMateriaPrima);
        }

        // GET: EntradaMateriaPrima/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaMateriaPrima entradaMateriaPrima = db.EntradaMateriaPrima.Find(id);
            if (entradaMateriaPrima == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombres", entradaMateriaPrima.IdProveedor);
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "IdInventario", entradaMateriaPrima.IdInventario);
            return View(entradaMateriaPrima);
        }

        // POST: EntradaMateriaPrima/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMatriaPrima,IdProveedor,IdInventario,NombreMateriaPrima,FechaEntrante,CantidadEntrante,Descripcion,PrecioxUnidad,activo")] EntradaMateriaPrima entradaMateriaPrima)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradaMateriaPrima).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombres", entradaMateriaPrima.IdProveedor);
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "IdInventario", entradaMateriaPrima.IdInventario);
            return View(entradaMateriaPrima);
        }

        // GET: EntradaMateriaPrima/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaMateriaPrima entradaMateriaPrima = db.EntradaMateriaPrima.Find(id);
            if (entradaMateriaPrima == null)
            {
                return HttpNotFound();
            }
            return View(entradaMateriaPrima);
        }

        // POST: EntradaMateriaPrima/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntradaMateriaPrima entradaMateriaPrima = db.EntradaMateriaPrima.Find(id);
            db.EntradaMateriaPrima.Remove(entradaMateriaPrima);
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
