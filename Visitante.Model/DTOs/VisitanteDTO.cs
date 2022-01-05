using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitante.Model.DTOs
{
    public class VisitanteDTO
    {
        public long TipoIdentificacionId { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaCreacion => DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd HH:mm:ss", null)
                    .ToString("dd-MM-yyyy HH:mm:ss");
    }
}
