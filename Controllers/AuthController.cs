using JWTAuthenticationAPI.Data;
using JWTAuthenticationAPI.DTOs;
using JWTAuthenticationAPI.Model;
using JWTAuthenticationAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthenticationAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;

    public AuthController(AppDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto registerDto)
    {
        var existingUser = _context.Users
            .FirstOrDefault(u => u.Email == registerDto.Email);

        if (existingUser != null)
        {
            return BadRequest("User already registered");
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

        var user = new User
        {
            Name = registerDto.Name,
            Email = registerDto.Email,
            PasswordHash = passwordHash,
            Role = "User"
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok("User registered successfully");
    }
    [HttpPost("Login")]
    public IActionResult Login(LoginDto loginDto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email);

        if (user == null)
        {
            return BadRequest("Invalid Email or Password");
        }

        bool IsPasswordValid = BCrypt.Net.BCrypt.Verify(
            loginDto.Password,
            user.PasswordHash
        );

        if (!IsPasswordValid)
        {
            return BadRequest("Invalid Email or Password");
        }

        var token = _tokenService.GenerateToken(user);
        return Ok(new
        {
            message = "Login Successfull",
            token = token
        });

    }
}