using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDayChallenge.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; } //not in data table
        public int PostId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        public virtual List<Reply> Replies { get; set; } //not in data table


    }
}
