using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pamela_4._0.Models
{
    public class PartialModels
    {

        public Becado becado { get; set; }
        public IEnumerable<Becado> becadoList { get; set; }
        public Tutor tutor { get; set; }
        public IEnumerable<Tutor> tutorsList { get; set; }
        public View_Becado_HistoricoPeriodosCategoriaBecadoTutorEscuelaSocial_Result todo { get; set; }
        public IEnumerable<Pamela_4._0.Models.View_Becado_HistoricoPeriodosCategoriaBecadoTutorEscuelaSocial_Result> todolist { get; set; }
        public View_Becado_HistoricoFolios_Result folio { get; set; }
        public IEnumerable<View_Becado_HistoricoFolios_Result> folioList { get; set; }
        public View__HistoricoFolios_Result historial {get; set;}
        public IEnumerable<View__HistoricoFolios_Result> historiaList{get; set;}
        public FolioAnual anual { get; set; }
        }
       
        }
