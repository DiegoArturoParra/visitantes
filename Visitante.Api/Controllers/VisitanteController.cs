using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Visitante.Business;
using Visitante.Model.DTOs;

namespace Visitante.Api.Controllers
{
    /// <summary>
    /// Visitantes
    /// </summary>
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/visitantes")]
    public class VisitanteController : ApiController
    {
        /// <summary>
        /// Obtiene el listado de visitantes
        /// </summary>
        /// <returns>Lista</returns>
        [HttpGet]
        [Route("list")]
        [AllowAnonymous]
        public IHttpActionResult GetVisitantes()
        {
            try
            {
                var lista = new VisitanteBO().GetVisitantes();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                var error = $"Error al manejar la solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }
        [HttpGet]
        [Route("listado-registros")]
        [AllowAnonymous]
        public IHttpActionResult GetRegistros()
        {
            try
            {
                var lista = new RegistroVisitanteBO().GetRegistros();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                var error = $"Error al manejar la solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }
        [HttpGet]
        [Route("listado-by-nombre")]
        [AllowAnonymous]
        public IHttpActionResult GetRegistrosByNombreVisitante(string nombreVisitante)
        {
            try
            {
                if (string.IsNullOrEmpty(nombreVisitante))
                {
                    return GetRegistros();
                }
                var lista = new RegistroVisitanteBO().GetRegistrosByNombreVisitante(nombreVisitante);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                var error = $"Error al manejar la solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }

        [HttpPost]
        [Route("crear")]
        [AllowAnonymous]
        public IHttpActionResult registrar(VisitanteDTO visitante)
        {
            try
            {
                var mensaje = new VisitanteBO().CrearVisitante(visitante);

                return Ok("registrado");
            }
            catch (Exception ex)
            {
                var error = $"Error al manejar la solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }
        [HttpPut]
        [Route("retirar-visitante-de-instalacion")]
        [AllowAnonymous]
        public IHttpActionResult retirarVisitante(RetirarVisitanteDTO visitante)
        {
            try
            {
                var mensaje = new RegistroVisitanteBO().RetiroVisitante(visitante);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                var error = $"Error al manejar la solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }

        [HttpPost]
        [Route("registro-visitante-instalacion")]
        [AllowAnonymous]
        public IHttpActionResult registroInstalacion(RegistroVisitanteDTO visitante)
        {
            try
            {
                var mensaje = new RegistroVisitanteBO().RegistrarVisitanteInstalacion(visitante);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                var error = $"Error al manejar la solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }
    }
}
