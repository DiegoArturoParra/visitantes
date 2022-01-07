using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitante.Model.DTOs
{
    public class RegistroVisitanteDTO
    {
        public long InstalacionId { get; set; }
        public long VisitanteId { get; set; }
        public string FechaIngreso { get; set; }
        public string Observaciones { get; set; }
    }
    public class ListRegistroVisitanteDTO
    {
        public long Id { get; set; }
        public VisitanteDTO visitante { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaSalida { get; set; }
        public InstalacionDTO instalacion { get; set; }
        public string observaciones { get; set; }
        public bool estadoRetirado { get; set; }

    }
}
