
using Core.Entities;
using System.Reflection.Metadata;

namespace BlogSite.Models.Entites;

public sealed class Post:Entity<Guid>
{
    

    public string Title { get; set; }

    public string Content { get; set; }

    
}
