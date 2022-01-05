using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Visitante.Model.DTOs
{
    public class RetirarVisitanteDTO
    {
        public int IdRegistro { get; set; }
        public string FechaSalida => DateTime.Now.ToString();
    }
}