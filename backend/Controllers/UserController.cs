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
    public async Task<IActionResult> Register([FromBody] AccountRegisterApiRequest request)
    {
        var result = await _userService.Register(request);

        // Map the result to an IActionResult
        return result.Match<IActionResult>(_ => Ok(), err => BadRequest(err));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AccountLoginApiRequest request)
    {
        var result = await _userService.Login(request);

        // Map the result to an IActionResult
        return result.Match<IActionResult>(token => Ok(new AccountLoginApiResponse { Token = token }), err => BadRequest(err));
    }
}