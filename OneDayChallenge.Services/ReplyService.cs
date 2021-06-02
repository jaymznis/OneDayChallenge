using OneDayChallenge.Data;
using OneDayChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDayChallenge.Services
{
    public class ReplyService
    {
        private readonly Guid _authorId;

        public ReplyService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateReply(ReplyCreate model)
        {

            var ent = new Reply()
            {
                CommentId = model.CommentId,
                AuthorId = _authorId,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(ent);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GetReply> GetRepliesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Replies
                    .Where(e => e.CommentId == id && e.AuthorId == _authorId)
                    .Select
                    (
                            e => new GetReply
                            {
                                ReplyId = e.Id,
                                AuthorId = e.AuthorId,
                                Text = e.Text
                            }
                    );

                return query.ToArray();
            }
        }
    }
}
