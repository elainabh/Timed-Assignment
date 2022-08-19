using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignmentAPI.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
        // public virtual List<CommentDetail> Comments { get; set; } = new List<Comments>();
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
    }
}