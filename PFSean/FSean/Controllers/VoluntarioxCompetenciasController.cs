using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FSean.Models;

namespace FSean.Controllers
{
    public class VoluntarioxCompetenciasController : ApiController
    {
        private FSeanDB db = new FSeanDB();

        // GET: api/VoluntarioxCompetencias
        public IQueryable<VoluntarioxCompetencia> GetVoluntarioxCompetencia()
        {
            return db.VoluntarioxCompetencia;
        }

        // GET: api/VoluntarioxCompetencias/5
        [ResponseType(typeof(VoluntarioxCompetencia))]
        public IHttpActionResult GetVoluntarioxCompetencia(int id)
        {
            VoluntarioxCompetencia voluntarioxCompetencia = db.VoluntarioxCompetencia.Find(id);
            if (voluntarioxCompetencia == null)
            {
                return NotFound();
            }

            return Ok(voluntarioxCompetencia);
        }

        // PUT: api/VoluntarioxCompetencias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoluntarioxCompetencia(int id, VoluntarioxCompetencia voluntarioxCompetencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voluntarioxCompetencia.iId)
            {
                return BadRequest();
            }

            db.Entry(voluntarioxCompetencia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoluntarioxCompetenciaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VoluntarioxCompetencias
        [ResponseType(typeof(VoluntarioxCompetencia))]
        public IHttpActionResult PostVoluntarioxCompetencia(VoluntarioxCompetencia voluntarioxCompetencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VoluntarioxCompetencia.Add(voluntarioxCompetencia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voluntarioxCompetencia.iId }, voluntarioxCompetencia);
        }

        // DELETE: api/VoluntarioxCompetencias/5
        [ResponseType(typeof(VoluntarioxCompetencia))]
        public IHttpActionResult DeleteVoluntarioxCompetencia(int id)
        {
            VoluntarioxCompetencia voluntarioxCompetencia = db.VoluntarioxCompetencia.Find(id);
            if (voluntarioxCompetencia == null)
            {
                return NotFound();
            }

            db.VoluntarioxCompetencia.Remove(voluntarioxCompetencia);
            db.SaveChanges();

            return Ok(voluntarioxCompetencia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoluntarioxCompetenciaExists(int id)
        {
            return db.VoluntarioxCompetencia.Count(e => e.iId == id) > 0;
        }
    }
}