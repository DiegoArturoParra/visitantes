using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Visitante.Business;
using Visitante.Model;

namespace Visitante.Api.Controllers
{
    /// <summary>
    /// Instalaciones
    /// </summary>
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/instalaciones")]
    public class InstalacionController : ApiController
    {
        /// <summary>
        /// Obtiene el listado de instalaciones
        /// </summary>
        /// <returns>Lista</returns>
        [HttpGet]
        [Route("list")]
        [AllowAnonymous]
        public IHttpActionResult GetInstalaciones()
        {
            try
            {
                var lista = new InstalacionBO().Get();
                if (lista == null) {
                    lista = new List<Instalacion>();
                }
                var resultado = (from r in lista
                                 select new
                                 {
                                     r.Id,
                                     r.Nombre
                                 }).ToList();

                return Ok(resultado);
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
