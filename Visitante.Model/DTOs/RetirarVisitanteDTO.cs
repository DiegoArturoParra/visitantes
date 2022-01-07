using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Visitante.Model.DTOs
{
    public class RetirarVisitanteDTO
    {
        public long IdRegistro { get; set; }
        public string FechaSalida => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}