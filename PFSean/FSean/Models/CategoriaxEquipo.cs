//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FSean.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoriaxEquipo
    {
        public int iId { get; set; }
        public int iIdCategoria { get; set; }
        public int iIdEquipo { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Equipo Equipo { get; set; }
    }
}
