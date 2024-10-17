using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Entites;

public sealed class Comment: Entity<Guid>
{
    public string Text{ get; set; }

    public User User { get; set; }
    public long UserId { get; set; }

    public Post Post { get; set; }

    public  Guid PostId{ get; set; }

}
