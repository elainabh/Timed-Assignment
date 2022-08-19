using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimedAssignmentAPI.Models
{
    public class Comments
    {
        [Key]
        int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

    }
}