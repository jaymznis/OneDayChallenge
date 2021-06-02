using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDayChallenge.Data
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CommentId))]
        public virtual Comment Comment { get; set; }
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
    }
}
