using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymesS.A.Entity
{
    public class ProductosViewModel
    {
        private DB_PymesEntities contexto;

        public ProductosViewModel()
        {
            contexto = new DB_PymesEntities();
            
        }
        //public List<BuscarProducto> Productos { get; set; }

        //public void BuscarPorNombre(string busqueda)
        //{
        //    var consulta = from p in contexto.Productos
        //                   where p.NombreProducto.Contains(busqueda)
        //                   select new
        //                   {

        //                       p.Producto.IdProducto,
        //                       p.Producto.NombreProducto,
        //                       p.Producto.PrecioXUnidad,
        //                       p.Producto.Descripcion,
        //                       TipoProducto = p.TipoProducto.NombresTipoProducto ?? "",
        //                       NombresTipoProducto = (from t in p.NombresTipoProducto)

        //                   }
        //}

        private DB_PymesEntities db = new DB_PymesEntities();

        public void actualizar_mo()
        {

           
                
            
            var pagomanoobra = db.PagoManoObra.ToList();
            foreach(var n in pagomanoobra)
            {
                n.total = n.HorasTrabjadas * n.PagoxHora;
            }
            db.SaveChanges();
        }

        

        //Get: /PagoMo/
    }

}
