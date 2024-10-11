using BlogSite.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Contexts;

public class BaseDbContext: DbContext
{
    public BaseDbContext(DbContextOptions opt):base(opt)
    {
        
    }


    public DbSet<Post> Posts{ get; set; }


}
