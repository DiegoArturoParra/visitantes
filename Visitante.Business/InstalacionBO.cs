using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Model;
using Visitante.Repositories;

namespace Visitante.Business
{
    public class InstalacionBO
    {
        /// <summary>
        /// Retorna el listado de instalaciones
        /// </summary>
        /// <returns></returns>
        public List<Instalacion> Get()
        {
            try
            {
                return new InstalacionRepository().Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
