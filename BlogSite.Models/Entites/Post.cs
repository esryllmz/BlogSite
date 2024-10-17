﻿
using Core.Entities;
using System.Reflection.Metadata;

namespace BlogSite.Models.Entites;

public sealed class Post:Entity<Guid>
{
    

    public string Title { get; set; }

    public string Content { get; set; }

    public int CategoryId { get; set; }

    public Category Category{ get; set; }

    public long AuthorId { get; set; }

    public  User Author { get; set; }

    public  List<Comment> Comments { get; set; }


}
