
using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entites;
using BlogSite.Service.Concretes;
using Core.Exceptions;
using Moq;

namespace Service.Tests;

public class PostServiceTest
{
    private PostService postService;

    private Mock<IMapper> mockMapper;

    private Mock<IPostRepository> repositoryMock;

    private Mock<PostBusinessRules> rulesMock;

    [SetUp]

    public void Setup()
    {
        repositoryMock = new Mock<IPostRepository>();
        mockMapper = new Mock<IMapper>();
        rulesMock = new Mock<PostBusinessRules>();
        postService=new PostService(repositoryMock.Object,mockMapper.Object, rulesMock.Object);
    }

    public void GetAll_ReturnsSuccess()
    {
        //Arange(Veri hazırlama)
        List<Post> posts = new List<Post>();
        List<PostResponseDto> responses = new();
        repositoryMock.Setup(x => x.GetAll(null, true)).Returns(posts);
        mockMapper.Setup(x=>x.Map<List<PostResponseDto>>(posts)).Returns(responses);

        //Act(Test)

        var result= postService.GetAll();


        //Assert(senaryo tuttu mu kontrol)

        Assert.IsTrue(result.Success);
        Assert.AreEqual(responses,result.Data);
        Assert.AreEqual(200,result.StatusCode);   
        Assert.AreEqual(string.Empty,result.Message);
    }

    [Test]  
    public void Add_WhenPostAdded_ReturnSuccess()
    {
        //Arange
        CreatePostRequest dto=new CreatePostRequest("Deneme","Content",1);
        Post post=new Post
        {
            Id=new Guid("{5D5B17FD-0922-4EB0-A700-039C207E6D97}"),
            AuthorId= "{4D5B17FD-0922-4EB0-A700-039C207E6D97}",
            Title="Deneme",
            Content="Deneme",
            CategoryId=1,
            CreatedDate=DateTime.Now,
        };

        PostResponseDto response = new PostResponseDto
        {
            Id = new Guid("{5D5B17FD-0922-4EB0-A700-039C207E6D97}"),
            Category = "Deneme",
            Content = "Deneme",
            CreatedDate = DateTime.Now,
            Title = "Deneme",
            UserName = "Eso"
        };

        mockMapper.Setup(x=>x.Map<Post>(dto)).Returns(post);
        repositoryMock.Setup(x => x.Add(post)).Returns(post);
        mockMapper.Setup(x=>x.Map<PostResponseDto>(post)).Returns(response);
        //Act

        var result= postService.Add(dto, "{4D5B17FD-0922-4EB0-A700-039C207E6D97}");
        //Assert

        Assert.AreEqual(response, result.Data);
        Assert.IsTrue(result.Success);

    }

    [Test]
    public void GetById_WhenPostIsNotPresent_ThrowsException()
    {
        //Arange
        Guid id = new Guid("{36625CE6-CB9C-4DAC-98DC-8FCAE10F7413}");
        Post post = null;

        rulesMock.Setup(x => x.PostIsNullCheck(post)).Throws(new Exception("İlgili post bulunamadı"));


        //Act
        var result=postService.GetById(id); 


        //Assert
        Assert.Throws<NotFoundException>(()=>postService.GetById(id), "İlgili post bulunamadı");



    }
}
