using DotnetApi.Common.Responses;
using DotnetApi.Dtos;
using DotnetApi.Interfaces;
using DotnetApi.Models;
using DotnetApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace DotnetApi.Controllers;

[ApiController]
[Route("api/[controller]")]

    public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService) 
    { 
        _authService = authService; 
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    { 
        await _authService.RegisterAsync(dto);
        return Ok(new ApiResponse<object>(true, "User registered successfully")); 
    }
    [HttpPost("login")]
    public async Task <IActionResult> LoginAsync(LoginDto dto)
    {
       var result= await _authService.LoginAsync(dto);
        return Ok(new ApiResponse<object>(true, "login successfully", result));
    }

}

