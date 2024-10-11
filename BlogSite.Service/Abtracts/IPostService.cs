using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abtracts;

public interface IPostService
{
    List<PostResponseDto> GetAll();
    PostResponseDto? GetById(Guid id);
    Post Add(CreatePostRequest create);

}
