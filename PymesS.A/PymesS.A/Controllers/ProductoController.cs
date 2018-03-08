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
    public class ProductoController : Controller
    {
        private DB_PymesEntities db = new DB_PymesEntities();
        private Producto producto = new Producto();
        private BuscProducto pl = new BuscProducto();
        
        // GET: Producto
        public ActionResult Index()
        {
            //var productolist = from p in db.Producto
            //                   .Include(producto => producto.TipoProducto )
            //                   select new ProductoViewModel
            //                   {
            //                       IdProducto = p.IdProducto,
            //                       NombreProducto = p.NombreProducto,
            //                       PrecioXUnidad = p.PrecioXUnidad,
            //                       Descripcion = p.Descripcion,
            //                       activo = p.activo,
            //                       NombresTipoProducto = p.TipoProducto.NombresTipoProducto
            //                   };

            return View(producto.Listar());
        }

        public JsonResult BuscarProducto(string nombre)
        {
            return Json(pl.Buscar(nombre));

        }



        public ActionResult Ver(int id)
        {
            return View(producto.Obtener(id));
        }

         public ActionResult Crud(int id = 0)
        {
            return View(id > 0 ? producto.Obtener(id) : producto);
        }
       
    }
}
