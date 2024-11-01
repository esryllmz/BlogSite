using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entites;
using Core.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abtracts;

public interface IPostService
{
    ReturnModel<List<PostResponseDto>> GetAll();
    ReturnModel<PostResponseDto?> GetById(Guid id);
    ReturnModel<PostResponseDto> Add(CreatePostRequest create);

    ReturnModel<PostResponseDto> Update(UpdatePostRequest updatePost);

    ReturnModel<PostResponseDto> Remove(Guid id);

    ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id);

    ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string id);

}
