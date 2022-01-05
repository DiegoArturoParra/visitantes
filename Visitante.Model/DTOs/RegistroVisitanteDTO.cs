using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitante.Model.DTOs
{
    public class RegistroVisitanteDTO
    {
        public int InstalacionId { get; set; }
        public int VisitanteId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Observaciones { get; set; }
    }
}
