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
    
    public partial class PagoManoObra
    {
        public int IdPagoManoObra { get; set; }
        public int IdPersona { get; set; }
        public int HorasTrabjadas { get; set; }
        public decimal PagoxHora { get; set; }
        public decimal total { get; set; }
        public bool activo { get; set; }
    
        public virtual Persona Persona { get; set; }
    }
}