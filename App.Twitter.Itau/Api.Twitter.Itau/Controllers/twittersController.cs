using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Api.Twitter.Itau.Models;

namespace Api.Twitter.Itau.Controllers
{
    public class twittersController : ApiController
    {
        private contexto db = new contexto();

        // GET: api/twitters
        public IQueryable<twitter> GetTwitters()
        {
            return db.Twitters;
        }

        // GET: api/twitters/5
        [ResponseType(typeof(twitter))]
        public IHttpActionResult Gettwitter(int id)
        {
            twitter twitter = db.Twitters.Find(id);
            if (twitter == null)
            {
                return NotFound();
            }

            return Ok(twitter);
        }

        // PUT: api/twitters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttwitter(int id, twitter twitter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != twitter.Id)
            {
                return BadRequest();
            }

            db.Entry(twitter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!twitterExists(id))
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

        // POST: api/twitters
        [ResponseType(typeof(twitter))]
        public IHttpActionResult Posttwitter(twitter twitter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Twitters.Add(twitter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = twitter.Id }, twitter);
        }

        // DELETE: api/twitters/5
        [ResponseType(typeof(twitter))]
        public IHttpActionResult Deletetwitter(int id)
        {
            twitter twitter = db.Twitters.Find(id);
            if (twitter == null)
            {
                return NotFound();
            }

            db.Twitters.Remove(twitter);
            db.SaveChanges();

            return Ok(twitter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool twitterExists(int id)
        {
            return db.Twitters.Count(e => e.Id == id) > 0;
        }
    }
}