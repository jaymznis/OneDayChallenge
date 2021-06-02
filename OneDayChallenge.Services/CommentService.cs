using OneDayChallenge.Data;
using OneDayChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDayChallenge.Services
{
    public class CommentService
    {
        private readonly Guid _authorId;

        public CommentService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateComment(CommentCreate model)
        {

            var ent = new Comment()
            {
                PostId = model.PostId,
                AuthorId = _authorId,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(ent);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GetComments> GetCommentsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Comments
                    .Where(e => e.PostId == id && e.AuthorId == _authorId)
                    .Select
                    (
                            e => new GetComments
                            {
                                CommentId = e.Id,
                                AuthorId = e.AuthorId,
                                Text = e.Text
                            }
                    );

                return query.ToArray();
            }
        }
    }
}
