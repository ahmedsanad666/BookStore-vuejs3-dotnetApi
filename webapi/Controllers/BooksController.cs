using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("bookstore/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var all = await _context.Books.Include(w => w.ApiUser).Include(q => q.Category).ToListAsync();
            foreach (var Book in all)
            {
                        string fileName = "images" + Book.Id + ".png";
                try
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                    Book.ImgByte = System.IO.File.ReadAllBytes(path);
                }
                catch(Exception ex)
                {
                    Book.ImgByte = null;

                }
             

              
            }
            return all;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var Book = await _context.Books.FindAsync(id);

            if (Book == null)
            {
                return NotFound();
            }
            string fileName = "images" + Book.Id + ".png";
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

            Book.ImgByte = System.IO.File.ReadAllBytes(path);


            return Book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Book Book)
        {
            if (id != Book.Id)
            {
                return BadRequest();
            }

            _context.Entry(Book).State = EntityState.Modified;

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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromForm] Book Book)
        {
            try
            {

                string message = "";
                var files =Book.Image;
                Book.Image = null;

                _context.Books.Add(Book);
                await _context.SaveChangesAsync();

                if (Book.Id > 0 && files != null && files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\images\\";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileName = "images" + Book.Id + ".png";
                    if (System.IO.File.Exists(path + fileName))
                    {
                        System.IO.File.Delete(path + fileName);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + fileName))
                    {
                        files.CopyTo(fileStream);
                        fileStream.Flush();
                        message = "Success";

                    }


                }
                else if (Book.Id == 0)
                {
                    message = "Failed";
                }

                else
                {
                    message = "Success";
                }

                if (message == "Success")
                {
                    var res = CreatedAtAction("GetBlog", new { id = Book.Id }, Book);
                    return res;

                }
                else
                {
                    //return StatusCode((int)HttpStatusCode.InternalServerError, message);
                    return BadRequest();
                }


            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            //_context.Books.Add(Book);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCourse", new { id = Book.Id }, Book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var Book = await _context.Books.FindAsync(id);
            if (Book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(Book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
