using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Media_Web_API.Data;
using Social_Media_Web_API.Dtos.PostDTO;
using Social_Media_Web_API.Models;
using Social_Media_Web_API.Repositories.Interfaces;

namespace Social_Media_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postRepository.GetAllWithUsersAsync();
            var postDtos = posts.Select(p => new PostReadDto
            {
                Id = p.Id,
                Content = p.Content,
                
                CreatedAt = p.CreatedAt,
                //UserId = p.UserId,
                UserName = p.User?.UserName
            });

            return Ok(postDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postRepository.GetByIdWithUserAsync(id);
            if (post == null)
                return NotFound();

            var postDto = new PostReadDto
            {
                Id = post.Id,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                //UserId = post.UserId
                UserName = post.User.UserName
            };

            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostCreateDto dto)
        {
            var post = new Post
            {
                Content = dto.Content,
                CreatedAt = DateTime.Now,
                UserId = dto.UserId
            };

            await _postRepository.AddAsync(post);
            return Ok("Post added successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostUpdateDto dto)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return NotFound();

            post.Content = dto.Content;
            await _postRepository.UpdateAsync(post);
            return Ok("Post updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return NotFound();

            await _postRepository.DeleteAsync(post);
            return NoContent();
        }
    }
}
