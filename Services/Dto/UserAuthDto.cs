namespace LisaApi.Services.Dto;

public class UserAuthDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}


public class UserSignupDto
{
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string Password { get; set; } = null!;
}
