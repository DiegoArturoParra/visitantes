using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Visitante.Model;

namespace Visitante.Repositories
{
    public class RegistroVisitanteRepository
    {

        VisitanteEntities contexto = new VisitanteEntities();

        /// <summary>
        /// Retorna la información de un registro dado su Id
        /// </summary>
        /// <returns></returns>
        public RegistroVisitante Get(int idRegistro)
        {
            this.contexto.Configuration.LazyLoadingEnabled = true;
            var registroVisitante = contexto.RegistroVisitante.Where(x => x.Id == idRegistro).FirstOrDefault();
            return registroVisitante;
        }

        /// <summary>
        /// Busca el último registro de ingreso de un visitante
        /// </summary>
        /// <param name="idVisitante">Id del visitante</param>
        /// <returns></returns>
        public RegistroVisitante GetUltimoRegistroVisitante(int idVisitante)
        {
            this.contexto.Configuration.LazyLoadingEnabled = true;
            var registroVisitante =
                (from r in contexto.RegistroVisitante
                 where r.IdVisitante == idVisitante
                 select r).OrderByDescending(r => r.FechaIngreso).FirstOrDefault();
            return registroVisitante;
        }

        public void Registro(RegistroVisitante registro)
        {
            this.contexto.Entry(registro).State = EntityState.Added;
            saveChanges();
        }

        public void saveChanges()
        {
            this.contexto.SaveChanges();
        }
        public void Update(RegistroVisitante registro)
        {
            this.contexto.Entry(registro).State = EntityState.Modified;
            saveChanges();
        }

        public List<RegistroVisitante> GetAll()
        {
            return this.contexto.RegistroVisitante.ToList();
        }
    }
}
