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
    
    public partial class Becado
    {
        public Becado()
        {
            this.HistoricoAnuals = new HashSet<HistoricoAnual>();
        }
    
        public int IDBecado { get; set; }
        public int IDPadre { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
    
        public virtual Tutor Tutor { get; set; }
        public virtual ICollection<HistoricoAnual> HistoricoAnuals { get; set; }
    }
}
