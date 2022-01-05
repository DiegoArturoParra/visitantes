using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Model;

namespace Visitante.Repositories
{
    public class TipoIdentificacionRepository
    {

        VisitanteEntities contexto = new VisitanteEntities();

        /// <summary>
        /// Retorna el listado de tipos de identificación
        /// </summary>
        /// <returns></returns>
        public List<TipoIdentificacion> Get()
        {
            this.contexto.Configuration.LazyLoadingEnabled = false;
            var lista = (from t in contexto.TipoIdentificacion
                         select t
                         ).OrderBy(x => x.Nombre).ToList();
            return lista;
        }

    }
}
