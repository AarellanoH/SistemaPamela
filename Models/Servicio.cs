//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pamela_4._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Servicio
    {
        public Servicio()
        {
            this.HistoricoAnuals = new HashSet<HistoricoAnual>();
        }
    
        public int IDServicio { get; set; }
        public string Nombre { get; set; }
        public string Encargado { get; set; }
        public string TelEncargado { get; set; }
        public string Direccion { get; set; }
    
        public virtual ICollection<HistoricoAnual> HistoricoAnuals { get; set; }
    }
}
