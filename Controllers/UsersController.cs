using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social_Media_Web_API.Data;
using Social_Media_Web_API.Dtos.UserDto;
using Social_Media_Web_API.Models;
using Social_Media_Web_API.Repositories;
using Social_Media_Web_API.Repositories.Interfaces;

namespace Social_Media_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public UserController(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        //  GET ALL USERS
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();

            var userDtos = users.Select(u => new
            {
                id = u.Id,
                userName = u.UserName,
                email = u.Email,
                bio = u.Bio,
                icon = u.Icon
            }).ToList();

        
            var response = new
            {
                results = userDtos
            };

            return Ok(response);
        }

        //  GET USER BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserWithPostsAsync(id);
            if (user == null)
                return NotFound();

            var userDto = new
            {
                id = user.Id,
                userName = user.UserName,
                email = user.Email,
                bio = user.Bio,
                icon = user.Icon
            };

            var response = new
            {
                results = new[] { userDto }
            };

            return Ok(response);
        }

        //  ADD USER
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserCreateDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(dto.AccountId);
            if (account == null)
                return NotFound("Account not found");

            var existingUser = await _userRepository.GetByAccountIdAsync(dto.AccountId);
            if (existingUser != null)
                return BadRequest("This account already has a profile");

            var user = new User
            {
                UserName = dto.UserName,
                Bio = dto.Bio,
                Icon = string.IsNullOrEmpty(dto.Icon) ? "🤨" : dto.Icon,
                AccountId = dto.AccountId
            };

            await _userRepository.AddAsync(user);

            var response = new
            {
                results = new[]
                {
                    new
                    {
                        message = "User profile created successfully",
                        userId = user.Id,
                        userName = user.UserName,
                        bio = user.Bio,
                        icon = user.Icon
                    }
                }
            };

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, response);
        }

        //  UPDATE USER
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

            var response = new
            {
                results = new[]
                {
                    new { message = "User updated successfully" }
                }
            };

            return Ok(response);
        }

        //  DELETE USER
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            await _userRepository.DeleteAsync(user);

            var response = new
            {
                results = new[]
                {
                    new { message = "User deleted successfully" }
                }
            };

            return Ok(response);
        }
    }
}
