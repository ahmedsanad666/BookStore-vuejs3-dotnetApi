using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("bookstore/[controller]")]
    [ApiController]
    public class KnowledgeHubsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KnowledgeHubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/knowledgeHubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnowledgeHub>>> GetCourses()
        {
            return await _context.knowledgeHubs.ToListAsync();
        }

        // GET: api/knowledgeHubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnowledgeHub>> GetCourse(int id)
        {
            var KnowledgeHub = await _context.knowledgeHubs.FindAsync(id);

            if (KnowledgeHub == null)
            {
                return NotFound();
            }

            return KnowledgeHub;
        }

        // PUT: api/knowledgeHubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, KnowledgeHub KnowledgeHub)
        {
            if (id != KnowledgeHub.Id)
            {
                return BadRequest();
            }

            _context.Entry(KnowledgeHub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/knowledgeHubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KnowledgeHub>> PostCourse(KnowledgeHub KnowledgeHub)
        {
            _context.knowledgeHubs.Add(KnowledgeHub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = KnowledgeHub.Id }, KnowledgeHub);
        }

        // DELETE: api/knowledgeHubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var KnowledgeHub = await _context.knowledgeHubs.FindAsync(id);
            if (KnowledgeHub == null)
            {
                return NotFound();
            }

            _context.knowledgeHubs.Remove(KnowledgeHub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.knowledgeHubs.Any(e => e.Id == id);
        }
    }
}
