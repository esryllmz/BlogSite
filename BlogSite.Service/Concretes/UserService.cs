using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Entites;
using BlogSite.Service.Abtracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Concretes;

public sealed class UserService(UserManager<User> _userManager) : IUserService

{
    public async Task<User> GetByEmailAsync(string email)
    {
        var user=await _userManager.FindByIdAsync(email);
        if (user is null)
        {
            Console.WriteLine("Kulanıcı bulunamadı");
        }
        return user;

    }

    public async Task<User> RegisterAsync(RegisterRequestDto dto)
    {
       User user = new User
       {
           FirstName=dto.FirstName,
           LastName=dto.LastName,
           Email=dto.Email,
           City=dto.City,
           UserName=dto.UserName,
           
       };

        var result = await _userManager.CreateAsync(user,dto.Password);

        if (!result.Succeeded) 
        {
            Console.WriteLine(result.Errors.ToList().First().Description);
        }
        return user;

    }
}
