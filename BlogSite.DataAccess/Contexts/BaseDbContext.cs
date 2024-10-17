﻿using BlogSite.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Contexts;

public class BaseDbContext: DbContext
{
    public BaseDbContext(DbContextOptions opt):base(opt)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    public DbSet<User> Users { get; set; }

    public DbSet<Post> Posts{ get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Category> Categories { get; set; }


}
