using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BrewzDomain.Classes;
using BrewzDomain.DataLayer;

namespace BrewzRestfullWebService.Controllers
{
    public class BrewersController : ApiController
    {
        private BrewzContext db = new BrewzContext();

        // GET: api/Brewers
        public IQueryable<Brewer> GetBrewers()
        {
            return db.brewers;
        }

        // GET: api/Brewers/5
        [ResponseType(typeof(Brewer))]
        public IHttpActionResult GetBrewer(int id)
        {
            Brewer brewer = db.Brewers.Find(id);
            if (brewer == null)
            {
                return NotFound();
            }

            return Ok(brewer);
        }

        // PUT: api/Brewers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBrewer(int id, Brewer brewer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brewer.BrewerId)
            {
                return BadRequest();
            }

            db.Entry(brewer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrewerExists(id))
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

        // POST: api/Brewers
        [ResponseType(typeof(Brewer))]
        public IHttpActionResult PostBrewer(Brewer brewer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brewers.Add(brewer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brewer.BrewerId }, brewer);
        }

        // DELETE: api/Brewers/5
        [ResponseType(typeof(Brewer))]
        public IHttpActionResult DeleteBrewer(int id)
        {
            Brewer brewer = db.Brewers.Find(id);
            if (brewer == null)
            {
                return NotFound();
            }

            db.Brewers.Remove(brewer);
            db.SaveChanges();

            return Ok(brewer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrewerExists(int id)
        {
            return db.Brewers.Count(e => e.BrewerId == id) > 0;
        }
    }
}
