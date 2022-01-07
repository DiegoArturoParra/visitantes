using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Visitante.Model;
using Visitante.Model.DTOs;
using Visitante.Repositories;

namespace Visitante.Business
{
    public class RegistroVisitanteBO
    {
        private readonly RegistroVisitanteRepository _repo;
        public RegistroVisitanteBO()
        {
            _repo = new RegistroVisitanteRepository();
        }
        public string RegistrarVisitanteInstalacion(RegistroVisitanteDTO visitante)
        {
            string mensaje = string.Empty;
            try
            {
                DateTime fecha = DateTime.Parse(visitante.FechaIngreso);
                RegistroVisitante registro = new RegistroVisitante()
                {
                    IdInstalacion = visitante.InstalacionId,
                    IdVisitante = visitante.VisitanteId,
                    FechaIngreso = fecha.ToString("yyyy-MM-dd HH:mm:ss"),
                    Observaciones = visitante.Observaciones,
                    FechaSalida = "yyyy-MM-dd HH:mm:ss"
                };
                _repo.Registro(registro);
                mensaje = "registro satisfactorio";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                mensaje = "no se pudo registrar";
            }

            return mensaje;
        }
        public string RetiroVisitante(RetirarVisitanteDTO retiro)
        {
            string mensaje = string.Empty;
            try
            {
                var registro = _repo.Get(retiro.IdRegistro);
                registro.FechaSalida = retiro.FechaSalida;
                _repo.Update(registro);
                mensaje = "se ha retirado el visitante satisfactoriamente.";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                mensaje = "no se pudo registrar";
            }

            return mensaje;
        }

        public List<ListRegistroVisitanteDTO> GetRegistros()
        {
            var listado = _repo.GetAll();
            return retornarListadoDTO(listado);
        }

        public List<ListRegistroVisitanteDTO> GetRegistrosByNombreVisitante(string nombreVisitante)
        {
            var listado = _repo.GetAllByNombreVisitante(nombreVisitante);
            return retornarListadoDTO(listado);
        }

        public List<ListRegistroVisitanteDTO> retornarListadoDTO(List<RegistroVisitante> registros)
        {
            return registros.Select(x => new ListRegistroVisitanteDTO
            {

                estadoRetirado = x.FechaSalidaData == null ? false : true,
                fechaIngreso = DateTime.Parse(x.FechaIngreso),

                Id = x.Id,
                instalacion = new InstalacionDTO
                {
                    Nombre = x.Instalacion.Nombre
                },
                observaciones = x.Observaciones,
                visitante = new VisitanteDTO
                {
                    Identificacion = x.Visitante.Identificacion,
                    Nombres = x.Visitante.Nombres,
                    Apellidos = x.Visitante.Apellidos,
                    TipoIdentificacion = new TipoIdentificacionDTO
                    {
                        Nombre = x.Visitante.TipoIdentificacion1.Nombre,
                        Siglas = x.Visitante.TipoIdentificacion1.Siglas
                    }
                },
                fechaSalida = x.FechaSalida.Equals("yyyy-MM-dd HH:mm:ss") ?
               new DateTime() : DateTime.Parse(x.FechaSalida)
            }).ToList();
        }
    }
}
