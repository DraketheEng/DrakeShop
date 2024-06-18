using DrakeShop.Comment.Context;
using DrakeShop.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrakeShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult GetCommentList() 
        { 
            var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var values = _commentContext.UserComments.Find(id);
            return Ok(values);
        }

        [HttpGet]
        public IActionResult GetCommentListByProductId(string id)
        {
            var values = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment) 
        {
            _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Eklendi.");
        }


        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Güncellendi.");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id) 
        {
            var value = _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Silindi.");
        }
    }
}
