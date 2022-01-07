using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Visitante.Model;

namespace Visitante.Repositories
{
    public class InstalacionRepository
    {
        ConnectionStringSettings c = ConfigurationManager.ConnectionStrings["VisitanteEntities"];
        VisitanteEntities contexto;
        public InstalacionRepository()
        {
            string fixedConnectionString = c.ConnectionString.Replace("{appDomain}", AppDomain.CurrentDomain.BaseDirectory);
            contexto = new VisitanteEntities(fixedConnectionString);
        }
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
