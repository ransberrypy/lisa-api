using Microsoft.AspNetCore.Mvc;
using LisaApi.Services.Dto;
using LisaApi.Services;
using LisaApi.Data;
using LisaApi.Models;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    // private readonly IEmailService _emailService;

    private readonly AuthenticationService _authService;
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context, AuthenticationService authService)//EmailService emailService
    {
        _context = context;
        _authService = authService;
        // _emailService = emailService;

    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserAuthDto login)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == login.Username);
        if (user == null || !_authService.VerifyPasswordHash(login.Password, Convert.FromBase64String(user.PasswordHash!), Convert.FromBase64String(user.PasswordSalt!)))
        {
            return Unauthorized();
        }
        var tokenString = _authService.GenerateJwtToken(user);
        return Ok(new { Token = tokenString });
    }

    [HttpPost("signup")]
    public  IActionResult Signup([FromBody] UserSignupDto signup)
    {
        if (_context.Users.Any(u => u.Username == signup.Username))
        {
            return BadRequest("Username already exists.");
        }

        _authService.CreatePasswordHash(signup.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var user = new User
        {
            Username = signup.Username,
            Email  = signup.Email,
            PhoneNumber = signup.PhoneNumber,
            PasswordHash = Convert.ToBase64String(passwordHash),
            PasswordSalt = Convert.ToBase64String(passwordSalt)
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        // var subject = "Welcome to Our Service!";
        // var message = $"Hello {user.Username}, welcome to our service.";
        // await _emailService.SendEmailAsync(user.Email!, subject, message);

        return Ok("User registered successfully.");
    }

}
