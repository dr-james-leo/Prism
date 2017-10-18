using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Prism.Models;

namespace Prism.Controllers
{
    public class ConsultantsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Consultants
        public IQueryable<Consultant> GetConsultants()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            return db.Consultants;
        }

        // GET: api/Consultants/5
        [ResponseType(typeof(Consultant))]
        public async Task<IHttpActionResult> GetConsultant(int id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            return Ok(consultant);
        }

        // PUT: api/Consultants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConsultant(int id, Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consultant.ConsultantId)
            {
                return BadRequest();
            }

            db.Entry(consultant).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantExists(id))
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

        // POST: api/Consultants
        [ResponseType(typeof(Consultant))]
        public async Task<IHttpActionResult> PostConsultant(Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consultants.Add(consultant);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = consultant.ConsultantId }, consultant);
        }

        // DELETE: api/Consultants/5
        [ResponseType(typeof(Consultant))]
        public async Task<IHttpActionResult> DeleteConsultant(int id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            db.Consultants.Remove(consultant);
            await db.SaveChangesAsync();

            return Ok(consultant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultantExists(int id)
        {
            return db.Consultants.Count(e => e.ConsultantId == id) > 0;
        }
    }
}