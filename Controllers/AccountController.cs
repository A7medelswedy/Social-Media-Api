using Microsoft.AspNetCore.Mvc;

using Social_Media_Web_API.Dtos.AccountDTO;
using Social_Media_Web_API.Models;
using Social_Media_Web_API.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace Social_Media_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup([FromBody] AccountCreateDto dto)
        {
            // Email validation
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(dto.Email))
                return BadRequest("Invalid email format");

            // Password validation
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,12}$");
            if (!passwordRegex.IsMatch(dto.Password))
                return BadRequest("Password must be 6-12 chars, contain uppercase, lowercase, and a number");

            if (dto.Password != dto.ConfirmPassword)
                return BadRequest("Passwords do not match");

            var existingAccount = await _accountRepository.GetByEmailAsync(dto.Email);
            if (existingAccount != null)
                return BadRequest("Email already exists");

            var account = new Account
            {
                Email = dto.Email,
                Password = dto.Password
            };

            await _accountRepository.AddAsync(account);
            return Ok(new { Message = "Account created successfully", AccountId = account.Id });
        }


        // Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AccountLoginDto dto)
        {
            var account = await _accountRepository.GetByEmailAsync(dto.Email);
            if (account == null || account.Password != dto.Password)
                return Unauthorized("Invalid email or password");

            return Ok(new { Message = "Login successful", AccountId = account.Id });
        }
    }
}
