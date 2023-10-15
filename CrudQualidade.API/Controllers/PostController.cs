using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CrudQualidade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public ActionResult<IEnumerable <Post>> GetAllPosts()
        {
            return Ok(_postService.GetAllPosts());
        }

        [HttpGet("{id}")]

        public ActionResult<Post> GetPostById(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)  return BadRequest("Post não foi encontrado!");

            return Ok(post);
        }

        [HttpPost]
        public IActionResult PostElement(Post post)
        {
            if (post == null) return BadRequest("Dados inválidos!");
        
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
        
            _postService.InsertPost(post);

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult PutPost(int id, [FromBody] Post post)
        {
            if (post.Id != id) return BadRequest("Id na requisição é diferente do id da url!");
            var existsPost = _postService.GetPostById(id);
            
            if (existsPost == null) return BadRequest("Post não existe!");

            try
            {
                _postService.UpdatePost(post);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult DeletePost(int id)
        {
            var existsPost = _postService.GetPostById(id);
            if (existsPost == null) return BadRequest("Post não encontrado!");

            try
            {
                _postService.DeletePost(existsPost);
                return Ok("Post removido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
