using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimedAssignmentAPI.Models;

namespace TimedAssignmentAPI
{
    public class PostDbContext : DbContext
    {
         public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) { }
         public DbSet<Post> Post { get; set; }
         public DbSet<Comments> CommentsDetail { get; }
    }
}