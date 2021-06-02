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

        public bool CreateComment(CommentCreate model, Comment post) //can't create unless there is a post?
        {
            var initialPost = post.PostId;

            var entity = new Comment()
            {
                PostId = initialPost,
                AuthorId = _authorId,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GetComments> GetCommentsById()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Comments
                    .Where(e => e.AuthorId == _authorId)
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
