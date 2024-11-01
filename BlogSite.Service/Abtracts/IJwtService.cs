using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abtracts;

public interface IJwtService
{
    TokenResponseDto CreateJwtToken(User user);
}
