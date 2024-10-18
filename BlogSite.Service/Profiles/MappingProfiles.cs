using AutoMapper;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostRequest,Post>();
        CreateMap<UpdatePostRequest, Post>();
        CreateMap<Post,PostResponseDto>()
            .ForMember(x=>x.Category, opt=>opt.MapFrom(x=>x.Category.Name))
            .ForMember(x=>x.User,opt=>opt.MapFrom(x=>x.Author.UserName));
       
    }

}
