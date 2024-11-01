﻿using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Service.Abtracts;
using Core.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Concretes;

public class AuthenticationService(IUserService _userService,IJwtService _jwtService) : IAuthenticationService
{
    public async Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto)
    {
        
        var user= await _userService.LoginAsync(dto);
        var tokenResponse = _jwtService.CreateJwtToken(user);
        return new ReturnModel<TokenResponseDto>
        {
            Data = tokenResponse,
            Message = "Giriş Başarılı",
            StatusCode = 200,
            Success = true,
        };
    }

    public async Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto)
    {
        var user= await _userService.RegisterAsync(dto);
        var registerRegister = _jwtService.CreateJwtToken(user);
        return new ReturnModel<TokenResponseDto>
        {
            Data = registerRegister,
            Message = "Kayıt işlemi Başarılı",
            StatusCode = 200,
            Success = true,
        };
    }
}