using Db.SQL.Configuration;
using Microsoft.EntityFrameworkCore;
using MVC.Model;
using System;

namespace Db.SQL
{
    public class MssqlDbContext : DbContext
    {
        public MssqlDbContext(DbContextOptions<MssqlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            builder.ApplyConfiguration(new TrainerConfiguration());
            //builder.ApplyConfiguration(new )
        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Athlete> Athletes {get; set;}
        public DbSet<Club> Clubs {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Competition> Compettions {get; set;}
        public DbSet<CompetitionResults> CompetitionResults { get; set;}
        public DbSet<Message> Messages {get; set;}
    }
}
