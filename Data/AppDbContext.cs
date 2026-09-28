using System;
using JWTAuthenticationAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthenticationAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }

}
