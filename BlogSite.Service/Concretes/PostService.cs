using AutoMapper;
using Azure;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entites;
using BlogSite.Service.Abtracts;
using Core.Entities.Responses;

namespace BlogSite.Service.Concretes;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequest create)
    {
        Post createdPost = _mapper.Map<Post>(create);
        createdPost.Id = Guid.NewGuid();

        _postRepository.Add(createdPost);

        PostResponseDto response = _mapper.Map<PostResponseDto>(createdPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto?> Delete(Guid id)
    {
        
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        List<Post> posts = _postRepository.GetAll();
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);


        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };

    }

    public ReturnModel<PostResponseDto?> GetById(Guid id)
    {
        var post = _postRepository.GetById(id);

        var response = _mapper.Map<PostResponseDto>(post);

        return new ReturnModel<PostResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };

    }

    public ReturnModel<PostResponseDto?> Update(UpdatePostRequest updatedPost)
    {
       Post post=_postRepository.GetById(updatedPost.Id);


        Post update = new Post
        {
            Id = post.Id,
            CategoryId = post.CategoryId,
            Content = updatedPost.Content,
            Title = updatedPost.Title,
            AuthorId = post.AuthorId,
            CreatedDate = post.CreatedDate,
        };

        Post updatedPost=_postRepository.Update(update);

        PostResponseDto dto=_mapper.Map<PostResponseDto>(post);

        return new ReturnModel<PostResponseDto?>
        {
            Data = dto,
            Message = "Post güncellendi",
            StatusCode = 200,
            Success = true
        };

    }
}
