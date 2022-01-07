using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using Visitante.Model;

namespace Visitante.Repositories
{
    public class RegistroVisitanteRepository
    {
        ConnectionStringSettings c = ConfigurationManager.ConnectionStrings["VisitanteEntities"];
        VisitanteEntities contexto;


        public RegistroVisitanteRepository()
        {
            string fixedConnectionString = c.ConnectionString.Replace("{appDomain}", AppDomain.CurrentDomain.BaseDirectory);
            contexto = new VisitanteEntities(fixedConnectionString);
        }
        public RegistroVisitante Get(long idRegistro)
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
        public static TException GetInnerException<TException>(Exception exception)
         where TException : Exception
        {
            Exception innerException = exception;
            while (innerException != null)
            {
                if (innerException is TException result)
                {
                    return result;
                }
                innerException = innerException.InnerException;

            }
            return null;
        }
        public void saveChanges()
        {
            try
            {
                this.contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                var SQLiteException = GetInnerException<SqliteException>(ex);
                if (SQLiteException != null)
                {
                    Debug.WriteLine($"Error: {SQLiteException.Message}");
                }
                else
                {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            }
      
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

        public List<RegistroVisitante> GetAllByNombreVisitante(string nombreVisitante)
        {
            var query = this.contexto.RegistroVisitante.Where(x=> x.Visitante.Nombres
            .ToUpper().Contains(nombreVisitante.ToUpper())).ToList();
            return query;
        }
    }
}
