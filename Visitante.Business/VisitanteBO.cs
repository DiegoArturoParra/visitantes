using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Model;
using Visitante.Model.DTOs;
using Visitante.Repositories;

namespace Visitante.Business
{
    public class VisitanteBO
    {
        /// <summary>
        /// Retorna la información de un visitante dado su Id
        /// </summary>
        /// <returns></returns>
        public Visitante.Model.Visitante Get(int idVisitante)
        {
            return (new VisitanteRepository()).Get(idVisitante);
        }

        /// <summary>
        /// Retorna la información de un visitante dado su número de identificación
        /// </summary>
        /// <returns></returns>
        public Visitante.Model.Visitante GetByIdentificacion(string identificacion)
        {
            return (new VisitanteRepository()).GetByIdentificacion(identificacion);
        }

        /// <summary>
        /// Crea un visitante
        /// </summary>
        /// <param name="visitanteNuevo">Datos del visitante</param>
        /// <returns>Id suceso</returns>
        public long CrearVisitante(VisitanteDTO visitanteNuevo)
        {
            try
            {
                var fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Visitante.Model.Visitante registro = new Model.Visitante()
                {
                    Apellidos = visitanteNuevo.Apellidos,
                    FechaCreacion = fechaActual,
                    Identificacion = visitanteNuevo.Identificacion,
                    Nombres = visitanteNuevo.Nombres,
                    TipoIdentificacion = visitanteNuevo.TipoIdentificacionId
                };
                var visitante = (new VisitanteRepository()).GetByIdentificacion(visitanteNuevo.Identificacion);

                if (visitante != null)
                {
                    throw new Exception("El visitante ya se encuentra registrado en el sistema.");
                }
                var resultado = (new VisitanteRepository()).CrearVisitante(registro);

                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Edtar un visitante
        /// </summary>
        /// <param name="datosVisitante">Datos del visitante a actualizar</param>
        /// <returns></returns>
        public bool EditarVisitante(Visitante.Model.Visitante datosVisitante)
        {
            try
            {
                var visitante = (new VisitanteRepository()).Get(datosVisitante.Id);

                if (visitante == null)
                {
                    return false;
                }

                var resultado = (new VisitanteRepository()).EditarVisitante(datosVisitante);

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Retorna la lista de visitantes
        /// </summary>
        /// <returns></returns>
        public List<ListVisitanteDTO> GetVisitantes()
        {
            return (new VisitanteRepository()).GetVisitantes();
        }

    }
}
