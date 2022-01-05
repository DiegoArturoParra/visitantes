using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Model;

namespace Visitante.Repositories
{
    public class InstalacionRepository
    {

        VisitanteEntities contexto = new VisitanteEntities();

        /// <summary>
        /// Retorna el listado de tipos de identificación
        /// </summary>
        /// <returns></returns>
        public List<Instalacion> Get()
        {
            this.contexto.Configuration.LazyLoadingEnabled = false;
            var lista = (from t in contexto.Instalacion
                         select t
                         ).OrderBy(x => x.Nombre).ToList();
            return lista;
        }

    }
}
