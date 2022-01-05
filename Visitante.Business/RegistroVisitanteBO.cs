using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                RegistroVisitante registro = new RegistroVisitante()
                {
                    IdInstalacion = visitante.InstalacionId,
                    IdVisitante = visitante.VisitanteId,
                    FechaIngreso = DateTime.ParseExact(visitante.FechaIngreso.ToString(), "yyyy-MM-dd HH:mm:ss", null)
                  .ToString("dd-MM-yyyy HH:mm:ss"),
                    Observaciones = visitante.Observaciones
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

        public List<RegistroVisitante> GetRegistros()
        {
            return _repo.GetAll();
        }
    }
}
