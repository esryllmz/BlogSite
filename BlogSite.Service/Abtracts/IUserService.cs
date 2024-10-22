using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abtracts;

public interface IUserService
{
    Task<User> RegisterAsync(RegisterRequestDto dto);

    Task<User> GetByEmailAsync(string email);
}
