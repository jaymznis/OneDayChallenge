using Microsoft.AspNet.Identity;
using OneDayChallenge.Models;
using OneDayChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OneDayChallenge.Web.API.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(authorId);
            return commentService;
        }

        public IHttpActionResult Get(int id)
        {
            
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentsById(id);
            return Ok(comments);
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
    }
}
