//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrograAvanzada.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class historico_tarea
    {
        public int id_log { get; set; }
        public int cod_tarea { get; set; }
        public string cod_usuarioProyecto { get; set; }
        public string observacion { get; set; }
        public System.DateTime fecha_cambio { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual tarea tarea { get; set; }
    }
}
