//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Visitante.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegistroVisitante
    {
        public long Id { get; set; }
        public long IdInstalacion { get; set; }
        public long IdVisitante { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaSalida { get; set; }
        public string Observaciones { get; set; }
        public virtual Instalacion Instalacion { get; set; }
        public virtual Visitante Visitante { get; set; }
    }
}
