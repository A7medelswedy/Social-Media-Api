using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social_Media_Web_API.Data;
using Social_Media_Web_API.Dtos.UserDto;
using Social_Media_Web_API.Models;
using Social_Media_Web_API.Repositories.Interfaces;

namespace Social_Media_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = users.Select(u => new UserReadDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Bio = u.Bio,
                Icon = u.Icon 
            });

            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserWithPostsAsync(id);
            if (user == null)
                return NotFound();

            var userDto = new UserReadDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Bio = user.Bio,
                Icon = user.Icon
            };

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserCreateDto dto)
        {
            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Bio = dto.Bio,
                Icon =  string.IsNullOrEmpty(dto.Icon) ? "🤨" : dto.Icon
            };

            await _userRepository.AddAsync(user);
            return Ok("User created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            user.UserName = dto.UserName;
            user.Bio = dto.Bio;
            user.Icon = dto.Icon;

            await _userRepository.UpdateAsync(user);
            return Ok("User updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            await _userRepository.DeleteAsync(user);
            return NoContent();
        }
    }
}
