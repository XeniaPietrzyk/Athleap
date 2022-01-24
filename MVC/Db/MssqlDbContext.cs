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
        }

        public DbSet<Trainer> Trainerss { get; set; }
    }
}
