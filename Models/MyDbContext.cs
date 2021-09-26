using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using excercise_api.Models;

//TODO: Maybe move this to the configurations folder instead?
namespace excercise_api
{
    public class MyDbContext : IdentityDbContext
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Excercice> Excercices { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<GymSession> GymSessions { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base (options)
        {
            
        }
    }
}