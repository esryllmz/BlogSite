using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Service.Abtracts;
using Core.Tokens.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticaionController(IAuthenticationService authenticationService,DecoderService decoderService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody]LoginRequestDto dto)
    {
        var result=await authenticationService.LoginAsync(dto);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDto dto)
    {
        var result= await authenticationService.RegisterAsync(dto);
        return Ok(result);
    }
}
