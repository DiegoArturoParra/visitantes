using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visitante.Model
{
    public partial class RegistroVisitante
    {
        [NotMapped]
        public DateTime? FechaIngresoData
        {
            get
            {
                if (string.IsNullOrEmpty(this.FechaIngreso))
                { return null; }
                else
                {
                    DateTime fecha;
                    if (DateTime.TryParse(this.FechaIngreso, out fecha))
                    {
                        return fecha;
                    }
                    else { return null; }
                }
            }
        }


        [NotMapped]
        public DateTime? FechaSalidaData
        {
            get
            {
                if (string.IsNullOrEmpty(this.FechaSalida))
                { return null; }
                else
                {
                    DateTime fecha;
                    if (DateTime.TryParse(this.FechaSalida, out fecha))
                    {
                        return fecha;
                    }
                    else { return null; }
                }
            }
        }

    }
}
