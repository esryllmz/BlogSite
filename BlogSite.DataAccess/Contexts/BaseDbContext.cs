﻿using BlogSite.Models.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Contexts;

public class BaseDbContext: IdentityDbContext<User,IdentityRole,string>
{
    public BaseDbContext(DbContextOptions opt):base(opt)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    public DbSet<Post> Posts{ get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Category> Categories { get; set; }


}
