using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedAssignmentAPI.Models;

namespace TimedAssignmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private PostDbContext _context;
        public PostController(PostDbContext context)
        {
            _context = context;
        }

            [HttpPost]
            public async Task<IActionResult> PostMedia([FromForm] PostEdit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Posts.Add(new Post()
            {
                Title = model.Title,
                Text = model.Text,
            });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetMedia()
        {
            var post = await _context.Post.ToListAsync();
            return Ok(post);
        }
    }
}