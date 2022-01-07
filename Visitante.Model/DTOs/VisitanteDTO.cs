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
        public TipoIdentificacionDTO TipoIdentificacion { get; set; }
    }

    public class InstalacionDTO
    {
        public string Nombre { get; set; }
    }
    public class ListVisitanteDTO
    {
        public long Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public TipoIdentificacionDTO TipoIdentificacion { get; set; }
    }
    public class TipoIdentificacionDTO
    {
        public string Siglas { get; set; }
        public string Nombre { get; set; }
    }
}
