using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visitante.Model
{
    public partial class Visitante
    {
        [NotMapped]
        public DateTime? FechaCreacionData
        {
            get
            {
                if (string.IsNullOrEmpty(this.FechaCreacion))
                { return null; }
                else
                {
                    DateTime fecha;
                    if (DateTime.TryParse(this.FechaCreacion, out fecha))
                    {
                        return fecha;
                    }
                    else { return null; }
                }
            }
        }

    }
}
