using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Model;

namespace Visitante.Repositories
{
    public class VisitanteRepository
    {

        VisitanteEntities contexto = new VisitanteEntities();

        /// <summary>
        /// Retorna la información de un visitante dado su Id
        /// </summary>
        /// <returns></returns>
        public Visitante.Model.Visitante Get(long idVisitante)
        {
            this.contexto.Configuration.LazyLoadingEnabled = true;
            /*var visitante = (from v in contexto.Visitante
                             where v.Id == idVisitante
                             select v
                         ).FirstOrDefault();*/
            var visitante = contexto.Visitante.Where(x => x.Id == idVisitante).FirstOrDefault();
            return visitante;
        }

        /// <summary>
        /// Retorna la información de un visitante dado su número de identificación
        /// </summary>
        /// <returns></returns>
        public Visitante.Model.Visitante GetByIdentificacion(string identificacion)
        {
            this.contexto.Configuration.LazyLoadingEnabled = true;
            var visitante = contexto.Visitante.Where(x => x.Identificacion == identificacion).FirstOrDefault();
            return visitante;
        }

        /// <summary>
        /// Crea un visitante
        /// </summary>
        /// <param name="visitanteNuevo">Datos del visitante</param>
        /// <returns>Id suceso</returns>
        public long CrearVisitante(Visitante.Model.Visitante visitanteNuevo)
        {
            // NOTA: la fecha de creación debe estar guardada en formato ISO 8601  YYYY-MM-DD HH:MM:SS
            try
            {
                this.contexto.Visitante.Add(visitanteNuevo);
                this.contexto.SaveChanges();

                return visitanteNuevo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Editar visitante
        /// </summary>
        /// <param name="visitante">Datos del visitante</param>
        /// <returns>Id suceso</returns>
        public bool EditarVisitante(Visitante.Model.Visitante visitante)
        {
            try
            {
                var visitanteActual = (contexto.Visitante.Where(v => v.Id == visitante.Id)).FirstOrDefault();
                if (visitanteActual == null) {
                    throw new Exception("El visitante no se encuentra en el sistema.");
                } else { 
                    visitanteActual.TipoIdentificacion = visitante.TipoIdentificacion;
                    visitanteActual.Identificacion = visitante.Identificacion;
                    visitanteActual.Nombres = visitante.Nombres;
                    visitanteActual.Apellidos = visitante.Apellidos;

                    this.contexto.Entry(visitanteActual).State = EntityState.Modified;
                    this.contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna la lista de visitantes ordenada descendente por fecha de creación
        /// </summary>
        /// <returns></returns>
        public List<Visitante.Model.Visitante> GetVisitantes()
        {
            this.contexto.Configuration.LazyLoadingEnabled = true;
            var visitantes = contexto.Visitante.OrderByDescending(x => x.FechaCreacion).ToList();
            // var visitantes = contexto.Visitante.ToList();
            // visitantes = visitantes.OrderByDescending(x => x.FechaCreacionData).ToList();
            return visitantes;
        }


    }
}
