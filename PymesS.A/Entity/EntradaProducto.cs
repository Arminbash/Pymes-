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
    
    public partial class EntradaProducto
    {
        public int IdEntradaProducto { get; set; }
        public int IdInventario { get; set; }
        public int IdProducto { get; set; }
        public string NombreMateriaPrima { get; set; }
        public System.DateTime FechaEntrante { get; set; }
        public int CantidadEntrante { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioxUnidad { get; set; }
        public bool activo { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Inventario Inventario { get; set; }
    }
}
