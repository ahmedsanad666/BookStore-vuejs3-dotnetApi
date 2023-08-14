using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("bookstore/[controller]")]
    [ApiController]
    public class UserQuestionsAnswersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserQuestionsAnswersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<UserQuestionsAnswer>> QData(UserQuestionsAnswer ans)
        {
            _context.UserQuestionsAnswers.Add(ans);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(QData), new { id = ans.Id }, ans);
        }
    }
}
