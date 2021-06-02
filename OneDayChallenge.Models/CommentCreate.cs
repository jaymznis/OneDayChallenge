using OneDayChallenge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDayChallenge.Models
{
    public class CommentCreate
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
