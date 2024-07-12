using System.ComponentModel.DataAnnotations;

namespace LisaApi.Models;

// User Model
public class User
{
    [Key]
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }
}