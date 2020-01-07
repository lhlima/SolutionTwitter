using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prova.Itau.WebAPI.Models;

namespace Prova.Itau.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwittersController : ControllerBase
    {
        private TwitterItauContext _context = new TwitterItauContext();
        //private readonly TwitterItauContext _context;

        //public TwittersController(TwitterItauContext context)
        //{
        //    _context = context;
        //}

        private readonly ILogger<TwittersController> _logger;
        public TwittersController(ILogger<TwittersController> logger)
        {
            _logger = logger;
        }

        // GET: api/Twitters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Twitters>>> GetTwitters()
        {
            return await _context.Twitters.ToListAsync();
        }

        // GET: api/Twitters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Twitters>> GetTwitters(int id)
        {
            var twitters = await _context.Twitters.FindAsync(id);

            if (twitters == null)
            {
                return NotFound();
            }

            return twitters;
        }

        // PUT: api/Twitters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTwitters(int id, Twitters twitters)
        {
            if (id != twitters.Id)
            {
                return BadRequest();
            }

            _context.Entry(twitters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TwittersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Twitters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Twitters>> PostTwitters(Twitters twitters)
        {
            _context.Twitters.Add(twitters);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTwitters", new { id = twitters.Id }, twitters);
        }

        // DELETE: api/Twitters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Twitters>> DeleteTwitters(int id)
        {
            var twitters = await _context.Twitters.FindAsync(id);
            if (twitters == null)
            {
                return NotFound();
            }

            _context.Twitters.Remove(twitters);
            await _context.SaveChangesAsync();

            return twitters;
        }

        private bool TwittersExists(int id)
        {
            return _context.Twitters.Any(e => e.Id == id);
        }
    }
}
