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
    public class EntradaProductoController : Controller
    {
        private DB_PymesEntities db = new DB_PymesEntities();

        // GET: EntradaProducto
        public ActionResult Index()
        {
            var entradaProducto = db.EntradaProducto.Include(e => e.Producto).Include(e => e.Inventario);
            return View(entradaProducto.ToList());
        }

        // GET: EntradaProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaProducto entradaProducto = db.EntradaProducto.Find(id);
            if (entradaProducto == null)
            {
                return HttpNotFound();
            }
            return View(entradaProducto);
        }

        // GET: EntradaProducto/Create
        public ActionResult Create()
        {
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "NombreProducto");
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "IdInventario");
            return View();
        }

        // POST: EntradaProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEntradaProducto,IdInventario,IdProducto,NombreMateriaPrima,FechaEntrante,CantidadEntrante,Descripcion,PrecioxUnidad,activo")] EntradaProducto entradaProducto)
        {
            if (ModelState.IsValid)
            {
                db.EntradaProducto.Add(entradaProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "NombreProducto", entradaProducto.IdProducto);
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "IdInventario", entradaProducto.IdInventario);
            return View(entradaProducto);
        }

        // GET: EntradaProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaProducto entradaProducto = db.EntradaProducto.Find(id);
            if (entradaProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "NombreProducto", entradaProducto.IdProducto);
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "IdInventario", entradaProducto.IdInventario);
            return View(entradaProducto);
        }

        // POST: EntradaProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEntradaProducto,IdInventario,IdProducto,NombreMateriaPrima,FechaEntrante,CantidadEntrante,Descripcion,PrecioxUnidad,activo")] EntradaProducto entradaProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradaProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "NombreProducto", entradaProducto.IdProducto);
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "IdInventario", entradaProducto.IdInventario);
            return View(entradaProducto);
        }

        // GET: EntradaProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaProducto entradaProducto = db.EntradaProducto.Find(id);
            if (entradaProducto == null)
            {
                return HttpNotFound();
            }
            return View(entradaProducto);
        }

        // POST: EntradaProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntradaProducto entradaProducto = db.EntradaProducto.Find(id);
            db.EntradaProducto.Remove(entradaProducto);
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
