using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequestDTO request)
    {
        var result = await _userService.Register(request);

        // Map the result to an IActionResult
        return result.Match<IActionResult>(_ => Ok(), BadRequest);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequestDTO request)
    {
        var result = await _userService.Login(request);

        // Map the result to an IActionResult
        return result.Match<IActionResult>(result => Ok(new AuthTokenResponseDTO { Token = result }), BadRequest);
    }
}