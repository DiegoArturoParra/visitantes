using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Visitante.Model;

namespace Visitante.Repositories
{
    public class TipoIdentificacionRepository
    {
        ConnectionStringSettings c = ConfigurationManager.ConnectionStrings["VisitanteEntities"];
        VisitanteEntities contexto;


        public TipoIdentificacionRepository()
        {
            string fixedConnectionString = c.ConnectionString.Replace("{appDomain}", AppDomain.CurrentDomain.BaseDirectory);

            contexto = new VisitanteEntities(fixedConnectionString);
        }


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
