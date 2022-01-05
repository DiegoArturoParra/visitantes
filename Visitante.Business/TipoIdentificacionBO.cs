using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Model;
using Visitante.Repositories;

namespace Visitante.Business
{
    public class TipoIdentificacionBO
    {
        /// <summary>
        /// Retorna el listado de tipos de identificación
        /// </summary>
        /// <returns></returns>
        public List<TipoIdentificacion> Get()
        {
            try
            {
                return new TipoIdentificacionRepository().Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
