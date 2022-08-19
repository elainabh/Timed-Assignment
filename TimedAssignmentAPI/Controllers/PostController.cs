using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedAssignmentAPI.Models;
using Microsoft.EntityFrameworkCore;
using TimedAssignmentAPI.Controllers;

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
            _context.Post.Add(new Post()
            {
                Title = model.Title,
                Text = model.Text,
                Username = model.Username,
            });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedia()
        {     
            var posts = await _context.Post.ToListAsync();

            List<PostListItem> postListItems = new List<PostListItem>(); 

            foreach(Post postEntity in posts)
            {
                postListItems.Add(
                    new PostListItem(){
                        Id = postEntity.Id,
                        Title = postEntity.Title,
                        Text = postEntity.Text,
                        Username = postEntity.Username
                    }
                );
            }

            foreach(PostListItem post in postListItems)
           { 
            post.Comments = GetAllCommentsByPostId(post.Id);
           }
            return Ok(posts);
            
        }


        public List<CommentDetail> GetAllCommentsByPostId (int PostId)
        {
            var postComments = _context.CommentsDetail.ToList();

            List<CommentDetail> commentDetails = new List<CommentDetail>();

            foreach(Comments comment in postComments)
            {
                if(PostId == comment.PostId)
                {
                commentDetails.Add(
                    new CommentDetail(){
                        Text = comment.Text,
                        Username = comment.Username
                    }
                );
                }
            }
            return commentDetails;
        }
    }
}