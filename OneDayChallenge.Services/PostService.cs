using OneDayChallenge.Data;
using OneDayChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDayChallenge.Services
{
    public class PostService
    {
        private readonly Guid _authorId;

        public PostService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                AuthorId = _authorId,
                Title = model.Title,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GetAllPosts> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Posts
                    .Where(e => e.AuthorId == _authorId)
                    .Select
                    (
                            e => new GetAllPosts
                            {
                                PostId = e.Id,
                                AuthorId = e.AuthorId,
                                Title = e.Title,
                                Text = e.Text
                            }
                    );
                return query.ToArray();
            }
        }

    }
}
