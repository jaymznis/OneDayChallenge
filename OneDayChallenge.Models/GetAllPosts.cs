using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDayChallenge.Models
{
    public class GetAllPosts
    {
        public int PostId { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
