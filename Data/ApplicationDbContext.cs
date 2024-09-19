using System;
using dotnetTuto.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetTuto.Data;

public class ApplicationDbContext : DbContext
{
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
{
    
}
public DbSet<Category> Categories {get;set;}
}
