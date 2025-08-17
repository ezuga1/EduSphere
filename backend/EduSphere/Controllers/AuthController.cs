using EduSphere.Data;
using EduSphere.DTOs;
using EduSphere.Models;
using EduSphere.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduSphere.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher = new();
        private readonly IEmailService _emailService;
        public AuthController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest("Email already in use.");
            }

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Role = dto.Role

            };
            user.Password = _passwordHasher.HashPassword(user, dto.Password);

            var code = new Random().Next(100000, 999999).ToString();
            user.VerificationCode = code;
            user.VerificationCodeExpires = DateTime.UtcNow.AddHours(1);



            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            await _emailService.SendVerificationEmailAsync(user.Email, code);
            return StatusCode(201, "User registered. Verification email sent.");
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyEmail(VerifyEmailDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
            {
                return NotFound("No such user");
            }
            if (user.IsVerified)
            {
                return BadRequest("Already registered");
            }

            if (user.VerificationCode != dto.Code
                || user.VerificationCodeExpires < DateTime.UtcNow)
            {
                return BadRequest("Invalid or expired code.");
            }

            user.IsVerified = true;
            user.VerificationCode = null;
            user.VerificationCodeExpires = null;
            await _context.SaveChangesAsync();

            return Ok("Email verified successfully");

        }
    }
}
