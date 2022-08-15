using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedAssignmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TimedAssignmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        private PostDbContext _context;
        public CommentsController(PostDbContext context) {
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> PostComments ([FromForm] CommentsEdit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Comments.Add(new Comments()
            {
                Text = model.Text,
                Username = model.Username
            });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var postComments = await _context.Comments.ToListAsync();
            return Ok(postComments);
        }
    }
}