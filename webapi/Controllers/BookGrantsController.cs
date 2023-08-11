using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookGrantsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public BookGrantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookGrant>>> GetBooksG()
        {
            var all = await _context.BookGrants.Include(w => w.ApiUser).ToListAsync();
            
            return all;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookGrant>> GetBookG(int id)
        {
            var grant = await _context.BookGrants.FindAsync(id);

            if (grant == null)
            {
                return NotFound();
            }
        

       


            return grant;
        }

        [HttpPost]
        public async Task<ActionResult<BookGrant>> PostBook([FromBody] BookGrant Grant)
        {

            _context.BookGrants.Add(Grant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = Grant.Id }, Grant);
        }

    }
}
