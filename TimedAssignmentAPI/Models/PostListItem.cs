using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignmentAPI.Models
{
    public class PostListItem
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
        public List<CommentDetail> Comments { get; set; } = new List<CommentDetail>();
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
    }
}