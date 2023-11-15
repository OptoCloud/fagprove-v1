using backend.DataAnnotations;

namespace backend.DTOs;

public struct AccountRegisterApiRequest
{
    [Username]
    public string Username { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
}