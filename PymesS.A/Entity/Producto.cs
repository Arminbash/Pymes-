//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.CostoProduccion = new HashSet<CostoProduccion>();
            this.EntradaProducto = new HashSet<EntradaProducto>();
            this.Inventario = new HashSet<Inventario>();
            TipoProducto = new TipoProducto();
        }
    
        public int IdProducto { get; set; }
        public int IdTipoProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioXUnidad { get; set; }
        public string Descripcion { get; set; }
        public bool activo { get; set; }

        public TipoProducto TipoProducto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CostoProduccion> CostoProduccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntradaProducto> EntradaProducto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventario> Inventario { get; set; }
        

        public List<Producto> Listar()
        {
            var producto = new List<Producto>();
            try
            {
                using (var context = new DB_PymesEntities())
                {

                    producto = context.Producto.ToList();
                    
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return producto;
        }

        public Producto Obtener(int id)
        {
            var producto = new Producto();
            try
            {
                using (var context = new DB_PymesEntities())
                {
                    producto = context.Producto
                            .Where(x => x.IdProducto == id)
                            .Single();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return producto;

        }


        



    }
}
