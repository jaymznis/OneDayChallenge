using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDayChallenge.Models
{
    public class GetComments
    {
        public int CommentId { get; set; }
        public Guid AuthorId { get; set; }
        public string Text { get; set; }
    }
}
