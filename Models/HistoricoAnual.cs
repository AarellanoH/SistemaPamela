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
    
    public partial class HistoricoAnual
    {
        public HistoricoAnual()
        {
            this.FolioAnuals = new HashSet<FolioAnual>();
        }
    
        public int IDHistoricoAnual { get; set; }
        public int IDPeriodos { get; set; }
        public int IDBecado { get; set; }
        public int IDCategoria { get; set; }
        public Nullable<int> IDEscuela { get; set; }
        public Nullable<int> Promedio { get; set; }
        public Nullable<int> IDServicio { get; set; }
        public Nullable<int> HorasRealizadas { get; set; }
    
        public virtual Becado Becado { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Escuela Escuela { get; set; }
        public virtual ICollection<FolioAnual> FolioAnuals { get; set; }
        public virtual Periodo Periodo { get; set; }
        public virtual Servicio Servicio { get; set; }
    }
}
